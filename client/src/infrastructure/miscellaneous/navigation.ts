import { useEffect, useState } from 'react';
import { useLocation } from 'react-router-dom';

export function useQueryParam(name: string) {
    const location = useLocation();
    const [value, setValue] = useState(new URLSearchParams(location.search).get(name));

    useEffect(() => {
        setValue(new URLSearchParams(location.search).get(name));
    }, [location]);

    return value;
}