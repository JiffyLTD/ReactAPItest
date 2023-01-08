import React, { useState } from 'react';
import './styles/app.css';
import './Components/PostItem';
import PostItem from './Components/PostItem';

function App() {

    return (
        <div className="App">
            <PostItem/>
            <PostItem/>
            <PostItem/>
            <PostItem/>
        </div>
        );
}

export default App;