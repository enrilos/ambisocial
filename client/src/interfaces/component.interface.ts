export default interface IComponent {
    component: React.FC,
    props?: { [key: string]: any },
    children?: React.ReactNode[]
}