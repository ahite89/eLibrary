import './scss/App.scss';
import { useState } from 'react';
import { Typography, Button } from '@mui/material';

import Login from './components/Login';
import Register from './components/Register';
import Header from './components/Header';
import Library from './components/Library';

function App() {

    // Login, Register, Role
    const [loggedIn, setLoggedIn] = useState(false);
    const [userRole, setUserRole] = useState('');
    const [hasAccount, setHasAccount] = useState(true);

    const assignUserRole = (role) => {
        setUserRole(role);
    };

    return (
        <>
            <Header setLoggedIn={setLoggedIn} loggedIn={loggedIn} />
            <div className="library-background"></div>
            {!loggedIn && hasAccount &&
                <div className='login-container col-md-4 col-md-offset-4'>
                    <Login assignRole={assignUserRole} onLogin={() => setLoggedIn(true)} />
                    <div className="toggle-login-container">
                        <Typography variant="h6">Don't have an account?</Typography>
                        <Button className="toggle-login-button" variant="outlined"
                            onClick={() => setHasAccount(false)}>Sign up now</Button>
                    </div>
                </div>
            }
            {!loggedIn && !hasAccount &&
                <div className='login-container col-md-4 col-md-offset-4'>
                    <Register assignRole={assignUserRole} onLogin={() => setLoggedIn(true)} />
                    <div className="toggle-login-container">
                        <Typography variant="h6">Already have an account?</Typography>
                        <Button className="toggle-login-button" variant="outlined"
                            onClick={() => setHasAccount(true)}>Login</Button>
                    </div>
                </div>
            }
            {loggedIn &&
                <Library userRole={userRole} />
            }
        </>
    );
}

export default App;
