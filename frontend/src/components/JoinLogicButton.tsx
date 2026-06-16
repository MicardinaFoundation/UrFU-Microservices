import { history, useModel } from 'umi';
import { useEffect } from "react";

export default function (props: any) {
    const { refresh } = useModel('@@initialState');
    useEffect(() => {
      refresh();
  
    }, [])
    if (localStorage.getItem("auth_token")) {
        const userName = localStorage.getItem("userName") != null ? localStorage.getItem("userName") : "Anon";
        const exitJoin = () => {
            localStorage.removeItem("auth_token");
            localStorage.removeItem("userName");
            localStorage.removeItem("AD3E7S%vCgk");
            //refresh();
            location.reload();
        };
        
        return (
            <>
                <span>

                    {userName} | <a onClick={exitJoin}>Выйти</a>
                </span>
            </>
        );
        
    }
    else {
        const join = () => {
            history.push('/join');
        };
        return (
            <>
                <span>

                    <a 
                    onClick={join}
                    >Войти</a>
                </span>

            </>
        );
    }
}