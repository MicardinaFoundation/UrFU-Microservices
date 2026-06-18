import { request as req } from "@umijs/max"
import { message } from "antd";

export async function getInitialState() {
    const token = localStorage.getItem('auth_token');
    if (!token) {
        return { currentUser: null };
    }
    const currentUser = await req('/api/user')
    return { currentUser };
}

function errHandler(staus: number) {
    switch (staus) {
        case 401:
            message.warning('Сессия истекла. Пожалуйста, войдите в систему заново.');
            localStorage.removeItem("auth_token");
            localStorage.removeItem("userName");
            localStorage.removeItem("AD3E7S%vCgk");
            location.reload();
            break;
        default:
            break;
    }
}

export const request = {
    timeout: 60000,
    errorConfig: {
        errorHandler: (err: any) => { errHandler(err.response.status) },
        errorThrower: () => { }
    },
    requestInterceptors: [
        (config: any) => {
            const token = localStorage.getItem('auth_token');
            const authHeaders = token && (config.url.substring(0, 5) == '/api/') ?
                { Authorization: 'Bearer ' + token } :
                {};

            config.headers = { ...config.headers, ...authHeaders };
            return config;
        }
    ],
    responseInterceptors: []
};