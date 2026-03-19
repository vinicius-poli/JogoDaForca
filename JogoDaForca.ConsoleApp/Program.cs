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
        int categoria = EscolherCategoria();
        
        while (true)
        {
            ExibirCabecalho();            

            string palavraAleatoria = EscolherPalavraAleatoria(categoria);

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

    static int EscolherCategoria()
    {   
        ExibirCabecalho();
        Console.WriteLine("Escolha uma categoria:");
        Console.WriteLine("1 - Frutas");
        Console.WriteLine("2 - Animais");
        Console.WriteLine("3 - Países");
        int categoriaEscolhida = Convert.ToInt32(Console.ReadLine());
        
        while (categoriaEscolhida != 1 && categoriaEscolhida != 2 && categoriaEscolhida != 3)
        {
            Console.WriteLine("Categoria Inválida!");
            Console.WriteLine("Escolha uma categoria:");
            Console.WriteLine("1 - Frutas");
            Console.WriteLine("2 - Animais");
            Console.WriteLine("3 - Países");
            categoriaEscolhida = Convert.ToInt32(Console.ReadLine());
        }
        
        return categoriaEscolhida;
    }
   
    static int OpcaoPalavraInteira()
    {
        Console.WriteLine("Deseja tentar auma letra ou a palavra INTEIRA?");
        Console.WriteLine("1- Letra");
        Console.WriteLine("2- Palavra Inteira");
        int opcaoLetraPalavra = Convert.ToInt32(Console.ReadLine());

        while (opcaoLetraPalavra != 1 && opcaoLetraPalavra != 2)
        {
            Console.WriteLine("Digite uma opção válida!");
            opcaoLetraPalavra = Convert.ToInt32(Console.ReadLine());
        }

        return opcaoLetraPalavra;
    }

    static string EscolherPalavraAleatoria(int categoriaEscolhida)
    {
        Console.WriteLine("Escolhendo palavra aleatória...");

        string[] palavras;

        if (categoriaEscolhida == 1)
        {
            palavras = [ 
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
            "UVAIA" ];
        }

        else if (categoriaEscolhida == 2)
        {
            palavras = [
            "ÁGUIA",
            "BALEIA",
            "CACHORRO",
            "CANGURU",
            "CAVALO",
            "COELHO",
            "CORUJA",
            "CROCODILO",
            "ELEFANTE",
            "FALCÃO",
            "FOCA",
            "GALINHA",
            "GATO",
            "GIRAFA",
            "GORILA",
            "HIPOPÓTAMO",
            "JACARÉ",
            "LEÃO",
            "LOBO",
            "MACACO",
            "PANDA",
            "PATO",
            "PAVÃO",
            "PINGUIM",
            "RAPOSA",
            "RINOCERONTE",
            "TARTARUGA",
            "TIGRE",
            "URSO",
            "ZEBRA"
            ];
        }

        else
        {
            palavras = [
            "ALEMANHA",
            "ANGOLA",
            "ARGENTINA",
            "AUSTRÁLIA",
            "BÉLGICA",
            "BOLÍVIA",
            "BRASIL",
            "CANADÁ",
            "CHILE",
            "CHINA",
            "COLÔMBIA",
            "COREIA DO SUL",
            "CUBA",
            "EGITO",
            "ESPANHA",
            "ESTADOS UNIDOS",
            "FRANÇA",
            "ÍNDIA",
            "INDONÉSIA",
            "ITÁLIA",
            "JAPÃO",
            "MÉXICO",
            "NIGÉRIA",
            "NORUEGA",
            "PERU",
            "PORTUGAL",
            "REINO UNIDO",
            "RÚSSIA",
            "SUÉCIA",
            "SUÍÇA"
            ];
        }
        

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
        
        

        List<char> letrasTentadas = new List<char>();
        List<char> letrasErradas = new List<char>();               

        while (jogadorAcertouPalavra == false && jogadorPerdeu == false) 
        {
            DesenharForca(quantidadeErros);

            Console.WriteLine("Letras acertadas: " + string.Join("", letrasAcertadas));
            Console.WriteLine("Letras Erradas: " + string.Join(" ", letrasErradas));
            Console.WriteLine("Erros cometidos: " + quantidadeErros);

            int opcao = OpcaoPalavraInteira();

            if (opcao == 1)
            {
                Console.Write("Digite uma letra: ");
                string? strLetra = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(strLetra))
                {
                    Console.WriteLine("Digite um caractere válido!");
                    Console.ReadLine();
                    continue;
                }

                char letraChute = char.ToUpper(Convert.ToChar(strLetra));

                if (letrasTentadas.Contains(letraChute))
                {
                    Console.WriteLine("Você já tentou essa letra! Pressione ENTER para continuar.");
                    Console.ReadLine();
                    continue;
                }

                letrasTentadas.Add(letraChute);
                
                char letraChuteLimpa = RemoverAcentos(letraChute.ToString())[0];

                bool letraFoiEncontrada = false;

                for (int contador = 0; contador < palavraAleatoria.Length; contador++)
                {
                    char letraAtualOriginal = palavraAleatoria[contador];
                    char letraAtualLimpa = RemoverAcentos(letraAtualOriginal.ToString())[0];
                    
                    if (letraChuteLimpa == letraAtualLimpa)
                    {
                        letrasAcertadas[contador] = letraAtualOriginal;
                        letraFoiEncontrada = true;
                    }
                    
                }

                if (letraFoiEncontrada == false)
                {
                    letrasErradas.Add(letraChute);
                    quantidadeErros++;
                }
                                
                jogadorAcertouPalavra = palavraAleatoria == string.Join("", letrasAcertadas);
                
            }

            else
            {
                Console.Write("Digite a palavra inteira: ");
                string? strPalavra = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(strPalavra))
                {
                    Console.WriteLine("Digite uma palavra válida!");
                    Console.ReadLine();
                    continue;
                }

                string palavraChute = (strPalavra.ToUpper());

                if (palavraChute == palavraAleatoria)
                {
                    jogadorAcertouPalavra = true;
                }

                else
                {
                    quantidadeErros++;
                }
            }
            
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

    static string RemoverAcentos(string acento)
    {
        string formaNormalizada = acento.Normalize(System.Text.NormalizationForm.FormD);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        foreach (char c in formaNormalizada)
        {
            System.Globalization.UnicodeCategory categoria = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c);
            if (categoria != System.Globalization.UnicodeCategory.NonSpacingMark)
            {
                sb.Append(c);
            }
        }

        return sb.ToString().Normalize(System.Text.NormalizationForm.FormC);
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

