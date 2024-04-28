int numerosTotais = 99, aux = 0, verificacao = 0, qtd = 5, posicao = 0, numPessoas = 0, numAtual = 0, cartelaPorJogador;
int qtdLinhaColuna = 5, numeroSorteado = 0, indice = 0, tamanhoVetorPessoasCartelas = 0, numPorPessoa = 0, NumRodada = 0, qtdJogador;
bool possibilidadeLinha = true, possibilidadeColuna = true, possibilidadeCartela = true, possibilidade = true;
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
        aux = new Random().Next(1, 100);
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
    Console.ResetColor();
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
        aux = new Random().Next(1, 100);
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
    return NumLinhaColuna;
}

// IMPRIMIR
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
            {
                Console.Write($"|");
                if (matriz[indexVetor][linha, coluna] == 0)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;                    
                    Console.Write($" {matriz[indexVetor][linha, coluna].ToString("D3")} ");
                    Console.ResetColor();
                    Console.Write($"|");
                }
                else
                    Console.Write($" {matriz[indexVetor][linha, coluna].ToString("D3")} |");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
void ImprimirBingo()
{
    Console.WriteLine("  *****    ***   *    *   *****     ****   ");
    Console.WriteLine("  *    *    *    **   *   *        *    *  ");
    Console.WriteLine("  *****     *    * *  *   *  ***   *    *  ");
    Console.WriteLine("  *    *    *    *  * *   *    *   *    *  ");
    Console.WriteLine("  *****    ***   *    *   ******    ****   ");
}
// CHECAR
int IdentificarPessoa(int indicePessoa)
{
    int pessoa = (indicePessoa / cartelaPorJogador) + 1;
    return pessoa;
}
int[] ChecarCartelaParaPontuar(int[][,] cartela, int[] pontos)
{
    int[] checarLinha = CriarVetor(tamanhoVetorPessoasCartelas);
    int[] checarColuna = CriarVetor(tamanhoVetorPessoasCartelas);
    int[] checarCartela = CriarVetor(tamanhoVetorPessoasCartelas);

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
                checarLinha[x] = 1;
            if (verificacaoColuna == qtdLinhaColuna)
                checarColuna[x] = 1;
            if (verificacaoTotal == qtdLinhaColuna * qtdLinhaColuna)
                checarCartela[x] = 1;
        }
    }
    if (possibilidadeLinha == true)
        Pontuar(checarLinha, 1, "PREENCHEU LINHA", pontos);
    if (possibilidadeColuna == true)
        Pontuar(checarColuna, 2, "PREENCHEU COLUNA", pontos);
    if (possibilidadeCartela == true)
        Pontuar(checarCartela, 3, "BINGO!GANHOU!", pontos);
    return checar;
}
void Pontuar(int[] checar, int opcaoChecagem, string tipo, int[] pontos)
{
    int pessoa = 0;
    int verificou = 0;
    bool pessoaJaPontuou = false;
    int cartelas = cartelaPorJogador;

    for (int i = 0; i < tamanhoVetorPessoasCartelas; i++)
    {
        if (checar[i] == 1 && possibilidade == true)
        {
            pessoa = IdentificarPessoa(i);
            Console.WriteLine($"PESSOA {pessoa} {tipo}");
            MarcarPontuacaoTabela(pessoa, opcaoChecagem, pontos);
            verificou++;    
            i += (cartelaPorJogador - 1);            
        }
        if (verificou != 0)
        {
            switch (opcaoChecagem)
            {
                case 1:
                    possibilidadeLinha = false;
                    break;
                case 2:
                    possibilidadeColuna = false;
                    break;
                default:
                    possibilidadeCartela = false;
                    break;
            }
        }
    }
}
void MarcarPontuacaoTabela(int pessoa, int opcaoChecagem, int[] pontos)
{
    if (opcaoChecagem == 1 || opcaoChecagem == 2)
    {
        pontos[pessoa-1] = 1;
    }
    else
    {
        pontos[pessoa-1] = 5;
    }

}
// NUMEROS DE CARTELAS POR JOGADOR
int NumJogadorCartela(int jogadorCartela, int opcaoJogadorCartela)
{
    do
    {
        if ((jogadorCartela < 1 && opcaoJogadorCartela == 2) || (jogadorCartela < 3 && opcaoJogadorCartela == 1))
        {
            Console.WriteLine("Digite um número Valido!");
            jogadorCartela = int.Parse(Console.ReadLine());
        }

    } while ((jogadorCartela < 1 && opcaoJogadorCartela == 2) || (jogadorCartela < 3 && opcaoJogadorCartela == 1));
    return jogadorCartela;
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
int[][,] rodarVetor(int num, int[][,] vetorJogador)
{
    for (int i = 0; i < tamanhoVetorPessoasCartelas; i++)
    {
        int[,] cartela = vetorJogador[i];
        ChecarNumSorteado(num, cartela);
    }
    return null;
}

// MAIN 
int[] vetorSorteio = CriarVetor(numerosTotais + 1);
ImprimirBingo();

Console.WriteLine("Digite um número de jogadores:");
qtdJogador = NumJogadorCartela(int.Parse(Console.ReadLine()), 1);

Console.WriteLine("Digite um número de tabela por jogador:");
cartelaPorJogador = NumJogadorCartela(int.Parse(Console.ReadLine()), 2);

int[][,] vetorJogador = GerarVetorJogador(qtdJogador, cartelaPorJogador);
ImprimirVetorMatriz(vetorJogador, cartelaPorJogador);

int[] vetorPontos = CriarVetor(qtdJogador);
Console.ReadKey();
Console.Clear();
do
{
    ImprimirBingo();
    numAtual = SortearNumero(vetorSorteio);
    ImprimirNumero(numAtual);
    rodarVetor(numAtual, vetorJogador);
    ChecarCartelaParaPontuar(vetorJogador, vetorPontos);
    ImprimirVetorMatriz(vetorJogador, cartelaPorJogador);
    NumRodada++;
    Console.ReadKey();
    Console.Clear();
} while (possibilidadeCartela != false);


for (int i = 0; i < qtdJogador; i++)
{
    int identificar = IdentificarPessoa(i);
    int pontos = vetorPontos[i];
    Console.WriteLine($"{identificar} FEZ {vetorPontos[i]} PONTOS;");

}

