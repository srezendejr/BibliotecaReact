import React from "react";
import { Link } from "react-router-dom";

function Navbar() {

    const estilo = {
        padding: "10px 20px",
        backgroundColor: "#333",
        color: "white",
        display: "flex",
        gap: "20px"
    };

    const linkStyle = {
        color: "white",
        textDecoration: "none",
        fontWeight: "bold"
    };
    return (
        <nav style={estilo}>
            <Link style={linkStyle} to="/autores">Autores</Link>
            <Link style={linkStyle} to="/generos">Gêneros</Link>
            <Link style={linkStyle} to="/livros">Livros</Link>
        </nav>
    );
}

export default Navbar;
//import React from 'react';
//import { Link } from 'react-router-dom';
//import '../App.css';

//const Navbar = () => {
//    return (
//        <div style={{ padding: '20px', fontFamily: 'Arial' }}>
//            <h1>🏠 Menu Principal</h1>
//            <nav style={{ marginBottom: '20px' }}>
//                <ul>
//                    <li><Link to="/autor">Autores</Link></li>
//                    <li><Link to="/genero">Gêneros</Link></li>
//                    <li><Link to="/livro">Livros</Link></li>
//                </ul>
//            </nav>
//        </div>
//    );
//};

//export default Navbar;