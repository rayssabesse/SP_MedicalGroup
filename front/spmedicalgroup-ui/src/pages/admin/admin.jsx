import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Link, useHistory } from 'react-router-dom';

import '../../assets_/css/admin.css'
import '../../assets_/css/global.css'
import action_users from '../../assets_/site/users.png';
import action_apps from '../../assets_/site/apps.png';
import action_clinics from '../../assets_/site/clinics.png';
import logo from '../../assets_/both/logo.png';

export default function AdminApps() {
    const [list_Patients, setlistPatients] = useState([]);
    const [list_Doctors, setlistDoctors] = useState([]);
    const [list_Apps, setlistApps] = useState([]);
    const [idPatient, setPatient] = useState(0);
    const [idDoctor, setDoctor] = useState(0);
    const [idSituation, setSituation] = useState(0);
    const [dateApps, setDate] = useState(new Date());
    const [description, setDescription] = useState('');
    const [isLoading, setisLoading] = useState(false);
    const [Message, setMessage] = useState('');
    let history = useHistory();

    const [open, setOpen] = React.useState(false);
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);

    function logout() {
        localStorage.removeItem('user-login');
        history.push('/login');
    }

    function listPatients() {
        axios('http://localhost:5000/api/patient', {
            headers: { 'Authorization': 'Bearer ' + localStorage.getItem('user-login') }
        }).then((answer) => {
            if (answer.status === 200) {
                setlistPatients(answer.data)
            }
        }).catch((error) => console.log(error));
    }

    function listDoctors() {
        axios('http://localhost:5000/api/doctor', {
            headers: { 'Authorization': 'Bearer ' + localStorage.getItem('user-login') }
        }).then((answer) => {
            if (answer.status === 200) {
                setlistDoctors(answer.data)
            }
        }).catch((error) => console.log(error));
    }

    function listApps() {
        axios('http://localhost:5000/api/appointment', {
            headers: { 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login') }
        }).then(answer => {
            if (answer.status === 200) {
                setlistApps(answer.data)
            };
            setMessage('');
        }).catch(erro => console.log(erro));
    }

    function registerApps(event) {
        event.preventDefault();
        setisLoading(true);
        axios.post('http://localhost:5000/api/appointment', {
            idPatient: idPatient,
            idDoctor: idDoctor,
            idSituation: idSituation,
            dateApps: dateApps,
            description: description
        }, {
            headers: { 'Authorization': 'Bearer ' + localStorage.getItem('user-login') }
        }).then(answer => {
            if (answer.status === 201) {
                setPatient(0)
                setDoctor(0);
                setSituation(0);
                setDate(new Date());
                setDescription('');
                setisLoading(false);
                console.log('Os states foram redefinidos.');
                listApps();
            };
        }).catch(error => console.log(error), setisLoading(false));
    }

    function deleteApps(appointment) {
        axios.delete('http://localhost:5000/api/appointment' + appointment.idAppointment, {
            headers: { 'Authorization': 'Bearer ' + localStorage.getItem('user-login') }
        }).then(answer => {
            if (answer.status === 204) {
                setMessage('A consulta foi excluída com sucesso.');
            }
            listApps();
        }).catch(error => console.log(error), setMessage(''))
    }

    useEffect(listApps, []);
    useEffect(listPatients, []);
    useEffect(listDoctors, []);

    return (
        <div>
            <header>
                <div className="welcoming">
                    <a>Bom dia <span>John Doe</span></a>
                </div>
                <div className="spmg">
                    <img src={logo} />
                    <a>sp medical group</a>
                </div>
            </header>
            <div className="block">
                <div className="block_box">
                    <div className="action_user">
                        <div className="action_txt">
                            <a>gerenciar usuários</a>
                        </div>
                        <div className="action_block_lines">
                            <div className="action_block_blue_line"></div>
                            <div className="action_block_orange_line"></div>
                        </div>
                        <img className="action_img" src={action_users} />
                    </div>
                    <div className="action_apps" onclick="location.href='../html/admin-apps.html'">
                        <div className="action_txt">
                            <a>gerenciar consultas</a>
                        </div>
                        <div className="action_block_lines">
                            <div className="action_block_blue_line"></div>
                            <div className="action_block_orange_line"></div>
                        </div>
                        <img className="action_img" src={action_apps} />
                    </div>
                    <div className="action_clinics">
                        <div className="action_txt">
                            <a>gerenciar clínicas</a>
                        </div>
                        <div className="action_block_lines">
                            <div className="action_block_blue_line"></div>
                            <div className="action_block_orange_line"></div>
                        </div>
                        <img className="action_img" src={action_clinics} />
                    </div>
                </div>
            </div>
        </div>
    )
}
