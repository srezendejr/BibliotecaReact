import React, { useState } from "react";

function LivroForm({ API_URL, atualizarLivros, autores, generos }) {

    const [livro, setLivro] = useState({
        id: 0,
        nome: "",
        idAutor: "",
        idGenero: ""
    });

    const [modoEdicao, setModoEdicao] = useState(false);

    const salvar = () => {

        if (!livro.nome || !livro.idAutor || !livro.idGenero) {
            alert("Preencha todos os campos");
            return;
        }

        const metodo = modoEdicao ? "PUT" : "POST";

        const url = modoEdicao
            ? API_URL + "/v1/Livro/BuscaLivroPorId/" + livro.id
            : API_URL + "/v1/Livro/SalvarLivro";

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
            nome: "",
            idAutor: "",
            idGenero: ""
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
                value={livro.nome}
                onChange={(e) =>
                    setLivro({ ...livro, nome: e.target.value })
                }
            />

            <br /><br />

            Autor <br />
            <select
                value={livro.idAutor}
                onChange={(e) =>
                    setLivro({ ...livro, idAutor: e.target.value })
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
                value={livro.idGenero}
                onChange={(e) =>
                    setLivro({ ...livro, idGenero: e.target.value })
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