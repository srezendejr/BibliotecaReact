import React from "react";

function LivroTabela({ livros, autores, generos, atualizarLivros, API_URL }) {

    const excluir = (livro) => {

        if (!window.confirm("Excluir livro?")) return;

        fetch(API_URL + "/v1/Livro/ExcluirLivro/" + livro.id, {
            method: "DELETE"
        })
            .then(() => atualizarLivros());
    };

    const nomeAutor = (id) => {
        const autor = autores.find(a => a.id === id);
        return autor ? autor.nome : "";
    };

    const nomeGenero = (id) => {
        const genero = generos.find(g => g.id === id);
        return genero ? genero.nome : "";
    };

    return (

        <div>

            <h3>Lista de Livros</h3>

            <table border="1" cellPadding="8">

                <thead>

                    <tr>
                        <th>ID</th>
                        <th>Título</th>
                        <th>Autor</th>
                        <th>Gênero</th>
                        <th>Excluir</th>
                    </tr>

                </thead>

                <tbody>

                    {livros.map(l => (

                        <tr key={l.id}>

                            <td>{l.id}</td>

                            <td>{l.nome}</td>

                            <td>{nomeAutor(l.idAutor)}</td>

                            <td>{nomeGenero(l.idGenero)}</td>

                            <td>
                                <button
                                    onClick={() => excluir(l)}
                                >
                                    Excluir
                                </button>
                            </td>

                        </tr>

                    ))}

                </tbody>

            </table>

        </div>

    );
}

export default LivroTabela;