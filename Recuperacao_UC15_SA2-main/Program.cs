using Recuperacao_UC15_SA2.Classes;

string? opcao;

do
{
    Console.Clear();
    
    Console.WriteLine(@"

        1 - cadastrar PJ
        2 - Listar PJ
        0 - Sair

    ");

    opcao = Console.ReadLine();

    PessoaJuridica metodosPj = new PessoaJuridica();

    switch (opcao)
    {
        case "0":
            break;

        case "1":

            PessoaJuridica pj = new PessoaJuridica();

            Console.WriteLine("Informe o nome PJ: ");
            pj.Nome = Console.ReadLine();

            Console.WriteLine("Informe o rendimento: ");
            pj.Rendimento = float.Parse(Console.ReadLine()!);

            bool valido;

            do
            {
                Console.WriteLine("Informe um CNPJ válido (ex: xx.xxx.xxx/0001-xx): ");
                pj.cnpj = Console.ReadLine();

                valido = metodosPj.ValidarCnpj(pj.cnpj!);



            } while (valido == false);

            metodosPj.Inserir(pj);

            Console.WriteLine($"Cadastro realizado com sucesso!");
            Console.WriteLine($"Pressione Entre para continuar...");
            Console.ReadLine();

            break;
        
        case "2":

            Console.WriteLine($"Digite o nome do arquivo que deseja ler: ");
            string nomeArquivo = Console.ReadLine()!;

            PessoaJuridica pessoaJuridica = metodosPj.Ler(nomeArquivo);

            Console.WriteLine(@$"

                Nome: {pessoaJuridica.Nome}
                Rendimento: {pessoaJuridica.Rendimento}
                CNPJ: {pessoaJuridica.cnpj}

            ");

            Console.WriteLine($"Pressione Enter para continuar...");
            Console.ReadLine();

            break;


        default:
            Console.WriteLine("Opção Invalida!");
            Console.WriteLine("Pressione Enter para continuar");
            Console.ReadLine();
            break;
    }
     

} while (opcao != "0");