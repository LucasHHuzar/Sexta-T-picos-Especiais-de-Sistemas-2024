//Declarando as variáveis
int[] vetor = new int[100];
Random random = new Random();

//Alimentando o vetor com o recurso aleatório
for (int i = 0; i < vetor.Length; i++)
{
    vetor[i] = random.Next(101);
}

//Apresentando o vetor criado
for (int i = 0; i < vetor.Length; i++)
{
    Console.Write(vetor[i] + " ");
}
    //Ordenando os números com o recurso Array.Sort
    Array.Sort(vetor);   

    Console.WriteLine("\n");

//Apresentando o vetor ordenado
for (int i = 0; i < vetor.Length; i++)
{
    Console.Write(vetor[i] + " ");
}
