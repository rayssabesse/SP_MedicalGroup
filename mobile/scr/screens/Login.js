import React, { Component } from 'react';
import {
  StyleSheet,
  Text,
  TouchableOpacity,
  View,
  Image,
  ImageBackground,
  TextInput,
} from 'react-native';

import AsyncStorage from '@react-native-async-storage/async-storage';

import api from '../services/api';

export default class Login extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email: 'henrique@gmail.com',
      password: 'henrique123',
    };
  }
  makeLogin = async () => {
    console.warn(this.state.email + ' ' + this.state.password);
    const resposta = await api.post('/login/login', {
      email: this.state.email, //ADM@ADM.COM
      password: this.state.password, //password123
    });
    if (resposta.status == 200) {
      console.warn
      const token = resposta.data.token;
      console.warn(token);
      await AsyncStorage.setItem('userToken', token);
      this.props.navigation.navigate('Appointment');
    }
  };

  render() {
    return (
      <ImageBackground
        source={require('../assets/img/login.png')}
        style={StyleSheet.absoluteFillObject}>
        <View style={styles.overlay} />
        <View style={styles.main}>
          <Image
            source={require('../assets/img/diagnosis.png')}
            style={styles.mainImgLogin}
          />
          <TextInput
            style={styles.inputLogin}
            placeholder="Nome de usuario"
            placeholderTextColor="#999"
            keyboardType="email-address"
            onChangeText={email => this.setState({ email })}
          />

          <TextInput
            style={styles.inputLogin}
            placeholder="password"
            placeholderTextColor="#999"
            keyboardType="default"
            secureTextEntry={true}
            onChangeText={password => this.setState({ password })}
          />

          <TouchableOpacity
            style={styles.btnLogin}
            onPress={this.makeLogin}>
            <Text style={styles.btnLoginText}>Login</Text>
          </TouchableOpacity>
        </View>
      </ImageBackground>
    );
  }
}

const styles = StyleSheet.create({

  overlay: {
    ...StyleSheet.absoluteFillObject,
    backgroundColor: 'rgba(196,197,248,0.70)',
  },

  main: {
    justifyContent: 'center',
    alignItems: 'center',
    width: '100%',
    height: '100%',
  },

  mainImgLogin: {
    margin: 60,
    marginTop: 0,
  },

  inputLogin: {
    width: 280,
    marginBottom: 40,
    fontSize: 18,
    color: '#000',
    borderBottomColor: '#000',
    borderBottomWidth: 3,
  },

  btnLoginText: {
    fontSize: 20,
    fontFamily: 'Open Sans Light',
    color: '#000',
    letterSpacing: 3,
    textTransform: 'uppercase',
  },

  btnLogin: {
    alignItems: 'center',
    justifyContent: 'center',
    height: 60,
    width: 200,
    backgroundColor: 'rgba(211,242,247,0.70)',
    borderColor: 'rgba(211,242,247,0.70)',
    borderWidth: 1,
    borderRadius: 4,
    shadowOffset: { height: 1, width: 1 },
  },
});