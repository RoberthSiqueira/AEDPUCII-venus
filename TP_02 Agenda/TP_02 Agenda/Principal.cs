using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AED;
using TP_02_Agenda;
using System.IO;
using System.Threading.Tasks;

namespace TP_02_Agenda
{
    class Principal
    {
        //Implementação do MENU
        static void Menu()
        {
            int opcao;
            CLista Agenda = new CLista();
            Contato CarregaContato = new Contato();
            Contato Contact = new Contato();
            StreamReader carrega_agenda = new StreamReader("Agenda.txt"); // instancia objeto para ler arquivo
            string linha = carrega_agenda.ReadLine();
            string[] Vetor = new string[19]; // Qt De atributos

            while (linha != null) // Enquanto tiver linhas no arquivo irá carregar os contatoss
            {
                
                Vetor = linha.Split(';'); // A cada atributo entre ';' se torna uma posição do array
                
                // Conversão de atributos de tipos numéricos
                int tipo = int.Parse(Vetor[0]);
                int endNumero = int.Parse(Vetor[11]);
                long endCep = int.Parse(Vetor[15]);
                int aniver_dia = int.Parse(Vetor[16]);
                int aniver_mes = int.Parse(Vetor[17]);
                int aniver_ano = int.Parse(Vetor[18]);

                //Atribuição do que está contido na posição do array para determinado atributo do Contato
                CarregaContato.tipo = tipo;
                CarregaContato.nome = Vetor[1];
                CarregaContato.nickname = Vetor[2];
                CarregaContato.empresa = Vetor[3];
                CarregaContato.cargo = Vetor[4];
                CarregaContato.celular = Vetor[5];
                CarregaContato.telefone_resid = Vetor[6];
                CarregaContato.telefone_comer = Vetor[7];
                CarregaContato.email = Vetor[8];
                CarregaContato.twitter = Vetor[9];
                CarregaContato.endereco.tipo_logradouro = Vetor[10];
                CarregaContato.endereco.numero = endNumero;
                CarregaContato.endereco.bairro = Vetor[12];
                CarregaContato.endereco.cidade = Vetor[13];
                CarregaContato.endereco.estado = Vetor[14];
                CarregaContato.endereco.cep = endCep;
                CarregaContato.aniversario_dia = aniver_dia;
                CarregaContato.aniversario_mes = aniver_mes;
                CarregaContato.aniversario_ano = aniver_ano;

                Agenda.InsereFim(CarregaContato);
                CarregaContato = new Contato();// Cada contato é inserido no fim da lista
                linha = carrega_agenda.ReadLine(); //Lê a linha do arquivo
            }
            carrega_agenda.Close(); //Fecha arquivo

            //Criação do Menu Principal
            #region Menu e controle do sistema
            do
            {
                Console.Clear();
                Console.WriteLine("|=================================================================|");
                Console.WriteLine("|========================= MENU PRINCIPAL ========================|");
                Console.WriteLine("|=================================================================|");
                Console.WriteLine("| 1 – Cadastrar contato                                           |");
                Console.WriteLine("| 2 – Remover contato                                             |");
                Console.WriteLine("| 3 – Alterar dados do contato (Todos os Contatos)                |");
                Console.WriteLine("| 4 – Pesquisar contato (Por nome ou apelido)                     |");
                Console.WriteLine("| 5 – Listar contatos por tipo                                    |");
                Console.WriteLine("| 6 – Listar todos os contatos                                    |");
                Console.WriteLine("| 7 - Listar aniversariantes do mês                               |");
                Console.WriteLine("| 8 – Sair                                                        |");
                Console.WriteLine("===================================================================");
                Console.Write("\n\n Qual a opção desejada ? ");
                opcao = int.Parse(Console.ReadLine());
                //Limpando a Tela
                Console.Clear();

                //Implementando as opções
                switch (opcao)
                {
                    //Menu 01 
                    #region Cadastrar Contato
                    case 1:

                        //Limpando Tela
                        Console.Clear();
                        Contato Cadastro = new Contato();
                        int tipoContato; // Recebe tipo do Contato
                        bool tipoProfissional = false; // Realizar controle do tipo de Contato

                        //Cadastrando o Contato
                        do
                        {
                            Console.Write("Tipo (1- Pessoal / 2- Profissional): ");
                            tipoContato = int.Parse(Console.ReadLine());
                            if (tipoContato == 2)
                                tipoProfissional = true;
                            Cadastro.tipo = tipoContato;

                        } while (!(tipoContato == 1 || tipoContato == 2));

                        Console.Write("Nome: ");
                        Cadastro.nome = Console.ReadLine();

                        Console.Write("Nickname: ");
                        Cadastro.nickname = Console.ReadLine();

                        if (tipoProfissional == true)
                        {
                            Console.Write("Empresa: ");
                            Cadastro.empresa = Console.ReadLine();

                            Console.Write("Cargo: ");
                            Cadastro.cargo = Console.ReadLine();
                        }

                        Console.Write("Celular: ");
                        Cadastro.celular = Console.ReadLine();

                        Console.Write("Telefone Residencial: ");
                        Cadastro.telefone_resid = Console.ReadLine();

                        Console.Write("Telefone Comercial: ");
                        Cadastro.telefone_comer = Console.ReadLine();

                        Console.Write("E-mail: ");
                        Cadastro.email = Console.ReadLine();

                        Console.Write("Twitter: ");
                        Cadastro.twitter = Console.ReadLine();

                        Console.Write("Tipo do logradouro (Rua/Av): ");
                        Cadastro.endereco.tipo_logradouro = Console.ReadLine();

                        Console.Write("Número: ");
                        Cadastro.endereco.numero = int.Parse(Console.ReadLine());

                        Console.Write("Bairro: ");
                        Cadastro.endereco.bairro = Console.ReadLine();

                        Console.Write("Cidade: ");
                        Cadastro.endereco.cidade = Console.ReadLine();

                        Console.Write("Estado: ");
                        Cadastro.endereco.estado = Console.ReadLine();

                        Console.Write("CEP: ");
                        Cadastro.endereco.cep = long.Parse(Console.ReadLine());

                        Console.Write("Aniversario - Ano: ");
                        Cadastro.aniversario_ano = int.Parse(Console.ReadLine());
                        while (Cadastro.aniversario_ano > 2015 && Cadastro.aniversario_ano > 1)
                        {
                            Console.Write("Favor Digitar um ano válido! Aniversario - Ano: ");
                            Cadastro.aniversario_ano = int.Parse(Console.ReadLine());
                        }

                        Console.Write("Aniversario - Mês: ");
                        Cadastro.aniversario_mes = int.Parse(Console.ReadLine());
                        while (Cadastro.aniversario_mes < 1 || Cadastro.aniversario_mes > 12)
                        {
                            Console.Write("Favor Digitar um mês válido! Aniversario - Mês: ");
                            Cadastro.aniversario_mes = int.Parse(Console.ReadLine());
                        }

                        Console.Write("Aniversario - Dia: ");
                        Cadastro.aniversario_dia = int.Parse(Console.ReadLine());
                        while (Cadastro.aniversario_dia > 31 || Cadastro.aniversario_dia < 1)
                        {
                            Console.Write("Favor Digitar um dia válido! Aniversario - Dia: ");
                            Cadastro.aniversario_dia = int.Parse(Console.ReadLine());
                        }
                        if ((Cadastro.aniversario_mes == 4 || Cadastro.aniversario_mes == 6 || Cadastro.aniversario_mes == 9 || Cadastro.aniversario_mes == 11) && (Cadastro.aniversario_dia >= 31))
                        {
                            Console.Write("Favor Digitar um dia válido! Aniversario - Dia: ");
                            Cadastro.aniversario_dia = int.Parse(Console.ReadLine());
                        }
                        else if ((Cadastro.aniversario_mes == 2) || (Cadastro.aniversario_dia >= 29))
                        {
                            Console.Write("Favor Digitar um dia válido! Aniversario - Dia: ");
                            Cadastro.aniversario_dia = int.Parse(Console.ReadLine());
                        }

                        Agenda.InsereComeco(Cadastro);
                        Cadastro = new Contato();
                        //Inserindo contato na CLista
                        Console.Write("\nContato cadastrado com sucesso!");
                        Console.ReadKey();

                        break;
                    #endregion
                    // Fim cadastro de contato

                    //Menu 02 
                    #region Remover Contato, pelo nome
                    case 2:
                        //Limpando Tela
                        Console.Clear();

                        string nomeDeletar; // irá receber o nome a ser deletado
                        Console.Write("Informe o nome do contato que deseja excluir: ");
                        nomeDeletar = Console.ReadLine();
                        Contact.DeletaContato(Agenda, nomeDeletar); // Chama método da classe Contato para exclusão
                        Console.ReadKey();

                        break;
                    #endregion
                    // Fim remoção de contato

                    //Menu 03
                    #region Alteração Contato
                    //Menu 03
                    case 3:
                        Console.Clear();

                        Console.Write("Qual contato você deseja alterar? ");
                        string nomeAlterar = Console.ReadLine();
                        Contact.AlterarContato(Agenda, nomeAlterar);

                        break;
                    // Fim remoção de contato
                    #endregion
                    // Fim da alteração

                    //Menu 04
                    #region Pesquisar contato, pelo nome ou pelo apelido
                    case 4:
                        //Limpando Tela
                        Console.Clear();

                        string nomePesquisar; // irá receber o nome a ser pesquisar
                        string apelidoPesquisar; // irá receber o apelido a ser pesquisar
                        int flag = 0;

                        do
                        {
                            Console.Write("Como deseja pesquisar o contato?"
                                        + "\n(1- Nome / 2 - Apelido): ");
                            flag = int.Parse(Console.ReadLine());
                        } while (!(flag == 1 || flag == 2));

                        if (flag == 1)
                        {
                            Console.Write("Informe o nome do contato que deseja pesquisar: ");
                            nomePesquisar = Console.ReadLine();
                            Contact.PesquisaNome(Agenda, nomePesquisar); // chama metódo que irá realizar pesquisa
                        }
                        else
                        {
                            Console.Write("Informe o apelido do contato que deseja pesquisar: ");
                            apelidoPesquisar = Console.ReadLine();
                            Contact.PesquisaApelido(Agenda, apelidoPesquisar); // chama metódo que irá realizar pesquisa
                        }
                        Console.ReadKey();

                        break;
                    #endregion
                    // Fim pesquisa

                    //Menu 05
                    #region Listar contatos por tipo
                    case 5:
                        //Limpando Tela
                        Console.Clear();

                        do
                        {
                            Console.Write("Qual tipo de contato deseja listar?"
                                        + "\n(1- Pessoal / 2 - Profissional): ");
                            flag = int.Parse(Console.ReadLine());
                        } while (flag >= 3);

                        Contact.ListarContatosPorTipo(Agenda, flag); // chama metódo que irá realizar pesquisa
                        Console.ReadKey();

                        break;
                    #endregion
                    //Fim da Listagem por Tipo

                    //Menu 06
                    #region Listar todos os contatos
                    case 6:
                        Console.Clear();
                        Contact.ListarTodosContatos(Agenda);
                        Console.ReadKey();
                        break;
                    #endregion
                    //Fim da Listagem

                    //Menu 07
                    #region Listar aniversario
                    case 7:
                        // Limpar tela
                        Console.Clear();

                        int mes = 0;
                        Console.Write("Informe o mês que deseja saber a lista de aniversariantes: ");
                        mes = int.Parse(Console.ReadLine());

                        if (mes >= 1 && mes <= 12)
                            Contact.ListarAniversariantes(Agenda, mes);

                        Console.ReadKey();
                        break;
                    #endregion
                    //Fim da listagem de aniversariantes

                    //Menu 08
                    #region Sair e salvar todo o conteúdo no arquivo
                    //Sair
                    case 8:

                        //Escrever no arquivo o conteúdo da memória
                        StreamWriter escreve_agenda = new StreamWriter("Agenda.txt"); // instancia objeto para escrever arquivo
                        for (int i = 1; i <= Agenda.Quantidade(); i++)
                        {
                            Contact = (Contato)Agenda.RetornaIndice(i); //retorna contato no índice determinado
                            escreve_agenda.WriteLine(Contact.SalvarNoArquivo(Contact));
                        }
                        escreve_agenda.Close(); //Fecha arquivo

                        Console.WriteLine("|=================================================================|");
                        Console.WriteLine("|     Obrigado por utilizar meu sistema de agenda eletrônica!     |");
                        Console.WriteLine("|                                                                 |");
                        Console.WriteLine("|     Copyright©   -   Fellipe Couto & Roberth Siqueira           |");
                        Console.WriteLine("|=================================================================|");
                        break;
                    #endregion
                    //Sair

                    //Default
                    #region Opção invalida
                    //Opção Invalida!
                    default:
                        Console.Write("Opção Invalida! \n\n");
                        break;
                    #endregion
                    //Fim Default, Opção Inválida!
                }

            } while (opcao != 8);

            #endregion
            //Fim menu
        }

        static void Main(string[] args)
        {
            Menu();
            Console.ReadKey();
        }
    }
}
