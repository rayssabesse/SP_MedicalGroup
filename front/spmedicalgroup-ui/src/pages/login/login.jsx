import { Component } from "react";
import axios from "axios";
import { Link } from 'react-router-dom';
import { parseJWT, userAuth } from "../../services/auth";

import '../../assets_/css/login.css'
import '../../assets_/css/global.css'
import logo from '../../assets_/both/logo.png';
import goback from '../../assets_/site/back.png';
import dudefromlogin from '../../assets_/site/login.png';

export default class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            email: '',
            password: '',
            errorMessage: '',
            isLoading: false
        };
    };

    wLogin = (event) => {
        event.preventDefault();
        console.log("api")
        this.setState({ errorMessage: '', isLoading: true })
        axios.post('http://localhost:5000/api/Login', {
            email: this.state.email,
            password: this.state.password
        })
            .then(answer => {
                if (answer.status === 200) {
                    localStorage.setItem("user-login", answer.data.token);
                    this.setState({ isLoading: false });

                    switch (parseJWT().role) {
                        case 1:
                            this.props.history.push("/admin")
                            console.log("Estou Logado: " + userAuth())
                            break;
                        case 2:
                            this.props.history.push("/doctor")
                            console.log("Estou Logado: " + userAuth())
                            break;
                        case 3:
                            this.props.history.push("/patient")
                            console.log("Estou Logado: " + userAuth())
                            break;
                        default:
                            this.props.history.push("/")
                            break;

                    }
                }
            }).catch(error => console.log(error), this.setState({ errorMessage: "Email e/ou Senha inválidos." }))
    }

    refreshStateField = (field) => {
        this.setState({ [field.target.name]: field.target.value })
    }

    render() {
        return (
            <div>
                <header>
                    <Link to="/">
                        <div className="spmgback">
                            <img src={goback} />
                        </div>
                    </Link>
                    <Link to="/">
                        <div className="spmg">
                            <img src={logo} />
                            <a>sp medical group</a>
                        </div>
                    </Link>
                </header>
                <div className="block">
                    <img src={dudefromlogin} className="body_img" />
                    <div className="login_box">
                        <div className="login_box_info">
                            <div className="login_lines">
                                <div className="login_box_blue_line"></div>
                                <div className="login_box_orange_line"></div>
                            </div>
                        </div>
                        <div className="login_info">
                            <a>bem vindo</a>
                            <div className="user_info">
                                <span>email de usuário</span>
                                <input type="email" name="email" value={this.state.email} onChange={this.refreshStateField} />
                                <span>senha</span>
                                <input type="password" name="password" value={this.state.password} onChange={this.refreshStateField} />
                            </div>
                            <div className="loginbtn">
                                {
                                    this.state.isLoading === true &&
                                    <button type="submit" disabled className="login_btn2">Loading...</button>
                                }
                                {
                                    this.state.isLoading === false &&
                                    <button type="submit" disabled={this.state.email === '' || this.state.password === '' ? 'none' : ''} className="login_btn2">entrar</button>
                                }
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}