import React, { useEffect } from 'react';
import { IComponent } from '@app/interfaces/component.interface';

export interface IPage {
    title: string,
    component: IComponent,
    restricted?: boolean
}

export default function Page(page: IPage) {
    useEffect(() => {
        document.title = page.title;
    }, [page.title]);

    const { component, props, children } = page.component;

    return React.createElement(component, props, children);
}