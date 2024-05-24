import { useEffect, useState } from "react";

//EXERCÍCIOS
//1 - Consutar os produtos da API(CORS)
//2 - Exibir no HTML uma lista de produtos

function CepConsultar(){

    const [rua, setRua] = useState("");

    //Evento de carregamento do componente
    useEffect(() => {
        console.log("o componente carregou...");

        //FETCH ou AXIOS
        fetch("https://viacep.com.br/ws/01001000/json/").then((resposta) => 
            resposta.json()
        ).then((cep) => {
            console.log(cep.logradouro);
            setRua(cep.logradouro);
        });
    }, []);

    return(
        <div>
            <h1>{ rua }</h1>
        </div>
    )
}

export default CepConsultar;