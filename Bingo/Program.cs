int numerosTotais = 9, aux = 0, verificacao = 0, qtd = 5, posicao = 0, numPessoas = 0, numAtual = 0;
int qtdLinhaColuna = 3, jogadorCartela = 0, numeroSorteado = 0, indice = 0, tamanhoVetorPessoasCartelas = 0, numPorPessoa = 0;
bool posibilidadeLinha = false, posibilidadeColuna = false, posibilidadeCartela = false;
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

// NUMERO SORTEIO
int SortearNumero(int[] numerosSorteados)
{
    bool numeroChecado = false;
    do
    {
        verificacao = 0;
        aux = new Random().Next(1, 10);
        for (int j = numerosTotais - 1; j > -1; j--)
        {
            if (aux == numerosSorteados[j])
                verificacao++;
        }
        if (verificacao == 0)
        {
            numerosSorteados[indice] = aux;
            numeroChecado = true;
            indice++;
        }
    }
    while (numeroChecado != true);
    return aux;
}
void ImprimirNumero(int numAtual)
{
    Console.WriteLine($"Número Sorteado:{numAtual}");
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

// CHECAR
int ChecarRepetidoCartela(int[,] cartela, int linha, int coluna, int opcao)
{
    int num = 0;
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
    int vetorLinha = 0;
    int num = 0;
    for (int v = 0; v < tamanhoVetorPessoasCartelas; v++)
    {
        for (int i = 0; i < qtdLinhaColuna; i++)
        {
            for (int j = 0; j < qtdLinhaColuna; j++)
            {
                if (aux == cartela[i, j])
                {
                    linha = i;
                    coluna = j;
                    vetorLinha = v;
                    verificacao++;
                }
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
void ImprimirVetorMatriz(int[][,] matriz, int cartelaPorJogador)
{
    int pessoa = 1;
    Console.WriteLine();
    for (int indexVetor = 0; indexVetor < tamanhoVetorPessoasCartelas; indexVetor++)
    {
        if (numPorPessoa == 0)
            Console.WriteLine($"Cartelas da {pessoa}ª pessoa:");

        if (numPorPessoa < cartelaPorJogador - 1)
            numPorPessoa++;
        else
        {
            numPorPessoa = 0;
            pessoa++;
        }
        for (int linha = 0; linha < qtdLinhaColuna; linha++)
        {
            for (int coluna = 0; coluna < qtdLinhaColuna; coluna++)
                Console.Write($"{matriz[indexVetor][linha, coluna]}, ");

            Console.WriteLine();
        }
        Console.WriteLine();
    }
    Console.WriteLine("\n");
}

// CHECAR
int[] ChecarCartelaParaPontuar(int[][,] cartela)
{
    int[] checar = CriarVetor(2);

    for (int x = 0; x < tamanhoVetorPessoasCartelas; x++)
    {
        int verificacaoTotal = 0;
        for (int i = 0; i < qtdLinhaColuna; i++)
        {
            int verificacaoColuna = 0;
            int verificacaoLinha = 0;
            for (int j = 0; j < qtdLinhaColuna; j++)
            {
                if (cartela[x][i, j] == 0)
                {
                    verificacaoLinha++;
                    verificacaoTotal++;
                }

                if (cartela[x][j, i] == 0)
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
    }
    return checar;
}
int[] PosibilidadePontuar(int[][,] cartela)
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
void NumJogadorCartela(int jogadorCartela, int opcaoJogadorCartela)
{
    do
    {
        if ((jogadorCartela < 1 && opcaoJogadorCartela == 2) || (jogadorCartela < 3 && opcaoJogadorCartela == 1))
        {
            Console.WriteLine("Digite um número Valido!");
            jogadorCartela = int.Parse(Console.ReadLine());
        }

    } while ((jogadorCartela < 1 && opcaoJogadorCartela == 2) || (jogadorCartela < 3 && opcaoJogadorCartela == 1));
}
int[][,] GerarVetorJogador(int qtdJogador, int cartelaPorJogador)
{
    tamanhoVetorPessoasCartelas = qtdJogador * cartelaPorJogador;
    int[][,] vetorPessoasCartelas = new int[tamanhoVetorPessoasCartelas][,];
    for (int i = 0; i < tamanhoVetorPessoasCartelas; i++)
    {
        int[,] vetorCartela = PovoarCartela();
        vetorPessoasCartelas[i] = vetorCartela;
    }
    return vetorPessoasCartelas;
}
int[][,] rodarVetor(int num, int[][,]vetorJogador)
{
    for (int i = 0; i < tamanhoVetorPessoasCartelas; i++)
    {
        int[,] cartela = vetorJogador[i];
        ChecarNumSorteado(num, cartela);
    }
    return null;
}
// MAIN 
int[] vetorSorteio = CriarVetor(10);
Console.WriteLine("Digite um número de jogadores:");
int qtdJogador = int.Parse(Console.ReadLine());
NumJogadorCartela(qtdJogador, 1);
Console.WriteLine("Digite um número de tabela por jogador:");
int cartelaPorJogador = int.Parse(Console.ReadLine());
NumJogadorCartela(cartelaPorJogador, 2);
int[][,] vetorJogador = GerarVetorJogador(qtdJogador, cartelaPorJogador);
ImprimirVetorMatriz(vetorJogador, cartelaPorJogador);

do
{
    numAtual = SortearNumero(vetorSorteio);
    ImprimirNumero(numAtual);
    rodarVetor(numAtual, vetorJogador);
    PosibilidadePontuar(vetorJogador);
    ImprimirVetorMatriz(vetorJogador, cartelaPorJogador);

    Console.ReadKey();
} while (true);

