import { useEffect, useState } from 'react';

export const debounce = (func: () => void, delay = 500) => {
    let timer: number;

    return () => {
        clearTimeout(timer);
        timer = setTimeout(() => {
            func.apply(null);
        }, delay);
    }
}

export const useDebounce = (value: string | number, delay = 500) => {
    const [val, setVal] = useState<string | number>(value);

    useEffect(() => {
        const handler = setTimeout(() => {
            setVal(value);
        }, delay);

        return () => {
            clearTimeout(handler);
        };
    }, [value, delay]);

    return val;
}