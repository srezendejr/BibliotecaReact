import React, { useEffect, useState } from "react";
import AutorLista from "../components/AutorLista";
import AutorForm from "../components/AutorForm";
import LivroLista from "../components/LivroLista";

function Autores() {

    const [autores, setAutores] = useState([]);
    const [autorSelecionado, setAutorSelecionado] = useState(null);
    const [livros, setLivros] = useState([]);
    const [busca, setBusca] = useState("");

    const API_URL = "https://localhost:7208/api";

    const buscarAutores = () => {

        fetch(API_URL + "/v1/Autor/ListaAutores")
            .then(res => res.json())
            .then(data => setAutores(data));
    };

    const buscarLivros = (autor) => {

        setAutorSelecionado(autor);

        fetch(API_URL + "/v1/Autor/" + autor.id + "/livrosPorAutor")
            .then(res => res.json())
            .then(data => setLivros(data));
    };

    useEffect(() => {
        buscarAutores();
    }, []);

    const autoresFiltrados = autores.filter(a =>
        a.nome.toLowerCase().includes(busca.toLowerCase())
    );

    return (

        <div style={{ padding: 30 }}>

            <h1>✍️ Cadastro de Autores</h1>

            <input
                type="text"
                placeholder="Buscar autor..."
                value={busca}
                onChange={(e) => setBusca(e.target.value)}
                style={{ marginBottom: 20, width: 300 }}
            />

            <AutorForm
                API_URL={API_URL}
                atualizarAutores={buscarAutores}
            />

            <AutorLista
                autores={autoresFiltrados}
                onSelecionar={buscarLivros}
                atualizarAutores={buscarAutores}
                API_URL={API_URL}
            />

            <LivroLista
                entidade={autorSelecionado}
                livros={livros}
                tipo="autor"
            />

        </div>
    );
}

export default Autores;