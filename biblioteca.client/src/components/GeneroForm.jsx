import React, { useState } from "react";

function GeneroForm({ API_URL, atualizarGeneros }) {

    const [genero, setGenero] = useState({
        id: 0,
        nome: ""
    });

    const [modoEdicao, setModoEdicao] = useState(false);

    const salvar = async () => {

        const metodo = modoEdicao ? "PUT" : "POST";

        const url = modoEdicao
            ? API_URL + "/v1/Genero/AtualizarGenero/" + genero.id
            : API_URL + "/v1/Genero/SalvarGenero";

        try {

            const response = await fetch(url, {
                method: metodo,
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(genero)
            });

            if (!response.ok) {
                const mensagem = await response.text();
                throw new Error(mensagem);
            }

            atualizarGeneros();
            limpar();

        } catch (erro) {
            alert(erro.message);
        }
    };

    const limpar = () => {

        setGenero({ id: 0, nome: "" });
        setModoEdicao(false);
    };

    return (

        <div style={{ marginBottom: 30 }}>
            <h3>{modoEdicao ? "Editar Gênero" : "Novo Gênero"}</h3>
            {modoEdicao && (
                <>
                    ID <br />
                    <input value={genero.id} disabled />
                    <br />
                </>
            )}
            Nome <br />
            <input
                value={genero.nome}
                onChange={(e) =>
                    setGenero({ ...genero, nome: e.target.value })
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

export default GeneroForm;