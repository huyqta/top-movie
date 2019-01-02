import * as React from 'react';
import { RouteComponentProps } from 'react-router-dom';

export default class Login extends React.Component<RouteComponentProps<{}>, {}> {
    public render() {
        return <div>
            <h1>Hello, world!</h1>
            <p>Username:</p><input type="text" id="username" name="username" />
            <p>Password:</p><input type="password" id="password" name="password" />
            <br />
            <input type="submit" name="submit" title="Login" value="Login2" />
        </div>;
    }
}
