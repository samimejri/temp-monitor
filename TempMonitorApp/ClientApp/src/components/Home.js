import React, { Component } from 'react';
import * as signalR from '@microsoft/signalr';
//import { LogLevel, HubConnection, TransportType,  Logger} from '@microsoft/signalr';

export class Home extends Component {
  static displayName = Home.name;

  constructor(props) {
    super(props);
    this.state = { temps: {} };
    this.populateTempData = this.populateTempData.bind(this);
    this.refreshState = this.refreshState.bind(this);
  }

  async populateTempData() {
    const response = await fetch('temp');
    const data = await response.json();
    this.setState({ cpu: data[0].temp, gpu: data[1].temp });
  }

  render() {
    return (
      <div>
        <h1>CPU temp: {this.state.cpu}</h1>
        <h1>GPU temp: {this.state.gpu}</h1>
      </div>
    );
  }

  refreshState() {
    this.populateTempData();
  }

  componentDidMount() {
    const hubConnection = new signalR.HubConnectionBuilder()
      .withUrl("/tempHub")
      .configureLogging(signalR.LogLevel.Information)
      .build();

    hubConnection
      .start()
      .then(() => console.log('Connection started! Yaaaaay'))
      .catch(err => console.log('Error while establishing connection :('));

    hubConnection.on('ReceiveMessage', (receivedMessage) => {
      console.log(receivedMessage);
    });

    this.refreshState();
  }
}
