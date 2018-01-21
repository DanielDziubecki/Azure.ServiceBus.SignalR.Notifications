import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import { hubConnection } from 'signalr-no-jquery';

class App extends Component {
  componentWillMount() {
    const connection = hubConnection('http://localhost:51130');
    const hubProxy = connection.createHubProxy('NotificationHub');
  
    hubProxy.on('SendMessage', function (message) {
      debugger
      alert(message);
  });
  debugger
  connection.start()
  .done(function(){ console.log('Now connected, connection ID=' + connection.id); console.log(connection) })
  .fail(function(){ console.log('Could not connect'); });
  }
  render() {
    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">Welcome to React</h1>
        </header>
        <p className="App-intro">
          To get started, edit <code>src/App.js</code> and save to reload.
        </p>
      </div>
    );
  }
}

export default App;
