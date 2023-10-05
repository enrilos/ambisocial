import React, { useEffect } from 'react';
import IComponent from '@infrastructure/ui/interfaces/component';

interface IPage {
    title: string,
    component: IComponent,
    restricted?: boolean
}

export const Page = ({
    title,
    component,
    restricted
}: IPage) => {
    useEffect(() => {
        if (restricted) return;
        document.title = title;
    }, [title]);

    if (restricted) return <h1>Not found</h1>;

    const { Component, props, children } = component;

    return React.createElement(Component, props, children);
}