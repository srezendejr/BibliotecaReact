import React, { useState } from "react";

function GeneroLista({ generos, onSelecionar, atualizarGeneros, API_URL }) {

    const [pagina, setPagina] = useState(1);
    const itensPorPagina = 5;

    const excluir = (genero) => {

        if (!window.confirm("Excluir gênero?")) return;

        fetch(API_URL + "/v1/Genero/ExcluirGenero/" + genero.id, {
            method: "DELETE"
        })
            .then(() => atualizarGeneros());
    };

    const inicio = (pagina - 1) * itensPorPagina;
    const generosPagina = generos.slice(inicio, inicio + itensPorPagina);

    return (

        <div>

            <h3>Gêneros</h3>

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

                    {generosPagina.map(g => (

                        <tr key={g.id}>

                            <td>{g.id}</td>
                            <td>{g.nome}</td>

                            <td>
                                <button
                                    onClick={() => onSelecionar(g)}
                                >
                                    Ver Livros
                                </button>
                            </td>

                            <td>
                                <button
                                    onClick={() => excluir(g)}
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
                disabled={inicio + itensPorPagina >= generos.length}
                onClick={() => setPagina(pagina + 1)}
            >
                Próximo
            </button>

        </div>
    );
}

export default GeneroLista;