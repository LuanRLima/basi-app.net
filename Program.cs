using   System;
using DIO.Series.Classes;
using DIO.Series.Enum;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {   
            string opcaoUsuario = ObeterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
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
                        // Console.Clear();
                        break;    
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObeterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por usar nosso sistema");
            Console.ReadLine();
            {
                 
            }
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Lista de Series");
            Console.WriteLine("----------------");
            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma serie cadastrada");
            }
            else
            {
                foreach (var serie in lista)
                {
                    var excluido = serie.retornaExcluído();
                    Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "Excluído" : ""));
                }
            }
        }   
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir Série");
            Console.WriteLine("----------------");
            foreach(int i in Genero.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Genero.GetName(typeof(Genero), i));
            }
            System.Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o título da Série: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Digite o Ano de Inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie serie = new Serie(id: repositorio.ProximoId(),
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno, 
                                    descricao: entradaDescricao);
            repositorio.Insere(serie);                        
                                    
        }
        private static void AtualizarSerie()
        {
            System.Console.WriteLine( "Atualizar Série");
            System.Console.WriteLine("----------------");
            int indiceSerie = int.Parse(Console.ReadLine());
            foreach(int i in Genero.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Genero.GetName(typeof(Genero), i));
            }
            System.Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o título da Série: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Digite o Ano de Inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie serie = new Serie(id: indiceSerie,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno, 
                                    descricao: entradaDescricao);
            repositorio.Atualiza(indiceSerie, serie);
        }
        private static void ExcluirSerie()
        {
            System.Console.WriteLine("Excluir Série");
            System.Console.WriteLine("----------------");
            System.Console.WriteLine("Digite o ID da Série que deseja excluir: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            repositorio.Exclui(indiceSerie);
        }
        private static void VisualizarSerie()
        {
            System.Console.WriteLine("Visualizar Série");
            System.Console.WriteLine("----------------");
            System.Console.WriteLine("Digite o ID da Série que deseja visualizar: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            Serie serie = repositorio.RetornaPorId(indiceSerie);
            System.Console.WriteLine("ID: {0} - {1}", serie.retornaId(), serie);
         
        }
        private static string ObeterOpcaoUsuario()
           {    
                System.Console.WriteLine();
                System.Console.WriteLine("DIO Series a seu dispor!!!");
                Console.WriteLine("Digite a opção desejada:");
                Console.WriteLine("1 - Listar Series");
                Console.WriteLine("2 - Inserir nova serie");
                Console.WriteLine("3 - Atualizar serie");
                Console.WriteLine("4 - Excluir serie");
                System.Console.WriteLine("5 - Visualizar serie");
                Console.WriteLine("X - Sair");
                System.Console.WriteLine();
                string opcaoUsuario = System.Console.ReadLine().ToUpper();
                System.Console.WriteLine();
                return opcaoUsuario;
           } 
    }
}            

