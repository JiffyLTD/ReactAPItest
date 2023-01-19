import React from 'react';
import classes from './MyTitle.module.css';

const MyH1 = ({children}) => {
  return (
    <h1 className={classes.myTitle}>
        {children}
    </h1>
  )
}

export default MyH1