using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();   

        static void Main(string[] args)
        {

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por usar nossos serviços!");
            Console.ReadLine();
            
        }

        public static void ListarSeries()
        {
            var lista = repository.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }
            Console.WriteLine(lista.Count);

            foreach (var serie in lista)
            {
                Console.WriteLine($"#ID {serie.RetornaId()}: - {serie.RetornaTitulo()}");
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            Serie serie = ObterSerie(repository.ProximoId());
            repository.Insere(serie);
        }

        private static void AtualizarSerie()
        {
            int id = ObterId();
            Serie serieAtualizada = ObterSerie(id);
            repository.Atualiza(id, serieAtualizada);
        }

        private static void ExcluirSerie()
        {
            repository.Exclui(ObterId());
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine(repository.RetornoPorId(ObterId()));
        }

        private static int ObterId()
        {
            Console.Write("Digite o id da série: ");
            return int.Parse(Console.ReadLine());
        }

        private static Serie ObterSerie(int id)
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i}-{Enum.GetName(typeof(Genero), i)}");
            }

            Console.Write("Digite o genêro entre as opções acima: ");
            int genero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite o ano de lançamento da série: ");
            int ano = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string descricao = Console.ReadLine();

            return new Serie(id, (Genero)genero, titulo, descricao, ano);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries ao seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario.ToUpper();
        }
    }
}
