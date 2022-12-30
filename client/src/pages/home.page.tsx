import { Button } from 'antd';
import { useDispatch } from 'react-redux';
import { useCounter } from '@app/store/selectors';
import { decrement, increment } from '@app/store/counter.store';
import Skull from '@app/scss/img/skull.svg';

import '@app/scss/pages/_home.page.scss';

export default function HomePage() {
    const counter = useCounter();
    const dispatch = useDispatch();

    const env = import.meta.env as { [key: string]: string };

    return (
        <div className="my-4">
            <Button type="primary" onClick={(e) => {
                e.preventDefault();
                dispatch(increment());
            }}
            >
                Increment
            </Button>
            <span>{counter.value}</span>
            <Button type="primary" onClick={(e) => {
                e.preventDefault();
                dispatch(decrement());
            }}
            >
                Decrement
            </Button>
            <div className='super-div'></div>
            <img src={Skull} alt="" />
            <h2 className='super-text'>This is App running on <span className='ml-2'>{env.APP_ENV}</span> env, port: {env.APP_PORT}</h2>
        </div>
    );
}