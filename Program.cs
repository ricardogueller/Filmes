using System;

namespace DIO.Filmes
{
    class Program
    {
        static FilmesRepositorio repositorio = new FilmesRepositorio();

        //Lista de opções do menu principal********************************************************
        static void Main(string[] args)
        {
            Console.WriteLine("Digite a opção desejada:");
            Console.WriteLine("1- Adicionar novo Filme");
            Console.WriteLine("2- Listar Filmes");
            Console.WriteLine("3- Excluir Filmes");
            Console.WriteLine("4- Atualizar Filme");
            Console.WriteLine("5- Informações sobre o filme");
            Console.WriteLine("X- Sair");

            string OpcaoDesejada = Console.ReadLine();
            Console.WriteLine();

            while (OpcaoDesejada.ToUpper() != "X")
            {
                switch (OpcaoDesejada)
                {
                    case "1":
                        InserirFilme();
                    break;
                        
                    case "2":
                        ListarFilmes();
                    break;

                    case "3":
                        ExcluirFilme();
                    break;

                    case "4":
                        AtualizarFilme();
                    break;
                        
                    default:
                        throw new ArgumentOutOfRangeException("Digite uma opção válida");

                }
                Console.WriteLine();
                Console.WriteLine("Digite a opção desejada:");
                Console.WriteLine("1- Adicionar novo Filme");
                Console.WriteLine("2- Listar filmes");
                Console.WriteLine("3- Excluir Filmes");
                Console.WriteLine("4- Atualizar Filme");
                Console.WriteLine("X- Sair");

                OpcaoDesejada = Console.ReadLine();
            }


        }

        //Ações do menu principal*******************************************************************
        private static void AtualizarFilme()
        {
            Console.WriteLine("Digite o ID do filme que deseja atualizar:");
            var lista = repositorio.Lista();
            foreach (var filme in lista)
            {
                var excluido = filme.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2} \nDescrição: {3} \nAno de lançamento: {4}\n", 
                                 filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluido*" : ""),
                                 filme.retornaDescricao(),
                                 filme.retornaAno());
            }                     

            int selecionaFilme = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Qual informação do filme deseja atualizar");
            Console.WriteLine("1- Titulo");
            Console.WriteLine("2- Descrição");
            Console.WriteLine("3- Genêro");
            Console.WriteLine("4- Ano");
            Console.WriteLine("X- Voltar ao menu principal");

            string OpcaoDesejada = Console.ReadLine();
            Console.WriteLine();

            while (OpcaoDesejada.ToUpper() != "X")
            {
                switch (OpcaoDesejada)
                {
                    case "1":
                    {
                        var filmeSelecionado = repositorio.Lista();

                        Console.WriteLine("Digite o titulo do filme:");
                        string entradaTitulo = Console.ReadLine();

                        filmeSelecionado[selecionaFilme].Titulo = entradaTitulo;
                    }
                    return;
                        
                    case "2":
                    {
                        var filmeSelecionado = repositorio.Lista();
                        Console.WriteLine("Digite a descrição do filme:");
                        string entradaDescricao = Console.ReadLine();

                        filmeSelecionado[selecionaFilme].Descricao = entradaDescricao;
                    }
                    return;

                    case "3":
                    {
                        var filmeSelecionado = repositorio.Lista();
                        foreach (int i in Enum.GetValues(typeof(Genero)))
                        {
                            Console.WriteLine("{0} -- {1}", i, Enum.GetName(typeof(Genero), i));
                        }
                        Console.WriteLine("Qual dos generos acima o filme pertence:");
                        int entradaGenero = int.Parse(Console.ReadLine());

                        filmeSelecionado[selecionaFilme].Genero = (Genero) entradaGenero;
                    }
                    return;

                    case "4":
                        {
                            var filmeSelecionado = repositorio.Lista();
                            Console.WriteLine("Digite o ano de lançamento do filme:");
                            int entradaAno = int.Parse(Console.ReadLine());
                            
                            filmeSelecionado[selecionaFilme].Ano = entradaAno;

                        }
                    return;

                    case "X":
                    return; 

                    default:
                        throw new ArgumentOutOfRangeException("Digite uma opção válida");   
                }            
            }
        }

        private static void ExcluirFilme()
        {
            Console.WriteLine("Qual filme você deseja excluir?");
            var lista = repositorio.Lista();
            foreach (var filme in lista)
            {
                var excluido = filme.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2} \nDescrição: {3} \nAno de lançamento: {4}\n", 
                                 filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluido*" : ""),
                                 filme.retornaDescricao(),
                                 filme.retornaAno());
            }                     

            Console.WriteLine("Digite o ID do filme que deseja excluir:");
            int selecionaFilme = int.Parse(Console.ReadLine());

            repositorio.Exclui(selecionaFilme);
        }

        private static void ListarFilmes()
        {
            Console.WriteLine("Listar filmes");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum filme cadastrado");
                return;
            }

            foreach (var filme in lista)
            {
                var excluido = filme.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2} \nDescrição: {3} \nGenero: {4} \nAno de lançamento: {5}\n", 
                                 filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluido*" : ""),
                                 filme.retornaDescricao(),
                                 filme.retornaAno());                                
            }
        }

        private static void InserirFilme()
        {
            Console.WriteLine("Insira um novo filme");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Qual o genero do filme:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo do filme:");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite a descrição do filme:");
            string entradaDescricao = Console.ReadLine();

            Console.WriteLine("Digite o ano de lançamento do filme:");
            int entradaAno = int.Parse(Console.ReadLine());

            Filmes novoFilme = new Filmes(id: repositorio.ProximoId(),
                                          Genero: (Genero) entradaGenero,
                                          Titulo: entradaTitulo,
                                          Descricao: entradaDescricao,
                                          Ano: entradaAno);
            
            repositorio.Inserir(novoFilme);
        }
    }
}
