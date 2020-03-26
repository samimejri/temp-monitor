import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render() {

    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderForecastsTable(this.state.forecasts);

    return (

      <div>
      </div>
    );
  }

  componentDidMount() {
    this.interval = setInterval(() => this.setState({ time: Date.now() }), 1000);
  }

  componentWillUnmount() {
    clearInterval(this.interval);
  }
  
  async populateTempData() {
    const response = await fetch('temps');
    const data = await response.json();
    this.setState({ temps: data, loading: false });
  }
}
