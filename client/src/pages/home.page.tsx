import Login from '@app/components/ui/login';
import '@app/scss/pages/_home.page.scss';

export default function HomePage(props?: { [key: string]: any }) {
    return (
        <main>
            <Login />
        </main>
    );
}