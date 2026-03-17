using System.Security.Cryptography;
using System.Threading.Tasks.Dataflow;

namespace JogoDaForca.ConsoleApp;
class Program
{ 
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("Jogo da Forca");
            Console.WriteLine("-----------------------");

            //Lógica do Jogo da Forca

            string palavraAleatoria = EscolherPalavraAleatoria();

            Console.WriteLine(palavraAleatoria);

            char[] letrasAcertadas = new char[palavraAleatoria.Length];

            for (int caractere = 0; caractere < letrasAcertadas.Length; caractere++)
            {
                letrasAcertadas[caractere] = '_';
            }

            bool jogadorAcertouPalavra = false;
            bool jogadorPerdeu = false;

            int quantidadeErros = 0;               

            while (jogadorAcertouPalavra == false && jogadorPerdeu == false) 
            {
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

            Console.Write("Deseja continuar o jogo? (S/N) ");
            string? opcaoContinuar = Console.ReadLine();

            if (opcaoContinuar?.ToUpper() != "S")
                break;
        }
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
    
}

