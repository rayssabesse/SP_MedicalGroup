import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Link, useHistory } from 'react-router-dom';

import '../../assets_/css/admin-reg-apps.css';
import '../../assets_/css/global.css';
import logo from '../../assets_/both/logo.png';

export default function ManageApps() {
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
    var six_apps = list_Apps.slice(0, 6);
    let history = useHistory();

    const [open, setOpen] = React.useState(false);
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);

    function logout() {
        localStorage.removeItem('user-login');
        history.push('/login');
    }

    function listPatients() {
        axios('http://localhost:5000/api/Patient', {
            headers: { 'Authorization': 'Bearer ' + localStorage.getItem('user-login') }
        }).then((answer) => {
            if (answer.status === 200) {
                setlistPatients(answer.data)
            }
        }).catch((error) => console.log(error));
    }

    function listDoctors() {
        axios('http://localhost:5000/api/Doctor', {
            headers: { 'Authorization': 'Bearer ' + localStorage.getItem('user-login') }
        }).then((answer) => {
            if (answer.status === 200) {
                setlistDoctors(answer.data)
            }
        }).catch((error) => console.log(error));
    }

    function listApps() {
        axios('http://localhost:5000/api/Appointment', {
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
        axios.post('http://localhost:5000/api/Appointment', {
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
        // console.log(appointment)
        axios.delete('http://localhost:5000/api/Appointment/delete' + appointment.idAppointment, {
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
                <Link to="/" onClick={logout}>
                    <div className="spmg">
                        <img src={logo} />
                        <a>sp medical group</a>
                    </div>
                </Link>
            </header>

            <div className="block">
                <div className="block_box_admin">
                    <div className="new_ap">
                        <a>nova consulta</a>
                        <div className="ap_form">
                            <div className="ap_form_row">
                                <a>nome do paciente</a>
                                <select className='ap_form_input' type="text" onChange={(field) => setPatient(field.target.value)}>
                                    <option value="0" selected></option>
                                    {list_Patients.map((patient) => {
                                        return (
                                            <option key={patient.idPatient} value={patient.idPatient}>
                                                {patient.namePatient}
                                            </option>
                                        )
                                    })}
                                </select>
                            </div>
                            <div className="ap_form_row">
                                <a>nome do médico</a>
                                <select className='ap_form_input' type="text" onChange={(field) => setDoctor(field.target.value)}>
                                    <option value="0" selected ></option>
                                    {list_Doctors.map((doctor) => {
                                        return (
                                            <option key={doctor.idDoctor} value={doctor.idDoctor}>
                                                {doctor.nameDoctor}
                                            </option>
                                        )
                                    })}
                                </select>
                            </div>
                            <div className='ap_form_row_2'>
                                <div className="ap_form_row">
                                    <a>data</a>
                                    <input type="datetime-local" className="date_time" value={dateApps} onChange={(field) => setDate(field.target.value)} />
                                </div>
                                <div className="ap_form_row">
                                    <a>situação</a>
                                    <select className='ap_form_input_situation' type="text" onChange={(field) => setSituation(field.target.value)}>
                                        <option value="0" selected></option>
                                        <option value="1">Realizada</option>
                                        <option value="2">Cancelada</option>
                                        <option value="3">Agendada</option>

                                    </select>
                                </div>
                            </div>

                            <div className="ap_form_row">
                                <a>descrição</a>
                                <textarea className='ap_description' maxLength="1000"></textarea>
                            </div>
                            {isLoading === false &&
                                <button className="ap_form_save" onClick={registerApps}>salvar</button>
                            }
                            {isLoading === true &&
                                <button className="ap_form_save">carregando...</button>
                            }

                        </div>
                    </div>
                    <div className="block_box_line"></div>
                    <div className="search_ap">
                        <a>consultas</a>
                        <form>
                            <input type="text" placeholder="Pesquisar consulta por paciente" />
                        </form>
                        <span>próximas consultas</span>
                        <div className='next_ap_row'>
                            {six_apps.map((itemApps) => {
                                return (
                                    <div>
                                        <div className="next_ap_block_admin" id={itemApps.idAppointment}>
                                            <div className="next_ap_block_txt">
                                                <div className="next_ap_block_txt_row">
                                                    <a>nome:</a>
                                                    <span>{itemApps.idPatientNavigation.namePatient}</span>
                                                </div>
                                                <div className="next_ap_block_txt_row">
                                                    <a>horário:</a>
                                                    <span>{itemApps.idDoctorNavigation.nameDoctor}</span>
                                                </div>


                                            </div>
                                            <div className="next_ap_cancel">
                                                <button className="next_ap_block_cancel" onClick={() => deleteApps(itemApps)}>cancelar</button>
                                            </div>
                                        </div>
                                    </div>
                                )
                            })}
                        </div>


                    </div>
                </div>
            </div>
        </div>
    )
}