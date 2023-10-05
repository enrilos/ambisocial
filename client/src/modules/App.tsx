import { BrowserRouter as Router } from 'react-router-dom';
import { AppRoutes } from '@modules/Routes';

import '@infrastructure/ui/scss/all.scss';

export const App = () => {
    return (
        <main>
            <Router>
                <AppRoutes />
            </Router>
        </main>
    );
}