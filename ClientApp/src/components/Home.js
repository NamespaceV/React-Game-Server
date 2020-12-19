import React, { Component } from 'react';

export class Home extends Component {
    static displayName = Home.name;

    async loadData() {
        const response = await fetch('ticktacktoe/list');
        const data = await response.json();
        this.setState({ data: data, loading: false });
    }

    async createGame() {
        this.setState({ data: [], loading: true });
        const response = await fetch('ticktacktoe/create');
        const data = await response.json();
        this.setState({ data: data, loading: false });
    }

    constructor(props) {
        super(props);
        this.state = { data: [], loading: true };
    }

    componentDidMount() {
        this.loadData();
    }

    static renderTable(data) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Game GUID</th>
                    </tr>
                </thead>
                <tbody>
                    {data.map(gameId =>
                        <tr key={gameId}>
                            <td><a href="/" class="btn btn-outline-primary" >{gameId}</a></td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    renderContents() {
        if (this.state.loading) {
            return <p><em>Loading...</em></p>;
        }
        return <>
            <a onClick={this.createGame.bind(this)} class="btn btn-primary">Create New Game</a>
            {Home.renderTable(this.state.data)}
        </>;
    }

    render() {
        let contents = this.renderContents();

        return (
            <div>
                <h1 id="tabelLabel" >Tick Tack Toe</h1>
                <p>Choose game to join.</p>
                {contents}
            </div>
        );
        
    }
}
