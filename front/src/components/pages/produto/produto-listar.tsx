import { useEffect, useState } from "react";
import { Endereco } from "../../../models/Endereco";
import { setCommentRange } from "typescript";
import { Produto } from "../../../models/Produto";

//EXERCÍCIOS
//1 - Consutar os produtos da API(CORS)
//2 - Exibir no HTML uma lista de produtos

function ProdutoListar(){

    const[produtos, setProdutos] = useState<Produto[]>([]);

    useEffect(() => {

        carregarProdutos();

    }, []);

    function carregarProdutos(){
        //FETCH ou AXIOS
        fetch("http://localhost:5134/api/produto/listar").then((resposta) => 

            resposta.json()

        ).then((produtos : Produto[]) => {

            console.table(produtos);
            setProdutos(produtos);
        });
    }
    
    function cadastrarProdutos(){

        const produto : Produto = {
            nome : "Strogonoff",
	        descricao : "Delicia",
	        valor : 20,
	        quantidade : 25
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

    return(
        <div>

            <h1>Listar Produtos</h1>

            <button onClick={cadastrarProdutos}>Cadastrar</button>

            <table border={1}>
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Nome</th>
                        <th>Descrição</th>
                        <th>Quantidade</th>
                        <th>Valor</th>
                        <th>CriadoEm</th>
                    </tr>
                </thead>

                <tbody>
                    {produtos.map(produto => (

                        <tr key={produto.id}>
                            <td>{produto.id}</td>
                            <td>{produto.nome}</td>
                            <td>{produto.descricao}</td>
                            <td>{produto.quantidade}</td>
                            <td>{produto.valor}</td>
                            <td>{produto.criadoEm}</td>
                        </tr>

                    ))}
                </tbody>

            </table>

        </div>
    )
}

export default ProdutoListar;