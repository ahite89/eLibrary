import '../scss/Header.scss';

import { Button, Typography, Container } from '@mui/material';

function Header({ handleLogout, loggedIn, userData }) {

    return (
        <section className='header-section'>
            <Container className="header-container">            
                <div className='header-text-container col-md-4'>
                    <i className="bi bi-book header-book-logo"></i>
                    <Typography variant="h4" className='header-title'>Zander's eLibrary</Typography>                    
                </div>
                <div className="header-action-buttons col-md-8">
                    {userData !== null && loggedIn &&
                        <div>
                            <Typography variant="h5">Welcome, {userData.username}</Typography>
                            <Typography variant="h5">Role: {userData.role}</Typography>
                        </div>
                    }
                    {loggedIn &&
                        <div className="logout-container">
                            <Button variant="outlined" onClick={handleLogout}>
                                Logout
                            </Button>
                        </div>
                    }
                </div>
            </Container>
        </section>
    )
}

export default Header;