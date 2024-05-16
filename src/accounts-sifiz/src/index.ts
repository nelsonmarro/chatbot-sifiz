import * as botpress from ".botpress";
import { Telegraf } from "telegraf";
import { HttpClient } from "./http-client";

console.info("starting integration");

export default new botpress.Integration({
	register: async ({ webhookUrl, ctx }) => {
		/**
		 * This is called when a bot installs the integration.
		 * You should use this handler to instanciate ressources in the external service and ensure that the configuration is valid.
		 */
		const telegraf = new Telegraf(ctx.configuration.botToken);
		await telegraf.telegram.setWebhook(webhookUrl);
	},
	unregister: async ({ ctx }) => {
		/**
		 * This is called when a bot removes the integration.
		 * You should use this handler to instanciate ressources in the external service and ensure that the configuration is valid.
		 */
		const telegraf = new Telegraf(ctx.configuration.botToken);
		await telegraf.telegram.deleteWebhook({ drop_pending_updates: true });
	},
	actions: {
		queryAccounts: async ({ input, logger }) => {
			const http = new HttpClient(logger);
			const accounts = await http.getUserAccounts(input.userId);
			if (accounts.error === "") {
				return accounts;
			}
			accounts.data = [];
			return accounts;
		},
		createAccount: async ({ input, logger }) => {
			const http = new HttpClient(logger);
			const response = await http.createUserAccount(input.userId, {
				accountName: input.accountName,
			});
			if (response.error) {
				response.data.id = 0;
				response.data.accountNumber = "";
				response.data.accountName = "";
				response.data.userId = 0;
				response.data.balance = 0;
				return response;
			}
			return response;
		},
		authenticateUser: async ({ input, logger }) => {
			const http = new HttpClient(logger);
			const response = await http.getUserByCedula(input.cedula);
			if (response.error) {
				response.data.id = 0;
				response.data.cedula = "";
				response.data.email = "";
				response.data.name = "";
				response.data.lastName = "";
				response.data.phoneNumber = "";
				return response;
			}
			return response;
		},
		registerUser: async ({ input, logger }) => {
			const http = new HttpClient(logger);
			const userData = {
				name: input.name,
				lastName: input.lastName,
				cedula: input.cedula,
				email: input.email,
				phoneNumber: input.phoneNumber,
			};

			const response = await http.createUser(userData);
			if (response.error) {
				response.data.id = 0;
				response.data.cedula = "";
				response.data.email = "";
				response.data.name = "";
				response.data.lastName = "";
				response.data.phoneNumber = "";
				return response;
			}
			return response;
		},
	},
	// Declaring channels for the integration.
	// This function will be called every time the bot sends a text message to the group channel.
	channels: {
		group: {
			messages: {
				text: async ({ payload, ctx, conversation, ack }) => {
					const client = new Telegraf(ctx.configuration.botToken);
					const message = await client.telegram.sendMessage(
						conversation.tags["id"]!,
						payload.text
					);
					await ack({ tags: { id: `${message.message_id}` } });
				},
				choice: async ({ payload, ctx, conversation, ack, logger }) => {
					const client = new Telegraf(ctx.configuration.botToken);

					const inlineKeyboard = payload.options.map((option) => [
						{ text: option.label, callback_data: option.value },
					]);

					logger.forBot().debug("Inline Keyboard:", inlineKeyboard);
					// Enviar mensaje con botones en línea
					const message = await client.telegram.sendMessage(
						conversation.tags["id"]!,
						payload.text, // El texto del mensaje que pregunta al usuario
						{
							reply_markup: { inline_keyboard: inlineKeyboard },
						}
					);

					await ack({ tags: { id: `${message.message_id}` } });
				},
			},
		},
	},
	// Declaring the handler for the incoming messages from Telegram
	handler: async ({ req, client }) => {
		if (!req.body) return;
		const body = JSON.parse(req.body);
		let conversationId, userId, messageId, text;

		if (body.message) {
			// Es un mensaje de texto normal
			conversationId = body.message.chat.id;
			userId = body.message.from.id;
			messageId = body.message.message_id;
			text = body.message.text;
		} else if (body.callback_query) {
			// Es una respuesta de un botón en línea
			conversationId = body.callback_query.message.chat.id;
			userId = body.callback_query.from.id;
			messageId = body.callback_query.message.message_id;
			text = body.callback_query.data; // El 'data' contiene el valor del callback_data del botón presionado
		}

		if (!conversationId || !userId || !messageId) {
			throw new Error("Handler didn't receive a valid message");
		}

		const { conversation } = await client.getOrCreateConversation({
			channel: "group",
			tags: { id: `${conversationId}` },
		});

		const { user } = await client.getOrCreateUser({
			tags: { id: `${userId}` },
		});

		await client.createMessage({
			tags: { id: `${messageId}` },
			type: "text",
			userId: user.id,
			conversationId: conversation.id,
			payload: { text: text },
		});
	},
});
