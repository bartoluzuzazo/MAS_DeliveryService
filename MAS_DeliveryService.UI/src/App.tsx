import React from 'react';
import { BrowserRouter } from 'react-router-dom';
import './App.css';
import {Nav} from "./Nav/Nav";
import {Router} from "./Router/Router";

function App() {
    return (
        <BrowserRouter>
        <div className="w-screen h-screen flex Font">
            <div className="flex justify-center items-center p-8">
                <Nav/>
            </div>
            <div>
                <Router/>
            </div>
        </div>
        </BrowserRouter>
    );
}

export default App;
