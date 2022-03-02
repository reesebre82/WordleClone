import React from "react";

const ScrollSnapScroller = (props) => {

    const ScrollSnapScrollerStyle = {
        scrollSnapType: 'y mandatory',
        maxHeight: '100vh',
        overflowY: 'scroll',
    }

    return (
      <div style={ScrollSnapScrollerStyle}>
          
          {props.children}
      </div>
    )
  }
  
export default ScrollSnapScroller