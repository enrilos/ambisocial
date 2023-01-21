import { useEffect, useState } from "react";
import { Link, useLocation } from "react-router-dom";
import { Menu } from "antd";
import { ItemType } from "antd/es/menu/hooks/useItems";
import { MailOutlined } from '@ant-design/icons';

const items: ItemType[] = [
    {
        label: (<Link to='/why'>Why</Link>),
        key: 'why',
        icon: <MailOutlined />
    }
];

export default function Header() {
    const [current, setCurrent] = useState<string>('');
    const location = useLocation();

    useEffect(() => {
        const keys = location.pathname.split('/').filter(key => key);
        setCurrent(keys[0] ?? '');
    }, [location.pathname]);

    const clickHandler = (e: any) => {
        e.domEvent.preventDefault();
        setCurrent(e.key ?? '');
    };

    return <Menu
        onClick={clickHandler}
        selectedKeys={[current]}
        items={items}
        mode="horizontal"
    />;
}