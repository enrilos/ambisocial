
import { BrowserRouter as Router } from 'react-router-dom';
import Routes from '@app/routes';

import '@app/scss/theme.scss';

export default function App() {
    return (
        <Router>
            <Routes />
        </Router>
    );
}