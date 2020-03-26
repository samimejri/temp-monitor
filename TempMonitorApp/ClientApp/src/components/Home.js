import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {

    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderForecastsTable(this.state.forecasts);

    return (
      
      <div>
      </div>
    );
  }

  async populateTempData() {
    const response = await fetch('temps');
    const data = await response.json();
    this.setState({ temps: data, loading: false });
  }
}
