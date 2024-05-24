import { getElementError } from '@testing-library/react';
import { get } from 'http';
import React, { useState } from 'react';

//1 - Exibir valor do contador no HTML
//2 - Realizar o exercício da soma

function Soma() {

  const [contador, setContador] = useState(0); 
  const [num1, setNum1] = useState("");
  const [num2, setNum2] = useState("");
  const [resultado, setResultado] = useState(0);
  
  function incrementarContador(){
    
    setContador(contador + 1);

    console.log(contador);

  }

  function somar(){

    setResultado(parseInt(num1) + parseInt(num2));
    
  }

  function digitarNum1(e : any){
    console.log(e.target.value);
    setNum1(e.target.value);
  }
  
  function digitarNum2(e : any){
    console.log(e.target.value);
    setNum2(e.target.value);
  }
  

  return (
    <div>

      <h1>SOMA</h1>

      <label>Número 1:</label><br />
      <input type="number" onChange={digitarNum1}/><br />

      <label>Número 2:</label><br />
      <input type="number" onChange={ (e : any) => { setNum2(e.target.value) }}/><br /><br />

      <button onClick={incrementarContador}>Contador</button>

      <button onClick={somar}>Somar</button>

      <p>
        { contador }
      </p>

      <p>
        { resultado }
      </p>

    </div>
  );
}

export default Soma;
