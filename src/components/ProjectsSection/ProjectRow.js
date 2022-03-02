import { render } from "@testing-library/react";
import React, { Component } from "react";
import ProjectBox from "./ProjectBox";

class ProjectRow extends Component {

    constructor(props){
        super(props);

        this.state = {
            leftColor: props.leftColor,
            rightColor: props.rightColor,
            leftTitle: props.leftTitle,
            rightTitle: props.rightTitle,
            leftDescription: props.leftDescription,
            rightDescription: props.rightDescription,
            leftFlex: props.flexLeft ? 1 : 3,
            rightFlex: props.flexLeft ? 3 : 1,
            defaultFlex: props.flexLeft,
        };
    }
    
    styles = {
        height: '50%',
        width: '100%',
        display: 'flex',
    }

    flipFlex = (value) => {
        if(this.state.defaultFlex)
        {
            if(value === '0'){
                this.setState({
                    leftFlex: 3,
                    rightFlex: 1,
                });
            } else {
                this.setState({
                    leftFlex: 1,
                    rightFlex: 3,
                });
            } 
        }
        else{
            if(value === '1'){
                this.setState({
                    leftFlex: 1,
                    rightFlex: 3,
                });
            } else {
                this.setState({
                    leftFlex: 3,
                    rightFlex: 1,
                });
            } 
        }
    }

    render() {
        return (
            <div style={this.styles}>
                <ProjectBox 
                    bgColor={this.state.leftColor}
                    defaultFlex={this.state.leftFlex}
                    sendData={this.flipFlex}
                    value='0'></ProjectBox>
                <ProjectBox 
                    bgColor={this.state.rightColor}
                    defaultFlex={this.state.rightFlex}
                    sendData={this.flipFlex}
                    value='1'
                    title={this.state.rightTitle}
                    description={this.state.rightDescription}></ProjectBox>
            </div>
        );
    }
  }
  
export default ProjectRow