import React, { useState, useEffect, Component } from 'react';
import axios from 'axios';
import { Link, useHistory } from 'react-router-dom';

import '../../assets_/css/doctor.css'
import '../../assets_/css/global.css'
import logo from '../../assets_/both/logo.png';
import doctorscreen from '../../assets_/site/doctor.png';

export default function DoctorApps() {
    const [list_Apps, setlistApps] = useState([]);
    const [list_Patients, setlistPatients] = useState([]);
    const [idPatient, setPatient] = useState(0);
    const [description, setDescription] = useState('');
    const [id_Now, setIdNow] = useState(0);

    let history = useHistory();

    const [open, setOpen] = React.useState(false);
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);


    function dateTime() {
        const DateTime = () => {

            var [date, setDate] = useState(new Date());

            useEffect(() => {
                var timer = setInterval(() => setDate(new Date()), 1000)
                return function cleanup() {
                    clearInterval(timer)
                }
            });
        }
    }

    function openModal(id) {
        console.log(id);
        setIdNow(id);
        handleOpen();
    }

    function logout() {
        localStorage.removeItem('user-login');
        history.push('/login');
    }

    function searchMine() {
        axios('http://localhost:5000/api/doctor', {
            headers: { 'Authorization': 'Bearer ' + localStorage.getItem('user-login') }
        }).then(answer => {
            if (answer.status === 200) {
                setlistApps(answer.data)
            };
        }).catch(error => console.log(error));
    }

    function addDescription(id) {
        console.log(id)
        axios.patch('ttp://localhost:5000/api/doctor/description' + id, {
            Description: description
        }, {
            headers: { 'Authorization': 'Bearer ' + localStorage.getItem('user-login') }
        }).then(answer => {
            if (answer.status === 200) {
                console.log('A descrição foi alterada.');
                setDescription(answer.data);

            }
            searchMine();
        }).catch(error => console.log(error))
    }

    useEffect(searchMine, []);

    return (
        <div>
            <header>
                <div className="welcoming">
                    <a>Bom dia <span>Dr. John Doe</span></a>
                </div>
                <Link to="/" onClick={logout}>
                    <div className="spmg">
                        <img src={logo} />
                        <a>sp medical group</a>
                    </div>
                </Link>
            </header>
            <div className="block">
                <div className="block_box_doctor">
                    <div className="patients_list">
                        <p1>lista de pacientes</p1>
                        <div className="patients_list_box">
                            {list_Apps.map((appointment) => {
                                return (
                                    <div key={appointment.idAppointment} id={appointment.idAppointment}>
                                        <div className="patients_list_block">
                                            <div className="patients_list_block_info">
                                                <div className="patients_list_block_info_txt">
                                                    <a>nome:</a>
                                                    {/* <span>{appointment.idPatientNavigation.namePatient}</span> */}
                                                    <a>horário:</a>
                                                    <textarea className='textarea_doctor' maxLength="1000" onChange={(field) => setDescription(field.target.value)}></textarea>
                                                </div>
                                                <button className="description_btn" disabled={description === '' ? 'none' : ''} onClick={() => addDescription(id_Now)}>salvar</button>
                                            </div>
                                            <div className="patients_list_block_lines">
                                                <div className="patients_list_block_blue_line"></div>
                                                <div className="patients_list_block_orange_line"></div>
                                            </div>
                                        </div>
                                    </div>
                                )
                            })}




                        </div>

                    </div>
                    <div className="block_box_line"></div>
                    <img src={doctorscreen} className='third_column_block_img' />
                </div>
            </div>
        </div>

    )
}