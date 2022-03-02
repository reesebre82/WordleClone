import React from "react";

const SnapSection = (props) => {

    const SnapSectionStyle = {
        height: "100vh",
        width: '100%',
        backgroundColor: props.bgColor,
        scrollSnapAlign: 'center'
    }

    return (
      <div style={SnapSectionStyle}>
          {props.children}
      </div>
    )
  }
  
export default SnapSection