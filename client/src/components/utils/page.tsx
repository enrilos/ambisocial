import React, { useEffect } from 'react';

export interface IPage {
    title: string,
    component: React.FC,
    props?: { [key: string]: any },
    children?: React.ReactNode[]
    restricted?: boolean
}

export default function Page(page: IPage) {
    useEffect(() => {
        document.title = page.title;
    }, [page.title]);

    return React.createElement(page.component, page?.props, page?.children);
}