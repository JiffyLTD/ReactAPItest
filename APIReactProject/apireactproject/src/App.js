import React from 'react'
import { BrowserRouter, Route, Routes, Navigate } from 'react-router-dom';
import About from './Pages/About';
import Posts from './Pages/Posts';
import './styles/app.css';
import Header from './Components/UI/Header/Header';
import Error from './Pages/Error';

function App() {
    return (
        <BrowserRouter>
            <Header/>
            <Routes>
                <Route path="/about" element={<About/>} />
                <Route path="/posts" element={<Posts/>} />
                <Route path="/error" element={<Error/>} />
                <Route path="*" element={<Navigate replace to="/error"/>} />
            </Routes>
        </BrowserRouter>
    );
}

export default App;