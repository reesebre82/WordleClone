import React from "react";
import ProjectRow from "./ProjectRow";

const ProjectContainer = (props) => {

    const ProjectContainerStyle = {
        width: '60vw',
        height: '75vh',
        position: 'relative',
        left: '50%',
        top: '50%',
        transform: 'translate(-50%, -50%)'
    }

    return (
      <div style={ProjectContainerStyle}>
          <ProjectRow 
                flexLeft='true' 
                leftColor='rgb(81, 55, 164)' 
                rightColor='rgb(242, 172, 108)'></ProjectRow>
          <ProjectRow 
                leftColor='rgb(156, 209, 251)' 
                rightColor='rgb(66, 101, 236'
                rightTitle="See all projects"
                rightDescription="Over 15+ Projects"></ProjectRow>
      </div>
    )
  }
  
export default ProjectContainer