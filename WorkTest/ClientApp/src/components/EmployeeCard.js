import React, { Component } from 'react';
import { Collapse, Row, Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';

export class EmployeeCard extends Component {
    constructor(props) {
        super(props);
        this.toggleDepInfo = this.toggleDepInfo.bind(this);

        this.state = {
            isOpenDepInfo : false
        };
    }

    toggleDepInfo() {
        this.setState({ isOpenDepInfo: !this.state.isOpenDepInfo })
    }

    render() {
        return (
            <Modal isOpen={this.props.modal} toggle={this.props.toggle}>
                <ModalHeader toggle={this.props.toggle}>Работник</ModalHeader>
                <ModalBody>
                    {this.props.employee !== undefined && this.props.employee !== null &&
                        <div className="ml-4">
                            <Row>
                                {this.props.employee.name}
                            </Row>
                            {this.props.departmentInfo !== undefined && this.props.departmentInfo !== null &&
                                <div>
                                    <Row>
                                        <div style={{ cursor: "pointer" }} onClick={this.toggleDepInfo.bind(this, this.props.employee)}>
                                            {this.props.departmentInfo.departmentName}
                                        </div>
                                    </Row>
                                    <Row>
                                        <Collapse isOpen={this.state.isOpenDepInfo}>
                                            <Row className="px-5">
                                                {this.props.departmentInfo.departmentName}
                                            </Row>
                                            <div>
                                                {
                                                    this.props.departmentInfo.employeeNames.map((item, key) =>
                                                        <Row className="px-5" key={key}>{item}</Row>)}
                                            </div>
                                            <Row className="px-5">
                                                {this.props.departmentInfo.averageSalary}
                                            </Row>
                                        </Collapse>
                                    </Row>
                                </div>}
                            <Row>
                                {this.props.employee.salary}
                            </Row>
                        </div>}
                </ModalBody>
                <ModalFooter>
                    <Button color="secondary" onClick={e => this.props.toggle(undefined)}>Закрыть</Button>
                </ModalFooter>
            </Modal>
        );
    }
}