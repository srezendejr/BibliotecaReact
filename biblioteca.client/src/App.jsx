import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Navbar from "./components/Navbar";
import Autores from "./pages/autor";
import Generos from "./pages/genero";
import Livros from "./pages/livro";

function App() {

    return (

        <BrowserRouter>
            <Navbar />
            <Routes>
                <Route path="/autores" element={<Autores />} />
                <Route path="/generos" element={<Generos />} />
                <Route path="/livros" element={<Livros />} />
            </Routes>

        </BrowserRouter>

    );
}

export default App;

//import React from 'react';
//import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
//import Navbar from './components/Navbar';
//import Autores from './pages/autor';
//import Generos from './pages/genero';
//import Livros from './pages/livro';
//import './App.css';

//const App = () => {
//    return (
//        <Router>
//            <Navbar />
//            <Routes>
//                <Route path="/autor" element={<Autores />} />
//                <Route path="/genero" element={<Generos />} />
//                <Route path="/livro" element={<Livros />} />
//            </Routes>
//        </Router>
//    );
//};


//export default App;


//import React, { useState } from 'react';
//import Compradores from './pages/Compradores';
//import Pedidos from './pages/Pedidos';
//import Produtos from './pages/Produtos';

//function App() {
//    const [paginaAtual, setPaginaAtual] = useState(false);
//    const renderizarPagina = () => {
//        switch (paginaAtual) {
//            case 'pedidos':
//                return <h2>📦 Página de Pedidos</h2>;
//            case 'compradores':
//                return <h2>🧑‍🤝‍🧑 Página de Compradores</h2 >;
//            case 'produtos':
//                return <h2>🛒 Página de Produtos</h2>;
//            default:
//                return <h2>Bem-vindo!</h2>;
//        }
//    };

//    return (
//        <div style={{ padding: '20px', fontFamily: 'Arial' }}>
//            <h1>🏠 Menu Principal</h1>
//            <nav style={{ marginBottom: '20px' }}>
//                <button onClick={() => setPaginaAtual('pedidos')} style={{ marginRight: '10px' }}>
//                    Pedidos
//                </button>
//                <button onClick={() => setPaginaAtual('compradores')} style={{ marginRight: '10px' }}>
//                    Compradores
//                </button>
//                <button onClick={() => setPaginaAtual('produtos')}>
//                    Produtos
//                </button>
//            </nav>

//            <div>
//                {renderizarPagina()}
//            </div>
//        </div>
//    );
//}

//export default App;


//import { useEffect, useState } from 'react';
//import './App.css';

//function App() {
//    const [forecasts, setForecasts] = useState();

//    useEffect(() => {
//        populateWeatherData();
//    }, []);

//    const contents = forecasts === undefined
//        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
//        : <table className="table table-striped" aria-labelledby="tableLabel">
//            <thead>
//                <tr>
//                    <th>Date</th>
//                    <th>Temp. (C)</th>
//                    <th>Temp. (F)</th>
//                    <th>Summary</th>
//                </tr>
//            </thead>
//            <tbody>
//                {forecasts.map(forecast =>
//                    <tr key={forecast.date}>
//                        <td>{forecast.date}</td>
//                        <td>{forecast.temperatureC}</td>
//                        <td>{forecast.temperatureF}</td>
//                        <td>{forecast.summary}</td>
//                    </tr>
//                )}
//            </tbody>
//        </table>;

//    return (
//        <div>
//            <h1 id="tableLabel">Weather forecast</h1>
//            <p>This component demonstrates fetching data from the server.</p>
//            {contents}
//        </div>
//    );

//    async function populateWeatherData() {
//        const response = await fetch('weatherforecast');
//        if (response.ok) {
//            const data = await response.json();
//            setForecasts(data);
//        }
//    }
//}

//export default App;