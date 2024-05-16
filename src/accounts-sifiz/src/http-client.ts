import { IntegrationLogger } from "@botpress/sdk/dist/integration/logger";
import axios, { AxiosInstance } from "axios";
import { AccountCreate } from "./models/account-create.model";
import { Account } from "./models/account.model";
import { ApiResponse } from "./models/api-response.model";
import { UserCreate } from "./models/user-create.model";
import { User } from "./models/user.model";

const baseUrl =
	"https://381e-2800-bf0-179-ea-ec6d-71df-dc44-598f.ngrok-free.app";

export class HttpClient {
	private axios: AxiosInstance;
	private logger: IntegrationLogger;

	constructor(logger: IntegrationLogger) {
		this.axios = axios.create({ baseURL: baseUrl });
		this.logger = logger;
	}

	private async get<T>(url: string): Promise<ApiResponse<T>> {
		try {
			const response = await this.axios.get<T>(url);
			this.logger.forBot().debug("GET Request successful:", response);
			return { data: response.data, error: "" };
		} catch (error) {
			this.logger.forBot().debug("GET Request failed:", error);
			return { data: {} as T, error: "Ocurrio un error en la petición" };
		}
	}

	private async post<TResponse, TRequest>(
		url: string,
		data: TRequest
	): Promise<ApiResponse<TResponse>> {
		try {
			const response = await this.axios.post<TResponse>(url, data);
			this.logger.forBot().debug("POST Request successful:", response);
			return { data: response.data, error: "" };
		} catch (error) {
			this.logger.forBot().debug("POST Request failed:", error);
			return {
				data: {} as TResponse,
				error: "Ocurrio un error al validar sus datos",
			};
		}
	}

	public async getUserByCedula(cedula: string): Promise<ApiResponse<User>> {
		return this.get<User>(`/users/by-cedula/${cedula}`);
	}

	public async getUserById(userId: number): Promise<ApiResponse<User>> {
		return this.get<User>(`/users/${userId}`);
	}

	public async getUserAccounts(
		userId: string
	): Promise<ApiResponse<Account[]>> {
		const accountList = await this.get<Account[]>(`/accounts/${userId}`);
		return accountList;
	}

	public async getUserAccount(
		userId: string,
		accountId: string
	): Promise<ApiResponse<Account>> {
		return this.get<Account>(`/accounts/${userId}/${accountId}`);
	}

	public async createUser(user: UserCreate): Promise<ApiResponse<User>> {
		return this.post<User, UserCreate>(`/users`, user);
	}

	public async createUserAccount(
		userId: string,
		account: AccountCreate
	): Promise<ApiResponse<Account>> {
		return this.post<Account, AccountCreate>(`/accounts/${userId}`, account);
	}
}
