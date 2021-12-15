import { Link, Route } from 'react-router-dom';

import '../../assets_/css/homepage.css';
import '../../assets_/css/global.css';
import logo from '../../assets_/both/logo.png';
import home from '../../assets_/site/home.png';
import about_us from '../../assets_/site/about_us.png';
import blood_test from '../../assets_/site/blood_test.png';
import chekcup from '../../assets_/site/checkup.png';
import dentist from '../../assets_/site/dentist.png';
import hospitalization from '../../assets_/site/hospitalization.png';
import pneumology from '../../assets_/site/pneumology.png';
import surgery from '../../assets_/site/surgery.png';
import vaccination from '../../assets_/site/vaccination.png';
import physiotherapy from '../../assets_/site/physiotherapy.png';
import contact from '../../assets_/site/contact.png';

import './App.css';

function App() {
  return (
    <div>
      <header>
        <Link to="/">
          <div className="spmg">
            <img src={logo} />
            <span>sp medical group</span>
          </div>
        </Link>
        <div className="menu">
          <span href="#home">home</span>
          <span href="#about_us">sobre nós</span>
          <span href="#services">serviços</span>
          <span href="#contact">contato</span>
          <Link to="/login"><span className="login_btn">entrar</span></Link>
        </div>
      </header>
      <div id="home" className="home">
        <div className="home_box">
          <div className="home_box_txt">
            <a>Te ajudando a tomar conta da sua saúde</a>
            <div className="home_box_txt2">
              <span>Medicina de precisão feita especialmente para você</span>
            </div>
          </div>
        </div>
        <img src={home} />
      </div>
      <div id="about_us" className="about_us">
        <img src={about_us} />
        <div className="about_us_txt">
          <a>sobre nós</a>
          <span>
            Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the
            industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and
            scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap
            into electronic typesetting, remaining essentially unchanged.
          </span>
        </div>
      </div>
      <div id="services" className="services">
        <a>nossos serviços</a>
        <div className="services_column">
          <div className="serv_block">
            <div className="serv_box">
              <img src={blood_test} />
            </div>
            <div className="serv_txt">
              <a>exames laboratoriais</a>
            </div>
          </div>
          <div className="ser_block">
            <div className="serv_box">
              <img src={chekcup} />
            </div>
            <div className="serv_txt">
              <a>checkup</a>
            </div>
          </div>
          <div className="serv_block">
            <div className="serv_box">
              <img src={dentist} />
            </div>
            <div className="serv_txt">
              <a>odontologia</a>
            </div>
          </div>
          <div className="serv_block">
            <div className="serv_box">
              <img src={hospitalization} />
            </div>
            <div className="serv_txt">
              <a>internação</a>
            </div>
          </div>
        </div>
        <div className="services_column">
          <div className="serv_block">
            <div className="serv_box">
              <img src={pneumology} />
            </div>
            <div className="serv_txt">
              <a>espirometria</a>
            </div>
          </div>
          <div className="ser_block">
            <div className="serv_box">
              <img src={surgery} />
            </div>
            <div className="serv_txt">
              <a>cirurgias</a>
            </div>
          </div>
          <div className="serv_block">
            <div className="serv_box">
              <img src={vaccination} />
            </div>
            <div className="serv_txt">
              <a>vacinação</a>
            </div>
          </div>
          <div className="serv_block">
            <div className="serv_box">
              <img src={physiotherapy} />
            </div>
            <div className="serv_txt">
              <a>fisioterapia</a>
            </div>
          </div>
        </div>
      </div>
      <div id="contact" className="contact">
        <img src={contact} />
        <div className="cont_info">
          <a>contato</a>

          <div className="cont_box">
            <a>Clínica SENAI de Informática</a>
            <div className="cont_box_info_box">
              <div className="cont_box_info_box_txt_box">
                <a>R. Alameda Barão de Limeira, 537 - Santa Cecília, São Paulo - SP, 01202-001</a>
              </div>
              <div className="cont_box_info_box_txt_box">
                <a>(11) 3273-5000<br />informatica@sp.senai.br</a>
              </div>
            </div>
          </div>

          <div className="cont_box">
            <a>Clínica SENAI Roberto Simonsen</a>
            <div className="cont_box_info_box">
              <div className="cont_box_info_box_txt_box">
                <a>R. Monsenhor Andrade, 298 - Brás, São Paulo - SP, 03008-000</a>
              </div>
              <div className="cont_box_info_box_txt_box">
                <a>(11) 3322-5000<br />senaibras@sp.senai.br</a>
              </div>
            </div>
          </div>
          <div className="cont_box">
            <a>Clínica SESI Ipiranga</a>
            <div className="cont_box_info_box">
              <div className="cont_box_info_box_txt_box">
                <a>R. Bom Pastor, 654 - Ipiranga, São Paulo - SP, 04203-050</a>
              </div>
              <div className="cont_box_info_box_txt_box">
                <a>(11) 2065-0150<br />(11) 2065-0141</a>
              </div>
            </div>
          </div>
        </div>
      </div>
      <footer>
        <a>sp medical group</a>
        <span>Copyright 2021 © Todos os direitos reservados.</span>
      </footer>
    </div >
  );
}

export default App;
