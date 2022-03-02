import React from "react";
import { motion } from "framer-motion";

const ProjectsLink = () => {

    const ProjectLinkStyle = {
        height: "100%",
        float: "right",
        padding: "0px 20px",
        margin: "0px 20px",
        lineHeight: "75px",
        fontSize: 'large'
    }

    function MouseOver(event) {
        event.target.style.cursor = 'pointer';
    }
    function MouseOut(event){
    }

    return (
      <motion.div 
                style={ProjectLinkStyle} 
                onMouseOver={MouseOver} 
                onMouseOut={MouseOut} 
                whileHover={{ scale: 1.1 }}
                whileTap={{ scale: 0.9 }}>
          All Projects
      </motion.div>
    )
  }
  
export default ProjectsLink