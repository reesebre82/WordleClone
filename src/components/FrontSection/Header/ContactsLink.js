import React from "react";
import { motion } from "framer-motion";

const ContactsLink = () => {

    const ContactsLinkStyle = {
        height: "100%",
        float: "right",
        padding: "0px 20px",
        margin: "0px 20px",
        lineHeight: "75px",
        fontSize: 'large'
    }

    async function MouseOver(event) {
        event.target.style.cursor = 'pointer';
    }
    function MouseOut(event){
    }

    return (
      <motion.div 
                style={ContactsLinkStyle} 
                onMouseOver={MouseOver} 
                onMouseOut={MouseOut} 
                whileHover={{ scale: 1.1 }}
                whileTap={{ scale: 0.9 }}>
          Contacts
      </motion.div>
    )
  }
  
export default ContactsLink