import React from "react";

const ProjectBox = (props) => {

    const ProjectBoxStyle = {
        flexGrow: props.defaultFlex,
        backgroundColor: props.bgColor,
        borderRadius: '15px',
        flexBasis: '100px',
        margin: '10px',
        transition: 'all 0.25s'
    }

    const DescriptionStyle = {
        color: "lightgray",
        position: 'relative',
        left: 'calc(5% + 1px)',
        top: '5%',
    }
    
    const TitleStyle = {
        color: 'white',
        position: 'relative',
        left: '5%',
        top: '0px',
    }

    function MouseOver(event) {
        props.sendData(props.value);
    }

    function MouseOut(event) {
       props.sendData('-1');
    }

    return (
      <div style={ProjectBoxStyle}
            onMouseOver={MouseOver} 
            onMouseOut={MouseOut}>
            <p style={DescriptionStyle}>{props.description}</p>
            <h1 style={TitleStyle}>{props.title}</h1>
      </div>
    )
  }
  
export default ProjectBox