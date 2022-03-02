import React from 'react'
import TitleLink from './TitleLink'
import ProjectsLink from './ProjectsLink'
import ContactsLink from './ContactsLink'

const Header = () => {

  const HeaderStyle = {
    position: 'relative',
    textAlign: "center",
    fontSize: "22px",
    width: "100vw",
    height: "75px"
   }

  return (
    <div style={HeaderStyle}>
      <TitleLink />
      <ContactsLink />
      <ProjectsLink />
    </div>
  )
}

export default Header