import { IntegrationDefinition, messages, z } from "@botpress/sdk";
import { name, integrationName } from "./package.json";

export default new IntegrationDefinition({
	name: integrationName ?? name,
	version: "0.2.0",
	configuration: {
		schema: z.object({
			botToken: z.string(),
		}),
	},
	events: {
		userRegistered: {
			schema: z.object({
				id: z.number(),
				cedula: z.string(),
				email: z.string(),
			}),
		},
		userAuthenticated: {
			schema: z.object({
				id: z.number(),
				name: z.string(),
				cedula: z.string(),
				email: z.string(),
			}),
		},
		accountCreated: {
			schema: z.object({
				id: z.number(),
				accountNumber: z.string(),
			}),
		},
	},
	actions: {
		registerUser: {
			input: {
				schema: z.object({
					name: z.string(),
					lastName: z.string(),
					cedula: z.string(),
					email: z.string(),
					phoneNumber: z.string(),
				}),
			},
			output: {
				schema: z.object({
					data: z.object({
						id: z.number(),
						name: z.string(),
						lastName: z.string(),
						cedula: z.string(),
						email: z.string(),
						phoneNumber: z.string(),
					}),
					error: z.string(),
				}),
			},
			description: "Registra un usuario en el sistema",
		},
		createAccount: {
			input: {
				schema: z.object({
					userId: z.string(),
					accountName: z.string(),
				}),
			},
			output: {
				schema: z.object({
					data: z.object({
						id: z.number(),
						accountNumber: z.string(),
						accountName: z.string(),
						balance: z.number(),
						userId: z.number(),
					}),
				}),
			},
			description: "Crea una cuenta para el usuario",
		},
		queryAccounts: {
			input: {
				schema: z.object({
					userId: z.string(),
				}),
			},
			output: {
				schema: z.object({
					data: z.array(
						z.object({
							id: z.number(),
							accountNumber: z.string(),
							accountName: z.string(),
							balance: z.number(),
							userId: z.number(),
						})
					),
					error: z.string(),
				}),
			},
			description: "Consulta las cuentas del usuario",
		},
		authenticateUser: {
			input: {
				schema: z.object({
					cedula: z.string(),
				}),
			},
			output: {
				schema: z.object({
					data: z.object({
						id: z.number(),
						name: z.string(),
						lastName: z.string(),
						cedula: z.string(),
						email: z.string(),
						phoneNumber: z.string(),
					}),
					error: z.string(),
				}),
			},
			description: "Autentica un usuario en el sistema",
		},
	},
	// icon: "./assets/account-sifiz.png",
	channels: {
		group: {
			messages: {
				text: messages.defaults.text,
				choice: messages.defaults.choice,
			},
			message: {
				tags: {
					id: {
						title: "Message ID", // The title of the Message ID tag.
						description: "Message ID from Chat", // Describes what the Message ID tag is.
					},
				},
			},
			conversation: {
				tags: {
					id: {
						title: "Conversation ID", // The title of the Conversation ID tag.
						description: "Conversation ID from Chat", // Describes what the Conversation ID tag is.
					},
				},
			},
		},
	},
	// Defines the user tags for our integration.
	user: {
		tags: {
			id: {
				title: "User ID", // The title of the User ID tag.
				description: "User ID from API", // Describes what the User ID tag is.
			},
		},
	},
});
