import { BrowserRouter, Link, Route, Routes } from "react-router-dom";
import ProdutoCadastrar from "./components/pages/produto/produto-cadastrar";
import ProdutoListar from "./components/pages/produto/produto-listar";
import CepConsultar from "./components/pages/cep/cep-consultar";

function App() {
  return (
    <div>
      <BrowserRouter>

        <nav>
          <ul>
            <li>
              <Link to={"/"}>Home</Link>
            </li>
            <li>
              <Link to={"/pages/produto/listar"}>Listar Produtos</Link>
            </li>
            <li>
              <Link to={"/pages/produto/cadastrar"}>Cadastrar Produtos</Link>
            </li>
            <li>
              <Link to={"/pages/cep/consultar"}>Consultar CEP</Link>
            </li>
          </ul>
        </nav>

        <Routes>
          <Route path='/' element={<ProdutoListar />}/>
          <Route path='/pages/produto/listar' element={<ProdutoListar/>}/>
          <Route path='/pages/produto/cadastrar' element={<ProdutoCadastrar/>}/>
          <Route path='/pages/cep/consultar' element={<CepConsultar/>}/>
        </Routes>

        <footer>
          <p>Desenvolvido por Lucas</p>
        </footer>
      
      </BrowserRouter>

    </div>
  );
}

export default App;
