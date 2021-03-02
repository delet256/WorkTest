import React, { Component } from 'react';
import { Row } from 'reactstrap';
import { fetch } from 'whatwg-fetch'
import { EmployeeCard } from './EmployeeCard';

const GET_EMPLOYEES_URL = "api/employee/Getemployees";
const GET_DEP_INFO_URL = "/api/department/getdepartmentInfo"

export class Home extends Component {
    constructor(props) {
        super(props);

        this.getEmployees = this.getEmployees.bind(this);
        this.getDepartmentInfo = this.getDepartmentInfo.bind(this);

        this.toggleEmployeeCard = this.toggleEmployeeCard.bind(this);

        this.state = {
            employees: [],
            modalEmployeeCard: false
        };
    }

    componentDidMount() {
        this.getEmployees();
    }

    getEmployees() {
        fetch(GET_EMPLOYEES_URL)
            .then(response => response.json())
            .then(data => this.setState({ employees: data })
            );
    }

    toggleEmployeeCard(employee) {
        if (employee !== undefined && employee !== null) {
            this.getDepartmentInfo(employee);
        }

        this.setState({
            employee: employee,
            modalEmployeeCard: !this.state.modalEmployeeCard
        } )
    }

    getDepartmentInfo(employee) {
        fetch(GET_DEP_INFO_URL, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(employee)
            })
            .then(response => response.json())
            .then(data => {
                    this.setState({ departmentInfo: data });
                }
            );
    }

    render() {
        return (
            <div>
                <br/>
                {
                    this.state.employees.length > 0 && <span>Работники</span>}
                {
                    this.state.employees.map((item, key) =>
                        <Row key={key}>
                            <div style={{ cursor: "pointer" }} onClick={this.toggleEmployeeCard.bind(this, item)}>{item.name}</div>
                        </Row>)}

                <EmployeeCard
                    employee={this.state.employee}
                    modal={this.state.modalEmployeeCard}
                    toggle={this.toggleEmployeeCard}
                    departmentInfo={this.state.departmentInfo}
                />

            </div>
        );
    }
}