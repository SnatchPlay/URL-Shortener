import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';
import  About  from './About';
import './App.css';
export class Layout extends Component {
    static displayName = Layout.name;

    render() {

        return (
            <div className="App">
        <NavMenu />
        <Container tag="main">
          {this.props.children}
            </Container>
            <About/>
      </div>
    );
  }
}
