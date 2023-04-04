import '../scss/Login.scss';

// CONVERT TO REGISTER


import { useState } from 'react';
import { Button, Card, TextField, MenuItem } from '@mui/material';
import agent from '../api/agent';

function Register({ onLogin }) {

    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [username, setUsername] = useState('');

    const handleSubmit = (event) => {
        event.preventDefault();

        const role = event.target.select.value;

        const registerData = {
            Email: email,
            Password: password,
            Username: username,
            Role: role
        };

        agent.Account.register(registerData).then((userData) => {
            onLogin(userData);
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
                <TextField
                    required
                    label='Username'
                    variant="outlined"
                    value={username}
                    onChange={(event) => setUsername(event.target.value)}
                />               
                <TextField required label="Role" name="select" select>
                    <MenuItem value="librarian">Librarian</MenuItem>
                    <MenuItem value="user">User</MenuItem>
                </TextField>
                <Button variant="contained" type="submit">Register</Button>
            </form>
        </Card>
    );
}

export default Register;