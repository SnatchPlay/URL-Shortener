import React, { Component } from 'react';

export class GetRoles extends Component {
    static displayName = GetRoles.name;

    constructor(props) {
        super(props);
        this.state = { roles: [], loading: true };
    }

    componentDidMount() {
        this.getroles();
    }

    static renderRolesTable(roles) {
        return (
            <table className="table table-striped" aria-labelledby="tableLabel">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Role Name</th>
                    </tr>
                </thead>
                <tbody>
                    {roles.map(role =>
                        <tr key={role.id}>
                            <td>{role.id}</td>
                            <td>{role.name}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : GetRoles.renderRolesTable(this.state.roles);

        return (
            <div>
                <h1 id="tableLabel">Weather forecast</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async getroles() {
        const response = await fetch('role');
        const data = await response.json();
        this.setState({ roles: data, loading: false });
    }
}
