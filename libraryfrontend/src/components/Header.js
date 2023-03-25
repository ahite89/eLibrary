import '../scss/Header.scss';

import { Button, Typography, Container, AppBar } from '@mui/material';

function Header({ setLoggedIn, loggedIn }) {

    return (
        <section className='header-section'>
            <AppBar position="static">
                <Container className="header-container">            
                    <div className='header-text-container col-md-4'>
                        <i className="bi bi-book header-book-logo"></i>
                        <Typography variant="h4" className='header-title'>Troy Web eLibrary</Typography>
                    </div>
                    <div className="header-action-buttons col-md-8">                   
                        {loggedIn &&
                            <div className="logout-container">
                                <Button variant="contained" onClick={() => setLoggedIn(false)}>
                                    Logout
                                </Button>
                            </div>
                        }
                    </div>
                </Container>
            </AppBar>
        </section>
    )
}

export default Header;