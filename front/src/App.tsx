import CepConsultar from "./components/pages/cep/cep-consultar";
import ProdutoCadastrar from "./components/pages/produto/produto-cadastrar";
import ProdutoListar from "./components/pages/produto/produto-listar";
import ListagemProdutos from "./components/pages/produto/produto-listar";

function App() {
  return (
    <div>
      <h1>APP Funcionando</h1>
      
      {/* <CepConsultar/> */}

      <ProdutoCadastrar />

      <ProdutoListar/>
      
    </div>
  );
}

export default App;
