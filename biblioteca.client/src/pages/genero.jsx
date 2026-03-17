import React, { useEffect, useState } from "react";
import GeneroForm from "../components/GeneroForm";
import GeneroLista from "../components/GeneroLista";
import LivroLista from "../components/LivroLista";

function Generos() {

    const [generos, setGeneros] = useState([]);
    const [generoSelecionado, setGeneroSelecionado] = useState(null);
    const [livros, setLivros] = useState([]);
    const [busca, setBusca] = useState("");

    const API_URL = "https://localhost:7208/api";

    const buscarGeneros = () => {

        fetch(API_URL + "/v1/Genero/ListaGeneros")
            .then(res => res.json())
            .then(data => setGeneros(data));
    };

    const buscarLivros = async (genero) => {
        setGeneroSelecionado(genero);
        try {
            const response = await fetch(API_URL + '/v1/Genero/' + genero.id + "/livrosPorGenero");
            if (!response.ok) {
                const mensagem = await response.text();
                throw new Error(mensagem);
            }
            const data = await response.json();
            setLivros(data);

        } catch (erro) {
            alert(erro.message);
        }
    };

    useEffect(() => {
        buscarGeneros();
    }, []);

    const generosFiltrados = generos.filter(g =>
        g.nome.toLowerCase().includes(busca.toLowerCase())
    );

    return (

        <div style={{ padding: 30 }}>

            <h1>📚 Cadastro de Gêneros</h1>

            <input
                type="text"
                placeholder="Buscar gênero..."
                value={busca}
                onChange={(e) => setBusca(e.target.value)}
                style={{ marginBottom: 20, width: 300 }}
            />

            <GeneroForm
                API_URL={API_URL}
                atualizarGeneros={buscarGeneros}
            />

            <GeneroLista
                generos={generosFiltrados}
                onSelecionar={buscarLivros}
                atualizarGeneros={buscarGeneros}
                API_URL={API_URL}
            />

            <LivroLista
                entidade={generoSelecionado}
                livros={livros}
                tipo="genero"
            />

        </div>
    );
}

export default Generos;