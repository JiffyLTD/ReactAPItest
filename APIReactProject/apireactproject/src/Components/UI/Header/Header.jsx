import React from 'react'
import {Link} from 'react-router-dom';

const Header = () => {
  return (
    <header className='header'>
            <Link className='header-buttons' to={'/about'}>О сайте</Link>
            <Link className='header-buttons' to={'/posts'}>Посты</Link>
    </header>
  )
}

export default Header