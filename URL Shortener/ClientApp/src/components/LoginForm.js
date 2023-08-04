import React, { useEffect } from "react";
import './Forms.css';

const LoginForm = () => {
    const [user, setUser] = React.useState();
    const [email, setEmail] = React.useState();
    const [password, setPassword] = React.useState();
    const handleLogin = async () => {
        var isRegistered = await fetch('user?email=' + email, {method:'GET'});
        var correct = await fetch('user?email=' + email + '&password=' + password, { method: 'GET' });
        if (isRegistered && !correct) {
            alert("Wrong credentials");
        }
        if (!isRegistered) {
            await fetch('user?email=' + email + '&password=' + password, {
                method: 'POST',
                headers: { 'Content-type': 'application/json' },
                body: JSON.stringify({ email: email, password: password })
            });
        }
    }


    return (
        <div>
            <form onSubmit={handleLogin}>
                <input type="email" placeholder="Email" className="field" onChange={(event) => setEmail(event.target.value)}></input>
                <input type="text" placeholder="Password" className="field" onChange={(event) => setPassword(event.target.value)}></input>
                <button type="submit" className="btn" >Login/Register</button>
            </form>
        </div>
    );
};

export default LoginForm;
