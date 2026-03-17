import React, { useState } from "react";

function AutorLista({ autores, onSelecionar, atualizarAutores, API_URL }) {

    const [pagina, setPagina] = useState(1);
    const itensPorPagina = 5;

    const excluir = async (autor) => {
        if (!window.confirm("Excluir autor?")) return;
        try {
            const response = await fetch(API_URL + "/v1/Autor/ExcluirAutor/" + autor.id, {
                method: "DELETE"
            });
            if (!response.ok) {
                const mensagem = await response.text();
                throw new Error(mensagem);
            }
            atualizarAutores();
        } catch (erro) {
            alert(erro.message);
        }
    };;

    const inicio = (pagina - 1) * itensPorPagina;
    const autoresPagina = autores.slice(inicio, inicio + itensPorPagina);
    return (
        <div>
            <h3>Autores</h3>
            <table border="1" cellPadding="8">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Nome</th>
                        <th>Livros</th>
                        <th>Excluir</th>
                    </tr>
                </thead>
                <tbody>
                    {autoresPagina.map(a => (
                        <tr key={a.id}>
                            <td>{a.id}</td>
                            <td>{a.nome}</td>
                            <td>
                                <button
                                    onClick={() => onSelecionar(a)}
                                >
                                    Ver Livros
                                </button>
                            </td>
                            <td>
                                <button
                                    onClick={() => excluir(a)}
                                >
                                    Excluir
                                </button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
            <br />
            <button
                disabled={pagina === 1}
                onClick={() => setPagina(pagina - 1)}
            >
                Anterior
            </button>
            <button
                disabled={inicio + itensPorPagina >= autores.length}
                onClick={() => setPagina(pagina + 1)}
            >
                Próximo
            </button>
        </div>
    );
}

export default AutorLista;