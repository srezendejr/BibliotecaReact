import React from "react";

function LivroLista({ entidade, livros, tipo }) {

    if (!entidade) return null;

    const titulo =
        tipo === "autor"
            ? `📚 Livros do Autor: ${entidade.nome}`
            : `📚 Livros do Gênero: ${entidade.nome}`;

    return (

        <div style={{ marginTop: 40 }}>

            <h3>{titulo}</h3>

            {livros.length === 0 ? (

                <p>Nenhum livro encontrado.</p>

            ) : (

                <table border="1" cellPadding="8">

                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Título</th>
                        </tr>
                    </thead>

                    <tbody>

                        {livros.map(l => (

                            <tr key={l.id}>
                                <td>{l.id}</td>
                                <td>{l.titulo}</td>
                            </tr>

                        ))}

                    </tbody>

                </table>

            )}

        </div>
    );
}

export default LivroLista;