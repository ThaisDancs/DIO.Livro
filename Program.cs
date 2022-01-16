namespace DIO.Livros
{
    class Program
    {
        static LivroRepositorio repositorio = new LivroRepositorio();
        static void Main(string[] args)
        {	
			Console.Clear();
			
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarLivro();
						break;
					case "2":
						InserirLivro();
						break;
					case "3":
						AtualizarLivro();
						break;
					case "4":
						ExcluirLivro();
						break;
					case "5":
						VisualizarLivro();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

		private static void VisualizarLivro()
		{
			Console.Write("Digite o id do livro: ");

			int indiceLivro = int.Parse(Console.ReadLine());
			
			var livro = repositorio.RetornaPorId(indiceLivro);

			Console.WriteLine(livro);
		}
		private static void ExcluirLivro()
		{
			Console.Write("Digite o id do livro: ");
			int indiceLivro = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceLivro);
		}
		private static void AtualizarLivro()
		{
			Console.Write("Digite o id do Livro: ");
			int indiceLivro = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Departamento)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Departamento), i));
			}
			Console.Write("Digite o Departamento entre as opções acima: ");
			int entradaDepartamento = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Livro: ");
			string? entradaTitulo = Console.ReadLine();
		
			Console.Write("Digite o Ano do Livro: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Livro: ");
			string? entradaDescricao = Console.ReadLine();

			Livro atualizaLivro = new Livro(id: indiceLivro,
										departamento: (Departamento)entradaDepartamento,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceLivro, atualizaLivro);
		}

		private static void ListarLivro()
		{
			Console.WriteLine("Listar livros");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum livro cadastrado.");
				return;
			}

			foreach (var livro in lista)
			{
                var excluido = livro.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", livro.retornaId(), livro.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

		private static void InserirLivro()
		{
			Console.WriteLine("Inserir novo livro");

			foreach (int i in Enum.GetValues(typeof(Departamento)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Departamento), i));
			}
			Console.Write("Digite o departamento entre as opções acima: ");
			int? entradaDepartamento = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Livro: ");
			string? entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano do Livro: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Livro: ");
			string? entradaDescricao = Console.ReadLine();

			Livro novaLivro = new Livro(id: repositorio.ProximoId(),
										departamento: (Departamento)entradaDepartamento,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaLivro);
		}


		private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Livros a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar livros");
			Console.WriteLine("2- Inserir novo livro");
			Console.WriteLine("3- Atualizar livro");
			Console.WriteLine("4- Excluir livro");
			Console.WriteLine("5- Visualizar livro");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario  = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;

            
		}  
        
    }
}