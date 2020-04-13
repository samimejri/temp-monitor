import React, { Component } from 'react';
import { CircularProgressbarWithChildren, buildStyles } from 'react-circular-progressbar';
import 'react-circular-progressbar/dist/styles.css';

export class TempMonitor extends Component {
    render() {
        let primary = this.determineMonitorPrimaryColor(this.props.Temperature);
        let secondary = this.determineMonitorSecondaryColor(this.props.Temperature);
        var text;

        if (this.props.SmallText) {
            text =
                <div>
                    <h6 style={{ color: primary }}><b>{this.props.Title}</b></h6>
                    <h6 style={{ color: primary }}>{this.props.Temperature} °C</h6>
                </div>
        }
        else {
            text =
                <div>
                    <h3 style={{ color: primary }}><b>{this.props.Title}</b></h3>
                    <h3 style={{ color: primary }}>{this.props.Temperature} °C</h3>
                </div>
        }

        return (
            <div>
                <CircularProgressbarWithChildren value={this.props.Temperature} circleRatio={0.6}
                    styles={buildStyles({
                        rotation: 1 / 2 + 1 / 5,
                        strokeLinecap: "butt",
                        pathColor: primary,
                        trailColor: secondary,
                        textColor: primary
                    })}>
                    {text}
                </CircularProgressbarWithChildren>
            </div>
        );
    }

    determineMonitorPrimaryColor(tempValue) {
        let primary = "dodgerblue";

        if (tempValue > 50) {
            primary = "darkorange";
        }

        if (tempValue > 85) {
            primary = "red";
        }

        return primary;
    }

    determineMonitorSecondaryColor(tempValue) {
        let secondary = "lightskyblue";

        if (tempValue > 50) {
            secondary = "palegoldenrod";
        }

        if (tempValue > 85) {
            secondary = "lightsalmon";
        }

        return secondary;
    }
}