import { createBrowserRouter } from 'react-router-dom';
import App from '../App.js';
import Library from '../components/Library';
import Login from '../components/Login';

export const routes = [
    {
        path: '/',
        element: <App />,
        children: [
            { path: 'library', element: <Library /> },
            { path: 'login', element: <Login /> }
        ]
    }
]

export const router = createBrowserRouter(routes);