import React, { useState } from "react";

function LivroForm({ API_URL, atualizarLivros, autores, generos }) {

    const [livro, setLivro] = useState({
        id: 0,
        titulo: "",
        autorId: "",
        generoId: ""
    });

    const [modoEdicao, setModoEdicao] = useState(false);

    const salvar = () => {

        if (!livro.titulo || !livro.autorId || !livro.generoId) {
            alert("Preencha todos os campos");
            return;
        }

        const metodo = modoEdicao ? "PUT" : "POST";

        const url = modoEdicao
            ? API_URL + "/Livro/" + livro.id
            : API_URL + "/Livro";

        fetch(url, {
            method: metodo,
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(livro)
        })
            .then(() => {
                atualizarLivros();
                limpar();
            });
    };

    const limpar = () => {

        setLivro({
            id: 0,
            titulo: "",
            autorId: "",
            generoId: ""
        });

        setModoEdicao(false);
    };

    return (

        <div style={{ marginBottom: 30 }}>

            <h3>{modoEdicao ? "Editar Livro" : "Novo Livro"}</h3>

            {modoEdicao && (
                <>
                    ID <br />
                    <input value={livro.id} disabled />
                    <br />
                </>
            )}

            Título <br />
            <input
                value={livro.titulo}
                onChange={(e) =>
                    setLivro({ ...livro, titulo: e.target.value })
                }
            />

            <br /><br />

            Autor <br />
            <select
                value={livro.autorId}
                onChange={(e) =>
                    setLivro({ ...livro, autorId: e.target.value })
                }
            >
                <option value="">Selecione</option>

                {autores.map(a => (
                    <option key={a.id} value={a.id}>
                        {a.nome}
                    </option>
                ))}

            </select>

            <br /><br />

            Gênero <br />
            <select
                value={livro.generoId}
                onChange={(e) =>
                    setLivro({ ...livro, generoId: e.target.value })
                }
            >
                <option value="">Selecione</option>

                {generos.map(g => (
                    <option key={g.id} value={g.id}>
                        {g.nome}
                    </option>
                ))}

            </select>

            <br /><br />

            <button onClick={salvar}>
                {modoEdicao ? "Salvar" : "Cadastrar"}
            </button>

            {modoEdicao && (
                <button onClick={limpar}>
                    Cancelar
                </button>
            )}

        </div>

    );
}

export default LivroForm;