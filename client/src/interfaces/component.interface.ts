export interface IComponent {
    component: React.FC,
    props?: { [key: string]: any },
    children?: React.ReactNode[]
}