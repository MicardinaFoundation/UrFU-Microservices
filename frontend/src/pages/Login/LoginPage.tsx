import { useState } from 'react';
import { Form, Input, Button, Card, Typography, message } from 'antd';
import { UserOutlined, LockOutlined, MailOutlined, UserAddOutlined } from '@ant-design/icons';
import './LoginPage.css';
import { request, Access, Navigate, useAccess, useModel } from "@umijs/max";


const { Title, Text, Link } = Typography;



export default function LoginPage() {
    const [loading, setLoading] = useState(false);
    const [isRegister, setIsRegister] = useState(false);

    // const onFinishLogin = async (values) => {
    //     setLoading(true);
    //     try {
    //         const apiBaseUrl = import.meta.env.VITE_API_BASE_URL || 'http://localhost:5000/api';
    //         // URL-адрес Gateway для получения токена через прокси YARP
    //         const tokenUrl = apiBaseUrl.replace('/api', '/connect/token');

    //         const params = new URLSearchParams();
    //         params.append('grant_type', 'password');
    //         params.append('username', values.username);
    //         params.append('password', values.password);
    //         params.append('client_id', 'heatbalance-web');
    //         params.append('scope', 'openid profile email roles datasets:read datasets:write datasets:delete runs:read runs:execute reports:generate');

    //         const response = await axios.post(tokenUrl, params, {
    //             headers: {
    //                 'Content-Type': 'application/x-www-form-urlencoded',
    //             },
    //         });

    //         if (response.data?.access_token) {
    //             localStorage.setItem('auth_token', response.data.access_token);
    //             localStorage.setItem('userName', values.username);
    //             message.success('Вход выполнен успешно!');
    //             navigate('/');
    //         } else {
    //             message.error('Не удалось получить токен авторизации.');
    //         }
    //     } catch (error) {
    //         console.error('Login error:', error);
    //         const errorDescription = error.response?.data?.error_description || 'Неверное имя пользователя или пароль';
    //         message.error(`Ошибка входа: ${errorDescription}`);
    //     } finally {
    //         setLoading(false);
    //     }
    // };

    // const onFinishRegister = async (values) => {
    //     setLoading(true);
    //     try {
    //         const apiBaseUrl = import.meta.env.VITE_API_BASE_URL || 'http://localhost:5000/api';
    //         const registerUrl = `${apiBaseUrl}/auth/register`;

    //         const response = await axios.post(registerUrl, {
    //             username: values.username,
    //             email: values.email,
    //             password: values.password
    //         });

    //         if (response.status === 200) {
    //             message.success('Регистрация завершена успешно! Пожалуйста, войдите в систему.');
    //             navigate('/login');
    //         }
    //     } catch (error) {
    //         console.error('Registration error:', error);
    //         const errorMsg = error.response?.data?.error || 'Не удалось зарегистрироваться';
    //         message.error(`Ошибка регистрации: ${errorMsg}`);
    //     } finally {
    //         setLoading(false);
    //     }
    // };

    const handleLogin = (data: any) => {
        request('api/auth', { data, method: 'POST' }).then((response: any) => {
            console.log(response);
            localStorage.setItem('auth_token', response.token);
            localStorage.setItem('TAD3E7S%vCgk', response.userIndex);
            localStorage.setItem('userName', response.uName);
            <Navigate to="/join" replace />
            //refresh();
            //location.reload(true);
        }).catch((resp: any) => {
            let inf = "";
            // switch (resp.response.status) {
            //   case 405:
            //     inf = "Некорректный ответ с сервера!"
            //     break;
            //   default:
            //     inf = "Другая ошибка!"
            //     break;
            // }
            switch (resp.response.status) {
                // --- 4xx Ошибки клиента ---
                case 400:
                    inf = "Bad Request: Неверный запрос";
                    break;
                case 401:
                    inf = "Unauthorized: Требуется авторизация";
                    break;
                case 403:
                    inf = "Forbidden: Доступ запрещен";
                    break;
                case 404:
                    inf = "Not Found: Страница не найдена";
                    break;
                case 405:
                    inf = "Method Not Allowed: Метод не поддерживается";
                    break;
                case 408:
                    inf = "Request Timeout: Время ожидания истекло";
                    break;
                case 429:
                    inf = "Too Many Requests: Слишком много запросов";
                    break;

                // --- 5xx Ошибки сервера ---
                case 500:
                    inf = "Internal Server Error: Ошибка сервера";
                    break;
                case 502:
                    inf = "Bad Gateway: Ошибка шлюза";
                    break;
                case 503:
                    inf = "Service Unavailable: Сервис временно недоступен";
                    break;
                case 504:
                    inf = "Gateway Timeout: Шлюз не отвечает";
                    break;

                // --- Значение по умолчанию ---
                default:
                    inf = `Unknown Status: Неизвестный код ошибки (${resp.response.status})`;
            }
            message.error(`${resp.response.data} ${inf}. (👇F12)`);
            console.log(resp);
        })
    }

    return (
        <div className="login-container">
            <div className="vista-container">
                <div className="vista-bg-rays"></div>
                <div className="vista-floor"></div>
            </div>

            <div className="login-background" />
            <div className="login-card" >
                <div className={`sliderWrapper ${isRegister ? "showRegister" : ''}`}>
                    <div className='formBox'>
                        <div className="login-header">
                            <div className="login-logo">
                                <UserOutlined />
                            </div>
                            <Title level={2} className="login-title">Вход</Title>
                        </div>

                        <Form
                            // name="login"
                            initialValues={{ remember: true }}
                            onFinish={handleLogin}
                            layout="horizontal"
                            size="large"
                        >
                            <Form.Item
                                name="login"
                                rules={[{ required: true, message: 'Введите имя пользователя (или почту)!' }]}
                            >
                                <Input
                                    prefix={<UserOutlined className="site-form-item-icon" />}
                                    placeholder="Имя пользователя или Email"
                                />
                            </Form.Item>

                            <Form.Item
                                name="password"
                                rules={[{ required: true, message: 'Пожалуйста, введите пароль!' }]}
                            >
                                <Input.Password
                                    prefix={<LockOutlined className="site-form-item-icon" />}
                                    placeholder="Пароль"
                                />
                            </Form.Item>

                            <Form.Item>
                                <Button type="primary" htmlType="submit" className="login-form-button" loading={loading} block>
                                    Войти
                                </Button>
                            </Form.Item>

                            <div className="login-footer">
                                <Link onClick={() => setIsRegister(true)} className="login-link">Регистрация</Link>
                            </div>
                        </Form>
                    </div>


                    <div className='formBox'>
                        <div className="login-header">
                            <div className="login-logo">
                                <UserAddOutlined />
                            </div>
                            <Title level={2} className="login-title">Регистрация</Title>
                        </div>


                        <Form
                            name="register"
                            //onFinish={onFinishRegister}
                            layout="vertical"
                            size="large"
                        >
                            <Form.Item
                                name="username"
                                rules={[
                                    { required: true, message: 'Пожалуйста, введите имя пользователя!' },
                                    { min: 3, message: 'Имя пользователя должно состоять минимум из 3 символов!' }
                                ]}
                            >
                                <Input
                                    prefix={<UserOutlined />}
                                    placeholder="Имя пользователя"
                                />
                            </Form.Item>

                            <Form.Item
                                name="email"
                                rules={[
                                    { type: 'email', message: 'Введите корректный E-mail!' }
                                ]}
                            >
                                <Input
                                    prefix={<MailOutlined />}
                                    placeholder="E-mail (необязательно)"
                                />
                            </Form.Item>

                            <Form.Item
                                name="password"
                                rules={[
                                    { required: true, message: 'Пожалуйста, введите пароль!' },
                                    { min: 6, message: 'Пароль должен быть не менее 6 символов!' }
                                ]}
                            >
                                <Input.Password
                                    prefix={<LockOutlined />}
                                    placeholder="Пароль"
                                />
                            </Form.Item>

                            <Form.Item
                                name="confirm"
                                dependencies={['password']}
                                hasFeedback
                                rules={[
                                    { required: true, message: 'Пожалуйста, подтвердите ваш пароль!' },
                                    ({ getFieldValue }) => ({
                                        validator(_, value) {
                                            if (!value || getFieldValue('password') === value) {
                                                return Promise.resolve();
                                            }
                                            return Promise.reject(new Error('Пароли не совпадают!'));
                                        },
                                    }),
                                ]}
                            >
                                <Input.Password
                                    prefix={<LockOutlined />}
                                    placeholder="Подтвердите пароль"
                                />
                            </Form.Item>

                            <Form.Item>
                                <Button type="primary" htmlType="submit" className="login-form-button" loading={loading} block>
                                    Зарегистрироваться
                                </Button>
                            </Form.Item>

                            <div className="register-footer">
                                <Link onClick={() => setIsRegister(false)} className="login-link">Войти</Link>
                            </div>
                        </Form>
                    </div>

                </div>
            </div>
        </div>
    );
}
