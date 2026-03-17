import React, { useState } from "react";

function AutorForm({ API_URL, atualizarAutores }) {

    const [autor, setAutor] = useState({
        id: 0,
        nome: ""
    });

    const [modoEdicao, setModoEdicao] = useState(false);

    const salvar = async () => {

        const metodo = modoEdicao ? "PUT" : "POST";

        const url = modoEdicao
            ? API_URL + "/v1/Autor/AtualizarAutor/" + autor.id
            : API_URL + "/v1/Autor/SalvarAutor";

        try {

            const response = await fetch(url, {
                method: metodo,
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(autor)
            });

            if (!response.ok) {
                const mensagem = await response.text();
                throw new Error(mensagem);
            }

            atualizarAutores();
            limpar();

        } catch (erro) {
            alert(erro.message);
        }
    };

    const limpar = () => {

        setAutor({ id: 0, nome: "" });
        setModoEdicao(false);
    };

    return (

        <div style={{ marginBottom: 30 }}>

            <h3>{modoEdicao ? "Editar Autor" : "Novo Autor"}</h3>

            {modoEdicao && (
                <>
                    ID <br />
                    <input value={autor.id} disabled />
                    <br />
                </>
            )}

            Nome <br />
            <input
                value={autor.nome}
                onChange={(e) =>
                    setAutor({ ...autor, nome: e.target.value })
                }
            />

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

export default AutorForm;