import axios from 'axios';
import jwtDecode from 'jwt-decode';
import AsyncStorage from '@react-native-async-storage/async-storage';
import React, { Component } from 'react';
import {
  SafeAreaView,
  ScrollView,
  StatusBar,
  Image,
  StyleSheet,
  Text,
  FlatList,
  View,
} from 'react-native';

import api from '../services/api';
//Continuar
class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      listAppointment: [],
      userNow: ''
    };
  };

  searchApps = async () => {
    const userToken = await AsyncStorage.getItem("userToken")
    console.warn('token do usuário')
    console.warn(userToken)

    const answer = await api.get('/appointments/mine', {
      headers: {
        Authorization: 'Bearer ' + userToken
      }
    });
    console.warn('answer')
    console.warn(answer)
    const dadosApi = answer.data;

    this.setState({
      listAppointment: dadosApi,
      userNow: jwtDecode(userToken).role
    });
  }

  componentDidMount() {
    this.searchApps();
  }

  render() {
    return (        
      this.state.userNow === '3' && (
        <View>
          <Text>Paciente</Text>
        </View>
      ),

      <View style={styles.main}>
      
        <View style={styles.mainHeader}>
          <View style={styles.mainHeaderRow}>
            <Image
              source={require('../assets/img/ap.png')}
              style={styles.mainHeaderImg}
            />
            <Text style={styles.mainHeaderText}>{'Consultas'.toUpperCase()}</Text>
          </View>
          <View style={styles.mainHeaderLine} />


        </View>


        <View style={styles.mainBody}>
          <FlatList
            contentContainerStyle={styles.mainBodyContent}
            data={this.state.listAppointment}
            keyExtractor={item => item.idAppointment}
            renderItem={this.renderItem}
          />

        </View>
      </View>

    );
  }


  renderItem = ({ item }) => (
   
      
    this.state.userNow === '3' ? (


      <View style={styles.cardAppointment}>


        <View style={styles.mainInfoCard}>

          <View style={styles.patientInfo}>
            <Text style={styles.key}>Paciente: </Text>
            <Text style={styles.value}>​{(item.idPatientNavigation.namePatient)}</Text>
          </View>

          <View style={styles.dataInfo}>
            <Text style={styles.key}>​Data da consulta: <Text style={styles.value}>{Intl.DateTimeFormat("pt-BR", {
              year: "numeric", month: "short", day: "numeric", hour: "numeric", minute: "numeric"
            }).format(new Date(item.dateAppointment))}</Text></Text>

          </View>


          <View style={styles.doctorInfo}>
            <Text style={styles.key}>Medico: <Text style={styles.value}>{(item.idDoctorNavigation.nameDoctor)}</Text> </Text>

          </View>

          <View style={styles.doctorjobInfo}>
            <Text style={styles.key}>Especialidade:  <Text style={styles.value}>{(item.idDoctorNavigation.idDoctorJobNavigation.nameDoctorJob)}</Text></Text>

          </View>

          <View style={styles.situationInfo}>
            <Text style={styles.key}>Situação: <Text style={styles.value}>{(item.idSituationNavigation.typeSituation)}</Text></Text>
           
          </View>

    

        </View>
      </View>
    )

      : (

        <View style={styles.cardAppointment}>


          <View style={styles.mainInfoCard}>


            <View style={styles.doctorInfo}>
              <Text style={styles.key}>Medico: <Text style={styles.value}>{(item.idDoctorNavigation.nameDoctor)}</Text> </Text>

            </View>

            <View style={styles.patientInfo}>
              <Text style={styles.key}>Paciente: </Text>
              <Text style={styles.value}>​{(item.idPatientNavigation.namePatient)}</Text>
            </View>

            <View style={styles.dataInfo}>
              <Text style={styles.key}>​Data da consulta: <Text style={styles.value}>{Intl.DateTimeFormat("pt-BR", {
                year: "numeric", month: "short", day: "numeric", hour: "numeric", minute: "numeric"
              }).format(new Date(item.dateAppointment))}</Text></Text>

            </View>


            <View style={styles.situationInfo}>
              <Text style={styles.key}>Situação: <Text style={styles.value}>{(item.idSituationNavigation.typeSituation)}</Text></Text>
              
            </View>

        

          </View>
        </View>
      )



  )
}


const styles = StyleSheet.create({

  main: {
    flex: 1,
    backgroundColor: '#CFDCFF',
  },

  mainHeader: {
    flex: 0.3,
    justifyContent: 'center',
    alignItems: 'center'
  },

  mainHeaderRow: {
    flexDirection: 'row',
  },

  mainHeaderText: {
    fontSize: 16,
    letterSpacing: 5,
    color: '#000',
  },

  mainHeaderLine: {
    width: 220,
    paddingTop: 10,
    borderBottomColor: '#000',
    borderBottomWidth: 2,
  },

  nomeConsulta: {
    marginTop: 35,
  },

  mainBody: {
    flex: 1,
  },
 
  mainBodyContent: {
    width: '100%',
    paddingTop: 10,
    paddingBottom: 10,
    marginBottom: 10,
    alignItems: "center"
  },

  cardAppointment: {
    width: 300,
    marginTop: 10,
    marginBottom: 10,
    paddingTop: 10,
    height: 150,
    backgroundColor: "#ACC6E7",
    flexDirection: "row",
    borderRadius: 25,
    paddingLeft: 20,
    paddingBottom: 20,
  },

  mainInfoCard: {
    flex: 2
  },

  addInfoCard: {
    flex: 1,
    alignItems: "center",
    height: "90%",
    justifyContent: "center"
  },

  key: {
    color: "#000",
    fontSize: 14,
  },

  value: {
    color: "#000",
    fontSize: 14,
  },

  dataInfo: {
    marginBottom: 8,
    justifyContent: "center",
  },

  patientInfo: {
    flexDirection: "row",
    marginBottom: 8,
    alignItems: "center"
  },

  doctorInfo: {
    flexDirection: "row",
    marginBottom: 10,
    alignItems: "center"
  },

  doctorjobInfo: {
    flexDirection: "row",
    marginBottom: 10,
    alignItems: "center"
  },
});

export default App;
