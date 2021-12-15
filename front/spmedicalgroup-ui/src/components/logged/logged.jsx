import { Link } from "react-router-dom";
import { userAuth, parseJWT } from "../../services/auth";

export default function Analysis() {
    if (userAuth() == true) {
        switch (parseJWT().role) {
            case "1":
                return (<Link to="/admin">Admin Dashboard</Link>)
            case "2":
                return (<Link to="/doctor">Médico Dashboard</Link>)
            case "3":
                return (<Link to="/patient">Paciente Dashboard</Link>)
            default:
                return (<Link to="/">Home Page</Link>)
        }
    } else {
        return <Link to="/login">Login</Link>
    }
}