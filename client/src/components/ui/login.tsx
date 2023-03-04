import { Form, Input, Checkbox, Button } from 'antd';

export default function Login() {
    return (
        <Form
            initialValues={{ remember: true }}
            onFinish={(values: any) => console.log(values)}
            autoComplete='off'
        >
            <Form.Item
                label='Username'
                name='username'
                rules={[{ required: true, message: 'Please input your username!' }]}
            >
                <Input />
            </Form.Item>

            <Form.Item
                label='Password'
                name='password'
                rules={[{ required: true, message: 'Please input your password!' }]}
            >
                <Input.Password />
            </Form.Item>

            <Form.Item name='remember' valuePropName='checked'>
                <Checkbox>Remember me</Checkbox>
            </Form.Item>

            <Form.Item>
                <Button type='primary' htmlType='submit'>
                    Submit
                </Button>
            </Form.Item>
        </Form>
    );
}