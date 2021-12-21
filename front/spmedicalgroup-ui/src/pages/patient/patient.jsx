import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Link, useHistory } from 'react-router-dom';

import '../../assets_/css/patient.css';
import '../../assets_/css/global.css';
import logo from '../../assets_/both/logo.png';
import cardfront from '../../assets_/site/card_front.png';
import patientscreen from '../../assets_/site/patient.png';

export default function PatientApps() {
    const [list_Apps, setlistApps] = useState([]);
    let history = useHistory();

    function logout() {
        localStorage.removeItem('user-login');
        history.push('/login');
    }

    function searchMine() {
        axios('http://localhost:5000/api/patient/appointments', {
            headers: { 'Authorization': 'Bearer ' + localStorage.getItem('user-login') }
        }).then(answer => {
            if (answer.status === 200) {
                setlistApps(answer.data)
            };
        }).catch(error => console.log(error));
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
                <div className="block_box">
                    <div className="my_profile">
                        <p1>meu perfil</p1>
                        <div className="my_profile_card">
                            <div className="my_profile_block_info_back">
                                <div className="my_profile_block_info_back_row">
                                    <a>nome:</a>
                                    <span></span>
                                </div>
                                <div className="my_profile_block_info_back_row">
                                    <a>data de nascimento:</a>
                                    <span></span>
                                </div>
                                <div className="my_profile_block_info_back_row">
                                    <a>RG:</a>
                                    <span></span>
                                </div>
                                <div className="my_profile_block_info_back_row">
                                    <a>CPF:</a>
                                    <span></span>
                                </div>
                                <div className="my_profile_block_info_back_row">
                                    <a>endereço:</a>
                                    <span></span>
                                </div>
                                <div className="my_profile_block_info_back_row">
                                    <a>telefone:</a>
                                    <span></span>
                                </div>
                            </div>
                        </div>
                        <img src={patientscreen} className="my_profile_patient_img " />
                    </div>
                    <div className="block_box_line"></div>
                    <div className="my_apps">
                        <p1>minhas consultas</p1>
                        {list_Apps.map((appointment) => {
                            return (
                                <div>
                                    <div className="next_ap_block">
                                        <div className="next_ap_block_info">
                                            <div className="next_ap_block_info_txt">
                                                <a>nome do médico:</a>
                                                <span>{appointment.idDoctorNavigation.nameDoctor}</span>
                                                <a>especialidade:</a>
                                                <span>{appointment.idDoctorNavigation.idDoctorJobNavigation.nameDoctorJob}</span>
                                                <a>data:</a>
                                                <span>{Intl.DateTimeFormat("pt-br", {year: 'numeric', month: '2-digit', day: 'numeric'}).format(new Date(appointment.dateAppointment))}</span>
                                                <a>situação:</a>
                                                <span>{appointment.idSituationNavigation.situation}</span>
                                            </div>
                                        </div>
                                        <div className="next_ap_block_address">
                                            <a href="">endereço</a>
                                        </div>
                                        <div className="next_ap_block_lines">
                                            <div className="next_ap_block_blue_line"></div>
                                            <div className="next_ap_block_orange_line"></div>
                                        </div>
                                    </div>
                                </div>
                            )
                        })}



                    </div>

                </div>
            </div>
        </div>
    )
}

