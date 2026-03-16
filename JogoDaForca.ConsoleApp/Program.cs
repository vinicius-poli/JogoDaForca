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

            while (jogadorAcertouPalavra == false)
            {
                Console.WriteLine(letrasAcertadas);

                Console.Write("Digite uma letra: ");
                string? strLetra = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(strLetra))
                {
                    Console.WriteLine("Digite um caractere válido!");
                    Console.ReadLine();
                    continue;
                }

                char letraChute = Convert.ToChar(strLetra.ToUpper());

                for (int contador = 0; contador < palavraAleatoria.Length; contador++)
                {
                    char letraAtual = palavraAleatoria[contador];
                    
                    if (letraChute == letraAtual)
                    {
                        letrasAcertadas[contador] = letraAtual;
                    }
                }

                jogadorAcertouPalavra = palavraAleatoria == string.Join("", letrasAcertadas);
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

