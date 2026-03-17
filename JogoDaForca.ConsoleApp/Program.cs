using System.Security.Cryptography;

namespace JogoDaForca.ConsoleApp;

/*
Requisitos
    1. Ao iniciar o jogo, deve ser selecionada uma palavra aleatória à partir de uma lista.
    2. O jogador poderá chutar a palavra secreta letra por letra, cada letra certa deverá ser apresentada,
    assim como as letras erradas.
    3. O jogador poderá cometer até cinco erros, caso erre pela quinta vez, ou acerte a palavra a partida
    acaba.
    4. Deve-se apresentar um desenho da forca sendo atualizado a cada erro.
*/

class Program
{ 
    static void Main(string[] args)
    {
        while (true)
        {
            ExibirCabecalho();            

            string palavraAleatoria = EscolherPalavraAleatoria();

            char[] letrasAcertadas = PreencherLetrasAcertadas(palavraAleatoria);
            
            ExecutarTentativas(letrasAcertadas, palavraAleatoria);         
            
            if (JogadorDesejaContinuar() == false)
                break;              
        }
    }

    static void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("-----------------------");
        Console.WriteLine("Jogo da Forca");
        Console.WriteLine("-----------------------");
    }
     
    static string EscolherPalavraAleatoria()
    {
        Console.WriteLine("Escolhendo palavra aleatória...");

        string[] palavras = [
            "ABACATE",
            "ABACAXI",
            "ACEROLA",
            "AÇAÍ",
            "ARAÇÁ",
            "ABACATE",
            "BACABA",
            "BACURI",
            "BANANA",
            "CAJÁ",
            "CAJU",
            "CARAMBOLA",
            "CUPUAÇU",
            "GRAVIOLA",
            "GOIABA",
            "JABUTICABA",
            "JENIPAPO",
            "MAÇÃ",
            "MANGABA",
            "MANGA",
            "MARACUJÁ",
            "MURICI",
            "PEQUI",
            "PITANGA",
            "PITAYA",
            "SAPOTI",
            "TANGERINA",
            "UMBU",
            "UVA",
            "UVAIA"
        ];

        int indiceAleatorio = RandomNumberGenerator.GetInt32(palavras.Length);

        string palavraAleatoria = palavras[indiceAleatorio];

        return palavraAleatoria;
        
    }
    
    static char[] PreencherLetrasAcertadas(string palavraAleatoria)
    {
        char[] letrasAcertadas = new char[palavraAleatoria.Length];

        for (int caractere = 0; caractere < letrasAcertadas.Length; caractere++)
        {
            letrasAcertadas[caractere] = '_';
        }

        return letrasAcertadas;
    }

    static void ExecutarTentativas(char[] letrasAcertadas, string palavraAleatoria)
    {
        bool jogadorAcertouPalavra = false;
        bool jogadorPerdeu = false;

        int quantidadeErros = 0;               

        while (jogadorAcertouPalavra == false && jogadorPerdeu == false) 
        {

            DesenharForca(quantidadeErros);

            Console.WriteLine("Letras acertadas: " + string.Join("", letrasAcertadas));
            Console.WriteLine("Erros cometidos: " + quantidadeErros);

            Console.Write("Digite uma letra: ");
            string? strLetra = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(strLetra))
            {
                Console.WriteLine("Digite um caractere válido!");
                Console.ReadLine();
                continue;
            }

            char letraChute = char.ToUpper(Convert.ToChar(strLetra));

            bool letraFoiEncontrada = false;

            for (int contador = 0; contador < palavraAleatoria.Length; contador++)
            {
                char letraAtual = palavraAleatoria[contador];
                
                if (letraChute == letraAtual)
                {
                    letrasAcertadas[contador] = letraAtual;
                    letraFoiEncontrada = true;
                }                    
            }

            if (letraFoiEncontrada == false)
                quantidadeErros++;
                
            jogadorAcertouPalavra = palavraAleatoria == string.Join("", letrasAcertadas);
            jogadorPerdeu = quantidadeErros > 5;

            if (jogadorAcertouPalavra)
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine($"Você acertou!! A palavra secreta era {palavraAleatoria}.");
                Console.WriteLine("-----------------------");
            }

            else if (jogadorPerdeu)
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine("Que azar! Tente novamente!");
                Console.WriteLine("-----------------------");
            }
        }
        
    }

    static void DesenharForca(int quantidadeErros)
    {
        Console.Clear();
        Console.WriteLine("-----------------------");
        Console.WriteLine("Jogo da Forca");
        Console.WriteLine("-----------------------");

        if (quantidadeErros == 0)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }

        else if (quantidadeErros == 1)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }

        else if (quantidadeErros == 2)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |         |        ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }

        else if (quantidadeErros == 3)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |        /|        ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }

        else if (quantidadeErros == 4)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |        /|\       ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }

        else if (quantidadeErros == 5)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |        /|\       ");
            Console.WriteLine(@" |        / \       ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }

        Console.WriteLine("-----------------------");        
    }

    static bool JogadorDesejaContinuar()
    {
        Console.Write("Deseja continuar o jogo? (S/N) ");
        string? opcaoContinuar = Console.ReadLine();
        if (opcaoContinuar?.ToUpper() != "S")
            return false;

        return true;
    }

}

