import styles from './HomePage.module.scss';

export interface IHomePageProps {
    abc?: string,
    children?: React.ReactNode[]
}

const HomePage = ({
    abc,
    children
}: IHomePageProps) => {
    return (
        <div className={styles.superText}>Hullo!{abc}{children}</div>
    );
}

export default HomePage;