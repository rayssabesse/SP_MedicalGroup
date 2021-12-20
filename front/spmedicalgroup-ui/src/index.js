// IMPORTS
import React from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router, Redirect, Switch } from 'react-router-dom';

import './index.css';

import Home from './pages/home/App.jsx';
import Login from './pages/login/login';
import ManageApps from './pages/admin-apps/admin-apps';
import DoctorApps from './pages/doctor/doctor';
import PatientApps from './pages/patient/patient'
import NotFound from './pages/not-found/not-found';

import reportWebVitals from './reportWebVitals';

import { parseJWT, userAuth } from './services/auth';

// PERMISSIONS
const PermAdmin = ({ component: Component }) => (
  <Route
    render={(props) =>
      userAuth() && parseJWT().role === '1' ? (
        <Component {...props} />
      ) : (
        <Redirect to="login" />
      )
    }
  />
);
const PermDoctor = ({ component: Component }) => (
  <Route
    render={(props) =>
      userAuth() && parseJWT().role === '2' ? (
        <Component {...props} />
      ) : (
        <Redirect to="login" />
      )
    }
  />
);
const PermPatient = ({ component: Component }) => (
  <Route
    render={(props) =>
      userAuth() && parseJWT().role === '3' ? (
        <Component {...props} />
      ) : (
        <Redirect to="login" />
      )
    }
  />
);

// ROUTING
const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Home} />
        <Route path="/login" component={Login} />
        <PermAdmin path="/admin-apps" component={ManageApps} />
        <PermDoctor path="/doctor" component={DoctorApps} />
        <PermPatient path="/patient" component={PatientApps} />
        <Route path="/not-found" component={NotFound} />
        <Redirect to="/not-found" />
      </Switch>
    </div>
  </Router>
)


ReactDOM.render(
  // <React.StrictMode>
  //   <Home />
  // </React.StrictMode>,
  routing,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();


