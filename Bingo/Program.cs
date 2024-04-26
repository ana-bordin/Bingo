int numerosTotais = 9, aux = 0, verificacao = 0, qtd = 5, posicao = 0, numPessoas = 0, numAtual = 0;
int qtdLinhaColuna = 3, tabelaPorJogador = 1;
bool numeroChecado = false, posibilidadeLinha = false, posibilidadeColuna = false, posibilidadeCartela = false;
int[] checar = new int[2];

//CRIAR VETOR E MATRIZ  
int[,] CriarMatriz()
{
    int[,] matriz = new int[qtdLinhaColuna, qtdLinhaColuna];
    return matriz;
}
int[] CriarVetor(int numMax)
{
    int[] vetor = new int[numMax];
    return vetor;
}

// CARTELA SORTEIO
int[] PovoarVetor()
{
    int[] vetor = CriarVetor(numerosTotais);
    for (int i = 0; i < numerosTotais; i++)
    {
        verificacao = 0;
        aux = new Random().Next(1, 10);
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
            cartela[i, j] = ChecarRepetidoCartela(cartela, i, j, 1);
        }
    }
    return cartela;
}
int ChecarRepetidoCartela(int[,] cartela, int linha, int coluna, int opcao)
{
    int num = 0;
    numeroChecado = false;
    while (num == 0)
    {
        aux = new Random().Next(1, 10);
        verificacao = 0;
        num = ChecarCartela(cartela, aux, opcao);
    }
    return num;
}
int ChecarCartela(int[,] cartela, int aux, int opcao)
{
    verificacao = 0;
    int linha = 0;
    int coluna = 0;
    int num = 0;
    for (int i = 0; i < qtdLinhaColuna; i++)
    {
        for (int j = 0; j < qtdLinhaColuna; j++)
        {
            if (aux == cartela[i, j])
            {
                linha = i;
                coluna = j;
                verificacao++;
            }
        }
    }
    if (verificacao == 0 && opcao == 1)
        num = aux;
    if (verificacao != 0 && opcao == 2)
    {
        cartela[linha, coluna] = 0;
        num = 0;
    }

    return num;
}
int ChecarNumSorteado(int numAtual, int[,] cartela)
{
    int NumLinhaColuna = ChecarCartela(cartela, numAtual, 2);
    return numAtual;
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

// NUMERO SORTEIO
int SortearNumero(int[] vetor)
{
    int numeroAtual = 0;

    if (posicao < numerosTotais)
    {
        numeroAtual = vetor[posicao];
        ImprimirNumero(vetor, posicao);
        posicao++;
    }

    return numeroAtual;
}
void ImprimirNumero(int[] vetor, int posicao)
{
    Console.WriteLine($"Número Sorteado:{vetor[posicao]}");
}

// CHECAR
int[] ChecarCartelaParaPontuar(int[,] cartela)
{
    int[] checar = CriarVetor(2);
    int verificacaoTotal = 0;
    for (int i = 0; i < qtdLinhaColuna; i++)
    {
        int verificacaoColuna = 0;
        int verificacaoLinha = 0;
        for (int j = 0; j < qtdLinhaColuna; j++)
        {
            if (cartela[i, j] == 0)
            {
                verificacaoLinha++;
                verificacaoTotal++;
            }

            if (cartela[j, i] == 0)
                verificacaoColuna++;
        }
        if (verificacaoLinha == qtdLinhaColuna)
        {
            checar[0] = 1;
            checar[1] = 1;
        }
        if (verificacaoColuna == qtdLinhaColuna)
        {
            checar[0] = 2;
            checar[1] = 2;
        }
        if (verificacaoTotal == qtdLinhaColuna * qtdLinhaColuna)
        {
            checar[0] = 3;
            checar[1] = 3;
        }
    }
    return checar;
}
int[] PosibilidadePontuar(int[,] cartela)
{
    int[] checar = ChecarCartelaParaPontuar(cartela);
    if (checar[0] == 1 && checar[1] == 1 && posibilidadeLinha == false)
    {
        posibilidadeLinha = true;
        Console.WriteLine("PREENCHEU LINHA");
    }

    if (checar[0] == 2 && checar[1] == 2 && posibilidadeColuna == false)
    {
        posibilidadeColuna = true;
        Console.WriteLine("PREENCHEU COLUNA");
    }
    if (checar[0] == 3 && checar[1] == 3 && posibilidadeCartela == false)
    {
        posibilidadeCartela = true;
        Console.WriteLine("BINGO!");
    }
    return checar;
}

// NUMEROS DE CARTELAS POR JOGADOR
void NumCartelasJogador(int numJogador)
{
    do
    {
        if (tabelaPorJogador < 1)
        {
            Console.WriteLine("Digite um número Valido!");
            tabelaPorJogador = int.Parse(Console.ReadLine());
        }
            
    } while (tabelaPorJogador < 1);
}

// MAIN 
int[] vetorSorteio = PovoarVetor();
int[,] cartelaJogador = PovoarCartela();
Console.WriteLine("Digite um número de tabela por jogador:");
tabelaPorJogador = int.Parse(Console.ReadLine());
NumCartelasJogador(tabelaPorJogador);

ImprimirMatriz(cartelaJogador);
do
{
    numAtual = SortearNumero(vetorSorteio);
    ChecarNumSorteado(numAtual, cartelaJogador);
    PosibilidadePontuar(cartelaJogador);
    ImprimirMatriz(cartelaJogador);

    Console.ReadKey();
} while (true);

