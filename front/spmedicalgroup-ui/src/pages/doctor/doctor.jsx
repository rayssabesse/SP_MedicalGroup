import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Link, useHistory } from 'react-router-dom';

import '../../assets_/css/doctor.css'
import '../../assets_/css/global.css'
import logo from '../../assets_/both/logo.png';
import doctorscreen from '../../assets_/site/doctor.png';

export default function DoctorApps() {
    const [list_Apps, setlistApps] = useState([]);
    const [description, setDescription] = useState('');
    const [id_Now, setIdNow] = useState(0);
    let history = useHistory();

    const [open, setOpen] = React.useState(false);
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);

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
                <div className="spmg">
                    <img src={logo} />
                    <a>sp medical group</a>
                </div>
            </header>
            <div className="block">
                <div className="block_box">
                    <div className="patients_list">
                        <p1>lista de pacientes</p1>
                        <div className="patients_list_block">
                            <div className="patients_list_block_info">
                                <div className="patients_list_block_info_txt">
                                    <a>nome:</a>
                                    <a>horário:</a>
                                </div>
                                <button className="description_btn">descrição</button>
                            </div>
                            <div className="patients_list_block_lines">
                                <div className="patients_list_block_blue_line"></div>
                                <div className="patients_list_block_orange_line"></div>
                            </div>
                        </div>
                        <div className="patients_list_block">
                            <div className="patients_list_block_info">
                                <div className="patients_list_block_info_txt">
                                    <a>nome:</a>
                                    <a>horário:</a>
                                </div>
                                <button className="description_btn">descrição</button>
                            </div>
                            <div className="patients_list_block_lines">
                                <div className="patients_list_block_blue_line"></div>
                                <div className="patients_list_block_orange_line"></div>
                            </div>
                        </div>
                        <div className="patients_list_block">
                            <div className="patients_list_block_info">
                                <div className="patients_list_block_info_txt">
                                    <a>nome:</a>
                                    <a>horário:</a>
                                </div>
                                <button className="description_btn">descrição</button>
                            </div>
                            <div className="patients_list_block_lines">
                                <div className="patients_list_block_blue_line"></div>
                                <div className="patients_list_block_orange_line"></div>
                            </div>
                        </div>
                        <div className="patients_list_block">
                            <div className="patients_list_block_info">
                                <div className="patients_list_block_info_txt">
                                    <a>nome:</a>
                                    <a>horário:</a>
                                </div>
                                <button className="description_btn">descrição</button>
                            </div>
                            <div className="patients_list_block_lines">
                                <div className="patients_list_block_blue_line"></div>
                                <div className="patients_list_block_orange_line"></div>
                            </div>
                        </div>
                        <div className="patients_list_block">
                            <div className="patients_list_block_info">
                                <div className="patients_list_block_info_txt">
                                    <a>nome:</a>
                                    <a>horário:</a>
                                </div>
                                <button className="description_btn">descrição</button>
                            </div>
                            <div className="patients_list_block_lines">
                                <div className="patients_list_block_blue_line"></div>
                                <div className="patients_list_block_orange_line"></div>
                            </div>
                        </div>
                    </div>
                    <div className="block_box_line"></div>
                    <div className="next_ap">
                        <p1>próxima consulta</p1>
                        <div className="next_ap_block">
                            <div className="next_ap_block_info">
                                <div className="next_ap_block_info_txt">
                                    <a>nome:</a>
                                    <a>horário:</a>
                                </div>
                                <div className="next_ap_description">
                                    <p1></p1>
                                </div>
                                <div className="next_ap_block_info_data">
                                    <a>dados complementares do paciente</a>
                                    <span>nome:</span>
                                    <span>idade:</span>
                                    <span>endereço</span>
                                    <span>telefone:</span>
                                    <span>RG:</span>
                                    <span>CPF:</span>
                                </div>

                            </div>
                            <div className="next_ap_block_lines">
                                <div className="next_ap_block_blue_line"></div>
                                <div className="next_ap_block_orange_line"></div>
                            </div>
                        </div>
                    </div>
                    <div className="third_column_block">
                        <div className="clock_block">
                            <a>horário atual</a>
                            <div id="clock_box"></div>
                            <script type="text/javascript" src="../js/doctor.js"></script>
                        </div>
                        <img src={doctorscreen}/>
                    </div>
                </div>
            </div>
        </div>
    )
}