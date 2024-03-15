
//Criação de um vetor
int[] vetor = new int[100];
Random aleatorio = new Random();

//Preencher com valores alatórios no vetor
for(int i = 0; i < vetor.Length; i++) 
{

    vetor[i] = aleatorio.Next(100);
    Console.Write(vetor[i] + " ");

}

Console.WriteLine("\n");

//Ordenar o vetor com Bubble Sort
bool troca;

do {

    troca = false;

    for (int i = 0; i < vetor.Length - 1; i++)
    {

        if (vetor[i] > vetor[i + 1])
        {
            int aux = vetor[i];
            vetor[i] = vetor[i + 1];
            vetor[i + 1] = aux;
            troca = true;
        } 

    }

} while (troca == true);

Console.WriteLine("\n");

//Apresentar o vetor ordenado
for (int i = 0; i < vetor.Length; i++)
{
    Console.Write(vetor[i] + " ");
}

