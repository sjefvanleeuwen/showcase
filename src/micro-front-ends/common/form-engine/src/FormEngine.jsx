import React,{ Component} from 'react';
import { Form, FormEngine } from 'react-json-form-engine';
import 'form-engine.min.css';
const loginForm = {
  id: 'loginForm',
  title: 'Login Form',
  sections: [
    {
      id: 'loginSection',
      title: 'Login Section',
      subsections: [
        {
          id: 'loginSubsection',
          title: 'Login',
          subtitle: 'Please enter your credentials.',
          fields: [
            {
              id: 'username',
              title: 'Username',
              type: 'string',
              required: true
            },
            {
              id: 'password',
              title: 'Password',
              type: 'string',
              required: true
            },
            {
              id: 'rememberMe',
              title: 'Remember me',
              type: 'boolean'
            }
          ]
        }
      ]
    }
  ],
  decorators: {
    password: {
      component: {
        type: 'password'
      }
    }
  }
};

export default class FormEngineComponent extends Component {
  render(){
    const instance = new FormEngine(loginForm);
    return (
        <Form
          instance={instance}
          onUpdate={(id, value) => {}}
          onSubmit={(hasError) => {}}
        />
    );
}};
