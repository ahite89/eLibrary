import './scss/App.scss';
import { useState, useEffect } from 'react';
import { Typography, Button } from '@mui/material';

import Login from './components/Login';
import Register from './components/Register';
import Header from './components/Header';
import Library from './components/Library';
import agent from './api/agent';

function App() {

    // Login, Register, Role
    const [loggedIn, setLoggedIn] = useState(false);
    const [userData, setUserData] = useState([]);
    const [hasAccount, setHasAccount] = useState(true);

    // Get current user via local storage
    useEffect(() => {
        const userData = hasAccount;
        if (userData !== null) {
            agent.Account.current(JSON.parse(userData)).then(userData => {
                if (userData !== null) {
                    setLoggedIn(true);
                    setUserData(userData);
                }
            }).catch(error => console.log(error.response))
        }
    }, []);

    const handleLogin = (userData) => {
        if (userData !== null) {
            setUserData(userData);
            setLoggedIn(true);
            localStorage.setItem("userData", JSON.stringify(userData));
        }
    };

    const handleLogout = () => {
        setLoggedIn(false);
        setUserData([]);
        localStorage.removeItem("userData");
    };

    return (
        <>
            <Header
                handleLogout={handleLogout}
                loggedIn={loggedIn}
                userData={userData}
            />
            <div className="library-background"></div>
            {!loggedIn && hasAccount &&
                <div className='login-container col-md-4 col-md-offset-4'>
                    <Login onLogin={handleLogin} />
                    <div className="toggle-login-container">
                        <Typography variant="h6">Don't have an account?</Typography>
                        <Button className="toggle-login-button" variant="outlined"
                            onClick={() => setHasAccount(false)}>Sign up now</Button>
                    </div>
                </div>
            }
            {!loggedIn && !hasAccount &&
                <div className='login-container col-md-4 col-md-offset-4'>
                    <Register onLogin={handleLogin} />
                    <div className="toggle-login-container">
                        <Typography variant="h6">Already have an account?</Typography>
                        <Button className="toggle-login-button" variant="outlined"
                            onClick={() => setHasAccount(true)}>Login</Button>
                    </div>
                </div>
            }
            {loggedIn &&
                <Library userData={userData} />
            }
        </>
    );
}

export default App;
