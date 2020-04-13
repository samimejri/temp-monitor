import React from 'react';

export class Collapsible extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            Open: false,
            Title: this.props.ShowTitle
        }
        this.togglePanel = this.togglePanel.bind(this);
    }

    togglePanel(e) {
        var title = this.state.Open ? this.props.ShowTitle : this.props.HideTitle;
        this.setState({ Open: !this.state.Open, Title: title })
    }

    render() {
        return (
            <div>
                <div onClick={(e) => this.togglePanel(e)} className="collapse-header btn btn-link">
                    {this.state.Title}
                </div>
                {
                    this.state.Open ? (
                        <div className="collapse-content">
                            {this.props.children}
                        </div>
                    ) : null
                }
            </div >
        );
    }
}

