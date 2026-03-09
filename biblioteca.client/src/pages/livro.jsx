import React, { useEffect, useState } from "react";
import LivroForm from "../components/LivroForm";
import LivroTabela from "../components/LivroTabela";

function Livros() {

    const [livros, setLivros] = useState([]);
    const [autores, setAutores] = useState([]);
    const [generos, setGeneros] = useState([]);

    const API_URL = "https://localhost:7208/api";

    const buscarLivros = () => {
        fetch(API_URL + "/v1/Livro/ListaLivros")
            .then(res => res.json())
            .then(data => setLivros(data));
    };

    const buscarAutores = () => {
        fetch(API_URL + "/v1/Autor/ListaAutores")
            .then(res => res.json())
            .then(data => setAutores(data));
    };

    const buscarGeneros = () => {
        fetch(API_URL + "/v1/Genero/ListaGeneros")
            .then(res => res.json())
            .then(data => setGeneros(data));
    };

    useEffect(() => {
        buscarLivros();
        buscarAutores();
        buscarGeneros();
    }, []);

    return (

        <div style={{ padding: 30 }}>

            <h1>📖 Cadastro de Livros</h1>

            <LivroForm
                API_URL={API_URL}
                atualizarLivros={buscarLivros}
                autores={autores}
                generos={generos}
            />

            <LivroTabela
                livros={livros}
                autores={autores}
                generos={generos}
                atualizarLivros={buscarLivros}
                API_URL={API_URL}
            />

        </div>

    );
}

export default Livros;