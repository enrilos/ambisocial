import { useDispatch, useSelector } from 'react-redux';
import { decrement, increment } from '@app/store/counter.store';
import '@app/scss/theme.scss';
import Skull from '@app/scss/img/skull.svg';

export default function App() {
    const counter = useSelector((state: any) => state.counter.value);
    const dispatch = useDispatch();

    return (
        <>
            <button onClick={() => dispatch(increment())}>Increment</button>
            <span>{counter}</span>
            <button onClick={() => dispatch(decrement())}>Decrement</button>
            <div className='super-div'></div>
            <img src={Skull} alt="" />
            <h2 className='super-text'>This is App running on <span className='ml-2'>{process.env.ENV}</span> env</h2>
        </>
    );
}