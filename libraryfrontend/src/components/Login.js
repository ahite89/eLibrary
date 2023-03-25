import '../scss/Login.scss';

import { useState } from 'react';
import { Button, Card, TextField } from '@mui/material';
import agent from '../api/agent';

function Login({ assignRole, onLogin }) {

    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const handleSubmit = (event) => {
        event.preventDefault();

        const loginData = {
            Email: email,
            Password: password,
        };

        agent.Account.login(loginData).then((userData) => {
            assignRole(userData.role);
            onLogin();
        })        
    };

    return (
        <Card>
            <form className='login-form' onSubmit={handleSubmit}>
                <TextField
                    required
                    label='Email'
                    variant="outlined"
                    value={email}
                    onChange={(event) => setEmail(event.target.value)}
                />
                <TextField
                    required
                    label='Password'
                    variant="outlined"
                    value={password}
                    onChange={(event) => setPassword(event.target.value)}
                />
                <Button variant="contained" type="submit">Login</Button>
            </form>
        </Card>
    );
}

export default Login;