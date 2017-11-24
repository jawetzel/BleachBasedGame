import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import { HubConnection } from '@aspnet/signalr-client';

class App extends Component {
    constructor(props) {
        super(props);

        this.connect1 = this.connect1.bind(this);
        this.connect2 = this.connect2.bind(this);

        this.Send1 = this.Send1.bind(this);
        this.Send2 = this.Send2.bind(this);

        this.state = {
            hubConnection1: null,
            hubConnection2: null
        };


    }

    connect1(){
        let connection = new HubConnection('http://localhost:62618/chat');

        connection.on('send', data => {
            console.log("connection 1 recieved Data");
        });

        connection.start()
            .then(() => connection.invoke('send', { Message: 'hello moto' }));

        this.setState({hubConnection1: connection});
    }
    Send1(){
        const data = `sent item`;

        this.state.hubConnection1.invoke('Send', { Message: 'hello moto' });
    }


    connect2(){
        let connection = new HubConnection('http://localhost:62618/chat');

        connection.on('send', data => {
            console.log("connection 2 recieved data");
        });

        connection.start()
            .then(() => connection.invoke('send', { Message: 'hello moto' }));

        this.setState({hubConnection2: connection});
    }
    Send2(){
        const data = `sent item`;

        this.state.hubConnection2.invoke('Send', { Message: 'hello moto' });
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
          <btn onClick={() => this.connect1()}>Connect1</btn>
          <btn onClick={() => this.Send1()}>Send1</btn>
          <btn onClick={() => this.connect2()}>Connect2</btn>
          <btn onClick={() => this.Send2()}>Send2</btn>
      </div>
    );
  }
}

export default App;
