import { useState } from "react";
import { Produto } from "../../../models/Produto";

function ProdutoCadastrar(){

    const [nome, setNome] = useState("");
    const [descricao, setDescricao] = useState("");
    const [valor, setValor] = useState(0);
    const [quantidade, setQuantidade] = useState(0);

    function cadastrarProduto(){

        const produto : Produto = {
            nome : nome,
	        descricao : descricao,
	        valor : valor,
	        quantidade : quantidade
        }

        //FETCH ou AXIOS
        fetch("http://localhost:5134/api/produto/cadastrar", 
        {
            method : "POST", 
            headers : {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(produto)
            
        }).then((resposta) => 

            resposta.json()

        ).then((produto : Produto) => {

            console.table(produto);

        });
    }
    
    return (
    
        <div>

            <h1>Cadastrar Produto</h1>

            <form action="" onSubmit={cadastrarProduto}>

            <label>Nome:</label>
            <input type="text" placeholder="Digite um nome" onChange={(e : any) => setNome(e.target.value)} required />
            
            <br />
            <br />

            <label>Descrição:</label>
            <input type="text" placeholder="Digite uma descrição do produto" onChange={(e : any) => 
                setDescricao(e.target.value)} required />

            <br />
            <br />
            
            <label>Valor:</label>
            <input type="text" placeholder="Digite o valor" onChange={(e : any) => 
                setValor(e.target.value)} required />
            
            <br />
            <br />

            <label>Quantidade:</label>
            <input type="text" placeholder="Digite a quantidade" onChange={(e : any) => 
                setQuantidade(e.target.value)} required />

            <br />
            <br />

            <button type="submit">Cadastrar</button> 

            </form>

        </div>

    )
}

export default ProdutoCadastrar;