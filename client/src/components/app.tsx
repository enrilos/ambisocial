import '@app/scss/theme.scss';
import Skull from '@app/scss/img/skull.svg';

export default function App() {
    return (
        <>
            <div className='super-div'></div>
            <img src={Skull} alt="" />
            <h2 className='super-text'>This is App running on <span className='ml-2'>port</span> {process.env.PORT}</h2>
        </>
    );
}