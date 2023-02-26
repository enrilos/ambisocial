import { useEffect, useState } from "react";

export function debounce(func: () => void, delay = 500) {
    let timer: NodeJS.Timeout;

    return () => {
        clearTimeout(timer);
        timer = setTimeout(() => {
            func.apply(null);
        }, delay);
    }
}

export function useDebounce(value: string | number, delay = 500) {
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