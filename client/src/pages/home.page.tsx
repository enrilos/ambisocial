import { useEffect } from 'react';
import { useDispatch } from 'react-redux';
import { useLocation, useNavigate } from 'react-router-dom';
import { useCounter } from '@app/store/selectors';
import { increment } from '@app/store/counter.store';
import Skull from '@app/scss/img/skull.svg';

import '@app/scss/pages/_home.page.scss';

export default function HomePage() {
    const counter = useCounter();
    const navigate = useNavigate();
    const location = useLocation();
    const dispatch = useDispatch();

    useEffect(() => {
        dispatch(increment());
    }, [location.search]);

    return (
        <div>
            <button onClick={(e) => {
                e.preventDefault();
                navigate(location.search ? location.search.concat('&abc') : location.search.concat('?abc'));
            }}
            >
                Increment
            </button>
            <span>{counter.value}</span>
            <div className='super-div'></div>
            <img src={Skull} alt="" />
            <h2 className='super-text'>This is App running on <span className='ml-2'>{process.env.ENV}</span> env</h2>
        </div>
    );
}