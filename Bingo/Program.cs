int numerosTotais = 99, aux = 0, verificacao = 0, qtd = 5;
int qtdLinhaColuna = 3;
int[] sorteio = new int[numerosTotais];
bool numeroChecado = false;

//CRIAR VETOR E MATRIZ  
int[,] CriarMatriz()
{
    int[,] matriz = new int[qtdLinhaColuna, qtdLinhaColuna];
    return matriz;
}
int[] CriarVetor()
{
    int[] vetor = new int[numerosTotais];
    return vetor;
}

// CARTELA SORTEIO
int[] PovoarVetor()
{
    int[] vetor = CriarVetor();
    for (int i = 0; i < numerosTotais; i++)
    {
        verificacao = 0;
        aux = new Random().Next(1, 100);
        for (int j = numerosTotais - 1; j > -1; j--)
        {
            if (aux == vetor[j])
                verificacao++;
        }
        if (verificacao == 0)
            vetor[i] = aux;
        else
            i--;
    }
    return vetor;
}

// CARTELA JOGADOR
int[,] PovoarCartela()
{
    int[,] cartela = CriarMatriz();
    for (int i = 0; i < qtdLinhaColuna; i++)
    {
        for (int j = 0; j < qtdLinhaColuna; j++)
        {
            cartela[i, j] = ChecarCartela(cartela, i, j);
        }
    }
    return cartela;
}
int ChecarCartela(int[,] cartela, int linha, int coluna)
{   
    numeroChecado = false;
    int num = 0;
    while (numeroChecado != true)
    {
        aux = new Random().Next(1, 100);
        verificacao = 0;

        for (int i = 0; i < qtdLinhaColuna; i++)
        {
            for (int j = 0; j < qtdLinhaColuna; j++)
            {
                if (aux == cartela[i, j])
                    verificacao++;
            }
        }
        if (verificacao == 0)
        {
            num = aux;
            numeroChecado = true;
        }
    }
    return num;
}

// IMPRIMIR
void ImprimirMatriz(int[,] matriz)
{
    Console.WriteLine();
    for (int linha = 0; linha < qtdLinhaColuna; linha++)
    {
        Console.WriteLine();
        for (int coluna = 0; coluna < qtdLinhaColuna; coluna++)
            Console.Write($"{matriz[linha, coluna]}, ");
    }
    Console.WriteLine("\n");
}
void ImprimirVetor(int[] vetor)
{
    Console.WriteLine();
    for (int linha = 0; linha < numerosTotais; linha++)
    {
        Console.Write($"{vetor[linha]}, ");
    }
    Console.WriteLine("\n");
}

// MAIN
int[,] cartelaJogador = PovoarCartela();
int[] vetorSorteio = PovoarVetor();

ImprimirMatriz(cartelaJogador);
ImprimirVetor(vetorSorteio);


