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

    return(
        <div>

            <h1>Listar Produtos</h1>

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