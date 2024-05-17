import { getElementError } from '@testing-library/react';
import { get } from 'http';
import React, { useState } from 'react';

//1 - Exibir valor do contador no HTML
//2 - Realizar o exercício da soma

function Soma() {

  const [contador, setContador] = useState(0); 

  
  
  function clicar(){
    
    setContador(contador + 1);

    console.log(contador);

  }

  return (
    <div>

      <h1>SOMA</h1>

      <label>Número 1:</label><br />
      <input type="number" name="num1"/><br />

      <label>Número 2:</label><br />
      <input type="number" name="num2"/><br /><br />

      <button onClick={clicar}>Calcular</button>

    </div>
  );
}

export default Soma;
