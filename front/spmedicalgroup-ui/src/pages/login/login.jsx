import { Component } from "react";
import axios from "axios";
import { Link } from 'react-router-dom';
import { parseJWT, userAuth } from "../../services/auth";

import "../../assets_/css/login.css"
import { logo } from '../../assets_/both/logo.png';

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

    RefreshStateField = (field) => {
        this.setState({[field.target.name]: field.target.value})
    }

    // ACHO QUE É O CSS
    // render(){

    // }
}