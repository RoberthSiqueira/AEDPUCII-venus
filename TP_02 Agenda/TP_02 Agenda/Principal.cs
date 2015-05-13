using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AED;
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
            Contato Contact = new Contato();
            StreamWriter arquivo_agenda = new StreamWriter("Agenda.txt"); // instancia objeto para criar arquivo

            //Criação do Menu Principal
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
                Console.WriteLine("| 5 – Listar contatos por tipo                                     |");
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
                    //Menu 01 - Cadastrar Contato
                    #region
                    case 1:

                        //Limpando Tela
                        Console.Clear();

                        int tipoContato; // Recebe tipo do Contato
                        bool tipoProfissional = false; // Realizar controle do tipo de Contato

                        //Cadastrando o Contato
                        do
                        {
                            Console.Write("Tipo (1- Pessoal / 2- Profissional): ");
                            tipoContato = int.Parse(Console.ReadLine());
                            if (tipoContato == 2)
                                tipoProfissional = true;
                            Contact.tipo = tipoContato;

                        } while (!(tipoContato == 1 || tipoContato == 2));
                        arquivo_agenda.Write(Contact.tipo + "; ");

                        Console.Write("Nome: ");
                        Contact.nome = Console.ReadLine();
                        arquivo_agenda.Write(Contact.nome + "; ");

                        Console.Write("Nickname: ");
                        Contact.nickname = Console.ReadLine();
                        arquivo_agenda.Write(Contact.nickname + "; ");

                        if (tipoProfissional == true)
                        {
                            Console.Write("Empresa: ");
                            Contact.empresa = Console.ReadLine();
                            arquivo_agenda.Write(Contact.empresa + "; ");

                            Console.Write("Cargo: ");
                            Contact.cargo = Console.ReadLine();
                            arquivo_agenda.Write(Contact.cargo + "; ");
                        }

                        Console.Write("Celular: ");
                        Contact.celular = Console.ReadLine();
                        arquivo_agenda.Write(Contact.celular + "; ");

                        Console.Write("Telefone Residencial: ");
                        Contact.telefone_resid = Console.ReadLine();
                        arquivo_agenda.Write(Contact.telefone_resid + "; ");

                        Console.Write("Telefone Comercial: ");
                        Contact.telefone_comer = Console.ReadLine();
                        arquivo_agenda.Write(Contact.telefone_comer + "; ");

                        Console.Write("E-mail: ");
                        Contact.email = Console.ReadLine();
                        arquivo_agenda.Write(Contact.email + "; ");

                        Console.Write("Twitter: ");
                        Contact.twitter = Console.ReadLine();
                        arquivo_agenda.Write(Contact.twitter + "; ");

                        Console.Write("Tipo do logradouro (Rua/Av): ");
                        Contact.endereco.tipo_logradouro = Console.ReadLine();
                        arquivo_agenda.Write(Contact.endereco.tipo_logradouro + "; ");

                        Console.Write("Número: ");
                        Contact.endereco.numero = int.Parse(Console.ReadLine());
                        arquivo_agenda.Write(Contact.endereco.numero + "; ");

                        Console.Write("Bairro: ");
                        Contact.endereco.bairro = Console.ReadLine();
                        arquivo_agenda.Write(Contact.endereco.bairro + "; ");

                        Console.Write("Cidade: ");
                        Contact.endereco.cidade = Console.ReadLine();
                        arquivo_agenda.Write(Contact.endereco.cidade + "; ");

                        Console.Write("Estado: ");
                        Contact.endereco.estado = Console.ReadLine();
                        arquivo_agenda.Write(Contact.endereco.estado + "; ");

                        Console.Write("CEP: ");
                        Contact.endereco.cep = long.Parse(Console.ReadLine());
                        arquivo_agenda.Write(Contact.endereco.cep + "; ");

                        Console.Write("Aniversario - Ano: ");
                        Contact.aniversario_ano = int.Parse(Console.ReadLine());
                        while (Contact.aniversario_ano > 2015 && Contact.aniversario_ano > 1)
                        {
                            Console.Write("Favor Digitar um ano válido! Aniversario - Ano: ");
                            Contact.aniversario_ano = int.Parse(Console.ReadLine());
                        }
                        arquivo_agenda.Write(Contact.aniversario_ano + "; ");

                        Console.Write("Aniversario - Mês: ");
                        Contact.aniversario_mes = int.Parse(Console.ReadLine());
                        while (Contact.aniversario_mes < 1 || Contact.aniversario_mes > 12)
                        {
                            Console.Write("Favor Digitar um mês válido! Aniversario - Mês: ");
                            Contact.aniversario_mes = int.Parse(Console.ReadLine());
                        }
                        arquivo_agenda.Write(Contact.aniversario_mes + "/");

                        Console.Write("Aniversario - Dia: ");
                        Contact.aniversario_dia = int.Parse(Console.ReadLine());
                        while (Contact.aniversario_dia > 31 || Contact.aniversario_dia < 1)
                        {
                            Console.Write("Favor Digitar um dia válido! Aniversario - Dia: ");
                            Contact.aniversario_dia = int.Parse(Console.ReadLine());
                        }
                        if ((Contact.aniversario_mes == 4 || Contact.aniversario_mes == 6 || Contact.aniversario_mes == 9 || Contact.aniversario_mes == 11) && (Contact.aniversario_dia >= 31))
                        {
                            Console.Write("Favor Digitar um mês válido! Aniversario - Dia: ");
                            Contact.aniversario_dia = int.Parse(Console.ReadLine());
                        }
                        else if ((Contact.aniversario_mes == 2) || (Contact.aniversario_dia >= 29))
                        {
                            Console.Write("Favor Digitar um mês válido! Aniversario - Dia: ");
                            Contact.aniversario_dia = int.Parse(Console.ReadLine());
                        }
                        arquivo_agenda.Write(Contact.aniversario_dia + "/");

                        //Inserindo contato na CLista
                        Console.Write("\nContato cadastrado com sucesso!");
                        Console.ReadKey();

                        break;
                    #endregion
                    // Fim cadastro de contato

                    //Menu 02 - Remover Contato, pelo nome
                    #region
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

                    #region
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

                    //Menu 04 - Pesquisar contato, pelo nome ou pelo apelido
                    #region
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

                    //Menu 05 - Listar contatos por tipo
                    #region
                    case 5:
                        //Limpando Tela
                        Console.Clear();

                        do
                        {
                            Console.Write("Qual tipo de contato deseja listar?"
                                        + "\n(1- Pessoal / 2 - Profissional): ");
                            flag = int.Parse(Console.ReadLine());
                        } while (flag>=3);

                        Contact.ListarContatosPorTipo(Agenda, flag); // chama metódo que irá realizar pesquisa
                        Console.ReadKey();

                        break;
                    #endregion
                    //Fim da Listagem por Tipo

                    //Menu 06 - Listar todos os contatos
                    #region
                    case 6:
                        Console.Clear();
                        Contact.ListarTodosContatos(Agenda);
                        Console.ReadKey();
                        break;
                    #endregion
                    //Fim da Listagem

                    //Menu 07 - Listar aniversario
                    #region
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

                    //Menu 08 - Sair
                    #region
                    //Sair
                    case 8:

                        Console.WriteLine("|=================================================================|");
                        Console.WriteLine("| Obrigado por utilizar meu sistema de agenda eletrônica!         |");
                        Console.WriteLine("|                                                                 |");
                        Console.WriteLine("|             Copyright©  -    Fellipe Couto & Roberth Siqueira   |");
                        Console.WriteLine("|=================================================================|");
                        break;
                    #endregion
                    //Sair

                    //Opção invalida
                    #region
                    //Opção Invalida!
                    default:
                        Console.Write("Opção Invalida! \n\n");
                        break;
                    #endregion
                }

            } while (opcao != 8);

            arquivo_agenda.Close();
        }

        static void Main(string[] args)
        {
            Menu();
            Console.ReadKey();
        }
    }
}
