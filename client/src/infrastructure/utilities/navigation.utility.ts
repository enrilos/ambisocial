import { useEffect, useState } from 'react';
import { useLocation } from 'react-router-dom';

export const useQueryParam = (name: string) => {
    const { search } = useLocation();
    const [value, setValue] = useState(new URLSearchParams(search).get(name));

    useEffect(() => {
        setValue(new URLSearchParams(search).get(name));
    }, [search]);

    return value;
}