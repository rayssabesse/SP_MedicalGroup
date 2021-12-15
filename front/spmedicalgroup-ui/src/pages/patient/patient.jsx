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
        axios('http://localhost:5000/api/appointment/patient', {
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
                <div className="welcoming" >
                    <a>Bom dia <span>John Doe</span></a>
                </div>
                <div className="spmg" >
                    <img src={logo} />
                    <a >sp medical group</a>
                </div>
            </header>
            <div className="block">
                <div className="block_box">
                    <div className="my_profile">
                        <p1>meu perfil</p1>
                        <div className="my_profile_card">
                            <div className="my_profile_card_front">
                                <img src={cardfront} />
                            </div>
                            <div className="my_profile_card_back">
                                <div className="my_profile_block_info_back">
                                    <a>nome:</a>
                                    <a>data de nascimento:</a>
                                    <a>RG:</a>
                                    <a>CPF:</a>
                                    <a>endereço:</a>
                                    <a>telefone:</a>
                                </div>
                                <div className="my_profile_block_lines">
                                    <div className="my_profile_block_blue_line"></div>
                                    <div className="my_profile_block_orange_line"></div>
                                </div>
                            </div>
                            <script type="text/javascript" src="../js/patient.js"></script>
                        </div>
                        <img src={patientscreen} className="my_profile_patient_img " />
                    </div>
                    <div className="block_box_line"></div>
                    <div className="my_apps">
                        <p1>minhas consultas</p1>
                        <div className="next_ap_block">
                            <div className="next_ap_block_info">
                                <div className="next_ap_block_info_txt">
                                    <a>nome do médico:</a>
                                    <a>especialidade:</a>
                                    <a>data:</a>
                                    <a>situação:</a>
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
                        <div className="next_ap_block">
                            <div className="next_ap_block_info">
                                <div className="next_ap_block_info_txt">
                                    <a>nome do médico:</a>
                                    <a>especialidade:</a>
                                    <a>data:</a>
                                    <a>situação:</a>
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
                        <div className="next_ap_block">
                            <div className="next_ap_block_info">
                                <div className="next_ap_block_info_txt">
                                    <a>nome do médico:</a>
                                    <a>especialidade:</a>
                                    <a>data:</a>
                                    <a>situação:</a>
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

                </div>
            </div>
        </div>
    )
}

