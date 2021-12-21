import 'react-native-gesture-handler';

import React, { Component } from 'react';

import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';

import { StatusBar, StyleSheet } from 'react-native';

import Consulta from './scr/screens/Appointments';
import Login from './scr/screens/Login';
// import CameraPerfil from './src/screens/camera';

const AuthStack = createStackNavigator();

class App extends Component {
  render() {
    return (
      <NavigationContainer>
        <StatusBar
          hidden={true}
        />
        <AuthStack.Navigator
          screenOptions={{
            headerShown: false,
          }}>
          <AuthStack.Screen name="Login" component={Login} />
          <AuthStack.Screen name="Consulta" component={Consulta} />
        </AuthStack.Navigator>
      </NavigationContainer>
    );
  }
}

export default App;