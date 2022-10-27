import React, { Component } from 'react';
import './custom.css'
import { Link, Outlet } from 'react-router-dom';

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <div class='container c1'>
                <div class='header'><h1 class='headerText'>Blåatoppens dagblad Admin</h1></div>
                <div class='Nav'>
                <nav>
                    <Link to='/Articles'>Artiklar</Link> | {" "}
                    <Link to='/Journalists'>Journalister</Link> | {" "}
                    <Link to='/Images'>Bilder</Link>

                </nav>
                </div>
                <Outlet/>

                {/* <p>Din admin-app!1</p> */}
            </div>
        );
    }
}
