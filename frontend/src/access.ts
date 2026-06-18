export default function access(initialState: any){
    const {currentUser} = initialState || {};
    const token = localStorage.getItem('auth_token');


    return {
        isAdmin: currentUser?.role === 'admin',
        isUser: !!currentUser,
        isAuth: !!token,
    }
}