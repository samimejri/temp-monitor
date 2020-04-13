import 'react-circular-progressbar/dist/styles.css';
import React, { Component } from 'react';
import { LogLevel, HubConnectionBuilder } from '@microsoft/signalr';
import { TempMonitor } from './TempMonitor.js';
import { Collapsible } from './Collapsible.js';

export class TempDashboard extends Component {
  constructor(props) {
    super(props);
    this.state = { cpuTemp: { temp: 0, cores: [] }, gpuTemp: "0" };
  }

  render() {

    const coresUI =
      this.state.cpuTemp.cores.map((core, index) => (
        <div key={index} className="col col-6 col-sm-6 col-md-6 col-lg-3 col-xl-3 p-2">
          <TempMonitor Title={index + 1} Temperature={core.temp} SmallText="true" />
        </div>
      )
      );

    return (

      <div className="row" >
        <div className="col col-12 col-sm-12 col-md-6 col-lg-6 col-xl-6 p-5">
          <div>
            <TempMonitor Title="CPU" Temperature={this.state.cpuTemp.temp} />
          </div>
          <Collapsible ShowTitle="Show Cores Temprature" HideTitle="Hide Cores Temprature">
            <div className="row">
              {coresUI}
            </div>
          </Collapsible>
        </div>

        <div className="col col-12 col-sm-12 col-md-6 col-lg-6 col-xl-6 p-5">
          <TempMonitor Title="GPU" Temperature={this.state.gpuTemp} />
        </div>
      </div >
    );
  }

  componentDidMount() {
    const hubConnection = new HubConnectionBuilder()
      .withUrl("http://localhost:5000/tempHub")
      .configureLogging(LogLevel.Information)
      .build();

    hubConnection
      .start()
      .then(() => console.log('Connection started!'))
      .catch(err => console.log('Error while establishing connection :('));

    hubConnection.on('TempMessage', (receivedMessage) => {
      this.setState({ cpuTemp: receivedMessage.cpuTemp, gpuTemp: receivedMessage.gpuTemp })
    });
  }
}
