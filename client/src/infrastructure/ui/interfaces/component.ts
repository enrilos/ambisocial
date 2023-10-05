export default interface IComponent {
    Component: React.FC,
    props?: { [key: string]: any };
    children?: React.ReactNode[]
}