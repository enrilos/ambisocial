import { Link } from 'react-router-dom';
import styles from './Header.module.scss';

export const Header = () => {
    return (
        <header className='p-4 mx-5'>
            <nav className='d-flex justify-content-between align-items-center'>
                <Link to='/'>AmbiSocial</Link>
            </nav>
        </header>
    );
}