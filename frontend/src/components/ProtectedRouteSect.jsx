import { Navigate, Outlet } from 'umi';
export default function ProtectedRoute({ children }) {
  const token = localStorage.getItem('auth_token');

  if (!token) {
    // Пользователь не авторизован -> перенаправляем на страницу входа
    return <Navigate to="/join" replace />;
  }

  
  // Авторизован -> рендерим дочерние компоненты
  return <Outlet />;
}