import React from "react";

const TitleLink = () => {

    const TitleLinkStyle = {
        height: "100%",
        float: "left",
        padding: "0px 20px",
        margin: "0px 20px",
        lineHeight: "75px"
    }

    function MouseOver(event) {
        event.target.style.cursor = 'default';
    }

    return (
      <div 
            style={TitleLinkStyle}
            onMouseOver={MouseOver} >
          Brendan R.
      </div>
    )
  }
  
export default TitleLink