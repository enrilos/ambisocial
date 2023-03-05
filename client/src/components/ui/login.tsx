import { Link } from 'react-router-dom';
import { Form, Input, Button } from 'antd';

export default function Login() {
    return (
        <div className='d-flex flex-row justify-content-center'>
            <div className='d-flex flex-column justify-content-center mt-3 container-login-wrapper'>
                <div className='d-flex flex-column justify-content-start align-items-center border py-3 mb-2'>
                    <div className='my-3'>AmbiSocial</div>
                    <Form
                        initialValues={{ remember: true }}
                        onFinish={(values: any) => console.log(values)}
                        className='d-flex flex-column align-items-stretch p-3'
                        autoComplete='off'
                    >
                        <div className='mb-2'>
                            <Form.Item
                                name='username'
                                rules={[{ required: true, message: 'Please input your username!' }]}
                            >
                                <Input placeholder='Username or email' />
                            </Form.Item>

                            <Form.Item
                                name='password'
                                rules={[{ required: true, message: 'Please input your password!' }]}
                            >
                                <Input.Password placeholder='Password' />
                            </Form.Item>
                        </div>

                        <Form.Item noStyle={true}>
                            <Button
                                type='primary'
                                htmlType='submit'
                                block={true}
                                className='d-flex justify-content-center align-items-center'
                            >
                                <span className='fw-bold letter-spacing-normal'>Submit</span>
                            </Button>
                        </Form.Item>
                    </Form>
                </div>
                <div className='text-center border py-3'>Don't have an account? <Link to='/why'>Sign up</Link></div>
            </div>
        </div>
    );
}