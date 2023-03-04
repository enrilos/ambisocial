import { Link } from 'react-router-dom';
import { UserOutlined } from '@ant-design/icons';

import '@app/scss/_header.scss';

export default function Header() {
    return (
        <header className='p-4 mx-5'>
            <nav className='d-flex justify-content-between align-items-center'>
                <Link to='/' className='nav-link-main'>AmbiSocial</Link>
                <section className='d-flex justify-content-between align-items-center nav-links-wrapper'>
                    <Link to='/discover'>Discover</Link>
                    <Link to='/why'>Why</Link>
                    <Link to='/contact'>Contact</Link>
                    <div className='nav-auth-wrapper'>
                        <Link to='/login'><UserOutlined /></Link>
                    </div>
                </section>
            </nav>
        </header>
    );
}