using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AED;
using System.IO;

namespace TP_02_Agenda
{
    class Contato
    {
        public int tipo = 0;
        public string nome;
        public string nickname;
        public string empresa;
        public string cargo;
        public string celular;
        public string telefone_resid;
        public string telefone_comer;
        public string email;
        public string twitter;
        public Endereco endereco = new Endereco();
        public int aniversario_dia;
        public int aniversario_mes;
        public int aniversario_ano;

        public Contato()
        {
            this.tipo = 0;
        }

        public string SalvarNoArquivo(Contato Contact) // Função para salvar as linhas no arquivo
        {
            string linhaContato = "";
                      
            // tipo (0); Nome (1) ;

            linhaContato += Contact.tipo + ";";
            linhaContato += Contact.nome + ";";
            linhaContato += Contact.nickname + ";";
            if (Contact.tipo == 2)
            {
                linhaContato += Contact.empresa + ";";
                linhaContato += Contact.cargo + ";";
            }
            else
            {
                linhaContato += "#;";   //Atributo Empresa Quando Tipo 1
                linhaContato += "#;";  //Atributo Cargo Quando Tipo 1
            }
            linhaContato += Contact.celular + ";";
            linhaContato += Contact.telefone_resid + ";";
            linhaContato += Contact.telefone_comer + ";";
            linhaContato += Contact.email + ";";
            linhaContato += Contact.twitter + ";";
            linhaContato += Contact.endereco.tipo_logradouro + ";";
            linhaContato += Contact.endereco.bairro + ";";
            linhaContato += Contact.endereco.cidade + ";";
            linhaContato += Contact.endereco.numero + ";";
            linhaContato += Contact.endereco.cep + ";";
            linhaContato += Contact.aniversario_dia + "/";
            linhaContato += Contact.aniversario_mes + "/";
            linhaContato += Contact.aniversario_ano + "/";
            
            return linhaContato;
        }

        //Deleta contato através do nome informado pelo usuário
        public void DeletaContato(CLista Agenda, string nomeDeletar)
        {
            foreach (Contato contato in Agenda)
            {
                if (contato.nome.Equals(nomeDeletar))
                {
                    Agenda.Remove(nomeDeletar);
                    Console.Write("\n\nContato excluído com sucesso!");
                    Console.ReadKey();
                }
                else
                {
                    Console.Write("A agenda não contém o nome informado. \nGentileza informar um nome válido.");
                }
            }
        }

        //Altera contato através do nome informado pelo usuário
        public void AlterarContato(CLista Agenda, string nomeAlterar)
        {
            //Abrindo Arquivi para Escrita
            StreamWriter arquivo_agenda = new StreamWriter("Agenda.txt");
            Contato Contact = new Contato();

            Console.Clear();

            foreach (Contato contato in Agenda)
            {
                if (contato.nome.Equals(nomeAlterar))
                {
                    Console.Write("Tipo: " + contato.tipo);
                    Console.Write("Nome: " + contato.nome);
                    Console.Write("Apelido: " + contato.nickname);
                    if (contato.tipo.Equals(2))
                    {
                        Console.Write("Empresa: " + contato.empresa);
                        Console.Write("Cargo: " + contato.cargo);
                    }
                    Console.Write("Celular: " + contato.celular);
                    Console.Write("Telefone Residencial: " + contato.telefone_resid);
                    Console.Write("Telefone Comercial: " + contato.telefone_comer);
                    Console.Write("E-mail: " + contato.email);
                    Console.Write("Twitter: " + contato.twitter);
                    Console.Write("Tipo do logradouro (Rua/Av): " + contato.endereco.tipo_logradouro);
                    Console.Write("Número: " + contato.endereco.numero);
                    Console.Write("Bairro: " + contato.endereco.bairro);
                    Console.Write("Cidade: " + contato.endereco.cidade);
                    Console.Write("Estado: " + contato.endereco.estado);
                    Console.Write("CEP: " + contato.endereco.cep);
                    Console.Write("Aniversário: " + contato.aniversario_dia + "/" + contato.aniversario_mes + "/" + contato.aniversario_ano);

                    Console.Write("\n\n===========================================");
                    Console.Write("\t Alteração do Dados do Contato");
                    Console.Write("\n===========================================\n\n");

                    Console.Write("Nickname: ");
                    Contact.nickname = Console.ReadLine();
                    contato.nickname = Contact.nickname;
                    arquivo_agenda.Write(Contact.nickname + "; ");


                    if (contato.tipo.Equals(2))
                    {
                        Console.Write("Empresa: ");
                        Contact.empresa = Console.ReadLine();
                        contato.empresa = Contact.empresa;
                        arquivo_agenda.Write(Contact.empresa + "; ");

                        Console.Write("Cargo: ");
                        Contact.cargo = Console.ReadLine();
                        contato.cargo = Contact.cargo;
                        arquivo_agenda.Write(Contact.cargo + "; ");
                    }

                    Console.Write("Celular: ");
                    Contact.celular = Console.ReadLine();
                    contato.celular = Contact.celular;
                    arquivo_agenda.Write(Contact.celular + "; ");

                    Console.Write("Telefone Residencial: ");
                    Contact.telefone_resid = Console.ReadLine();
                    contato.telefone_resid = Contact.telefone_resid;
                    arquivo_agenda.Write(Contact.telefone_resid + "; ");

                    Console.Write("Telefone Comercial: ");
                    Contact.telefone_comer = Console.ReadLine();
                    contato.telefone_comer = Contact.telefone_comer;
                    arquivo_agenda.Write(Contact.telefone_comer + "; ");

                    Console.Write("E-mail: ");
                    Contact.email = Console.ReadLine();
                    contato.email = Contact.email;
                    arquivo_agenda.Write(Contact.email + "; ");

                    Console.Write("Twitter: ");
                    Contact.twitter = Console.ReadLine();
                    contato.twitter = Contact.twitter;
                    arquivo_agenda.Write(Contact.twitter + "; ");

                    Console.Write("Tipo do logradouro (Rua/Av): ");
                    Contact.endereco.tipo_logradouro = Console.ReadLine();
                    contato.endereco.tipo_logradouro = Contact.endereco.tipo_logradouro;
                    arquivo_agenda.Write(Contact.endereco.tipo_logradouro + "; ");

                    Console.Write("Número: ");
                    Contact.endereco.numero = int.Parse(Console.ReadLine());
                    contato.endereco.numero = Contact.endereco.numero;
                    arquivo_agenda.Write(Contact.endereco.numero + "; ");

                    Console.Write("Bairro: ");
                    Contact.endereco.bairro = Console.ReadLine();
                    contato.endereco.bairro = Contact.endereco.bairro;
                    arquivo_agenda.Write(Contact.endereco.bairro + "; ");

                    Console.Write("Cidade: ");
                    Contact.endereco.cidade = Console.ReadLine();
                    contato.endereco.cidade = Contact.endereco.cidade;
                    arquivo_agenda.Write(Contact.endereco.cidade + "; ");

                    Console.Write("Estado: ");
                    Contact.endereco.estado = Console.ReadLine();
                    contato.endereco.estado = Contact.endereco.estado;
                    arquivo_agenda.Write(Contact.endereco.estado + "; ");

                    Console.Write("CEP: ");
                    Contact.endereco.cep = long.Parse(Console.ReadLine());
                    contato.endereco.cep = Contact.endereco.cep;
                    arquivo_agenda.Write(Contact.endereco.cep + "; ");

                    Console.Write("Aniversario - Dia: ");
                    Contact.aniversario_dia = int.Parse(Console.ReadLine());
                    contato.aniversario_dia = Contact.aniversario_dia;
                    arquivo_agenda.Write(Contact.aniversario_dia + "/");

                    Console.Write("Aniversario - Mês: ");
                    Contact.aniversario_mes = int.Parse(Console.ReadLine());
                    contato.aniversario_mes = Contact.aniversario_mes;
                    arquivo_agenda.Write(Contact.aniversario_mes + "/");

                    Console.Write("Aniversario - Ano: ");
                    Contact.aniversario_ano = int.Parse(Console.ReadLine());
                    contato.aniversario_ano = Contact.aniversario_ano;
                    arquivo_agenda.Write(Contact.aniversario_ano + "; ");

                    //Inserindo contato na CLista
                    Console.Write("\nContato alterado com sucesso!");
                    Console.ReadKey();

                    //Fechando Arquivo
                    arquivo_agenda.Close();

                }
            }

        }

        //Pesquisa contato por Nome
        public void PesquisaNome(CLista Agenda, string nomePesquisa)
        {
            foreach (Contato contato in Agenda)
            {
                if (contato.nome.Equals(nomePesquisa)) // Verifica se existe o nome informado na agenda
                {
                    // Tem de imprimir os dados se conter o nome
                    if (contato.tipo == 1)
                        Console.Write("Tipo: Pessoal");
                    else
                        Console.Write("\nTipo: Profissional");
                    Console.Write("\nNome: " + contato.nome);
                    Console.Write("\nNickname: " + contato.nickname);
                    if (contato.tipo == 2)
                    {
                        Console.Write("\nEmpresa: " + contato.empresa);
                        Console.Write("\nCargo: " + contato.cargo);
                    }
                    Console.Write("\nCelular: " + contato.celular);
                    Console.Write("\nTelefone Residencial: " + contato.telefone_resid);
                    Console.Write("\nTelefone Comercial: " + contato.telefone_comer);
                    Console.Write("\nE-mail: " + contato.email);
                    Console.Write("\nTwitter: " + contato.twitter);
                    Console.Write("\nTipo do logradouro (Rua/Av): " + contato.endereco.tipo_logradouro);
                    Console.Write("\nNúmero: " + contato.endereco.numero);
                    Console.Write("\nBairro: " + contato.endereco.bairro);
                    Console.Write("\nCidade: " + contato.endereco.cidade);
                    Console.Write("\nEstado: " + contato.endereco.estado);
                    Console.Write("\nCEP: " + contato.endereco.cep);
                    Console.Write("\nAniversario - Dia: " + contato.aniversario_dia);
                    Console.Write("\nAniversario - Mês: " + contato.aniversario_mes);
                    Console.Write("\nAniversario - Ano: " + contato.aniversario_ano);
                }
                else
                    Console.Write("\nA agenda não contém o nome informado. \n Gentileza informar um nome válido.");

            }

        } // fim PesquisaNome

        //Pesquisa contato por Apelido
        public void PesquisaApelido(CLista Agenda, string apelidoPesquisa)
        {
            foreach (Contato contato in Agenda)
            {
                if (contato.nickname.Equals(apelidoPesquisa)) // Verifica se existe o apelido informado na agenda
                {
                    // Tem de imprimir os dados se conter o apelido
                    if (contato.tipo == 1)
                        Console.Write("Tipo: Pessoal");
                    else
                        Console.Write("Tipo: Profissional");
                    Console.Write("Nome: " + contato.nome);
                    Console.Write("Nickname: " + contato.nickname);
                    if (contato.tipo == 2)
                    {
                        Console.Write("Empresa: " + contato.empresa);
                        Console.Write("Cargo: " + contato.cargo);
                    }
                    Console.Write("Celular: " + contato.celular);
                    Console.Write("Telefone Residencial: " + contato.telefone_resid);
                    Console.Write("Telefone Comercial: " + contato.telefone_comer);
                    Console.Write("E-mail: " + contato.email);
                    Console.Write("Twitter: " + contato.twitter);
                    Console.Write("Tipo do logradouro (Rua/Av): " + contato.endereco.tipo_logradouro);
                    Console.Write("Número: " + contato.endereco.numero);
                    Console.Write("Bairro: " + contato.endereco.bairro);
                    Console.Write("Cidade: " + contato.endereco.cidade);
                    Console.Write("Estado: " + contato.endereco.estado);
                    Console.Write("CEP: " + contato.endereco.cep);
                    Console.Write("Aniversario - Dia: " + contato.aniversario_dia);
                    Console.Write("Aniversario - Mês: " + contato.aniversario_mes);
                    Console.Write("Aniversario - Ano: " + contato.aniversario_ano);
                }
                else
                    Console.Write("A agenda não contém o apelido informado. \n Gentileza informar um apelido válido.");

            }
        } // fim PesquisaApelido

        //Listar contatos pessoal e profissional
        public void ListarContatosPorTipo(CLista Agenda, int tipoContatoPessoal)
        {
            Console.Clear();
            int cont = 0;
            int pagina_anterior = 0;
            int pagina_atual = 1;

            for (int i = 0; i < Agenda.Quantidade(); i++)
            {
                cont++;

                if (pagina_anterior != pagina_atual)
                {
                    Console.WriteLine("LISTAGEM DE CONTATOS ( PÁGINA " + pagina_atual + ")");
                    Console.WriteLine("=========================\n\n");
                }

                pagina_anterior = pagina_atual;
                foreach (Contato contato in Agenda)
                {
                    // imprime dados 
                    if (tipoContatoPessoal == 1)
                        Console.Write("Tipo: Pessoal");
                    else
                    {
                        Console.Write("\nTipo: Profissional");
                    }
                    Console.Write("\nNome: " + contato.nome);
                    Console.Write("\nNickname: " + contato.nickname);

                    if (tipoContatoPessoal == 2)
                    {
                        Console.Write("\nEmpresa: " + contato.empresa);
                        Console.Write("\nCargo: " + contato.cargo);
                    }
                    Console.Write("\nCelular: " + contato.celular);
                    Console.Write("\nTelefone Residencial: " + contato.telefone_resid);
                    Console.Write("\nTelefone Comercial: " + contato.telefone_comer);
                    Console.Write("\nE-mail: " + contato.email);
                    Console.Write("\nTwitter: " + contato.twitter);
                    Console.Write("\nTipo do logradouro (Rua/Av): " + contato.endereco.tipo_logradouro);
                    Console.Write("\nNúmero: " + contato.endereco.numero);
                    Console.Write("\nBairro: " + contato.endereco.bairro);
                    Console.Write("\nCidade: " + contato.endereco.cidade);
                    Console.Write("\nEstado: " + contato.endereco.estado);
                    Console.Write("\nCEP: " + contato.endereco.cep);
                    Console.Write("\nAniversario - Dia: " + contato.aniversario_dia);
                    Console.Write("\nAniversario - Mês: " + contato.aniversario_mes);
                    Console.Write("\nAniversario - Ano: " + contato.aniversario_ano);

                    if (cont % 3 == 0)
                    {
                        cont = 0;
                        pagina_atual++;
                        pagina_anterior = pagina_atual - 1;
                    }

                    //Quebra de Linha
                    Console.Write("\n\n");
                }
            }
        } // fim ListarContatos

        //Listar Todos os contatos
        public void ListarTodosContatos(CLista Agenda)
        {
            int cont = 0;
            int pagina_anterior = 0;
            int pagina_atual = 1;

            for (int i = 0; i < Agenda.Quantidade(); i++)
            {
                cont++;

                if (pagina_anterior != pagina_atual)
                {
                    Console.WriteLine("LISTAGEM DE CONTATOS ( PÁGINA " + pagina_atual + ")");
                    Console.WriteLine("=========================\n\n");
                }

                pagina_anterior = pagina_atual;
                foreach (Contato contato in Agenda)
                {
                    // imprime dados 
                    if (contato.tipo == 1)
                        Console.Write("Tipo: Pessoal");
                    else
                    {
                        Console.Write("\nTipo: Profissional");
                    }

                    Console.Write("\nNome: " + contato.nome);
                    Console.Write("\nNickname: " + contato.nickname);

                    if (contato.tipo == 2)
                    {
                        Console.Write("\nEmpresa: " + contato.empresa);
                        Console.Write("\nCargo: " + contato.cargo);
                    }
                    Console.Write("\nCelular: " + contato.celular);
                    Console.Write("\nTelefone Residencial: " + contato.telefone_resid);
                    Console.Write("\nTelefone Comercial: " + contato.telefone_comer);
                    Console.Write("\nE-mail: " + contato.email);
                    Console.Write("\nTwitter: " + contato.twitter);
                    Console.Write("\nTipo do logradouro (Rua/Av): " + contato.endereco.tipo_logradouro);
                    Console.Write("\nNúmero: " + contato.endereco.numero);
                    Console.Write("\nBairro: " + contato.endereco.bairro);
                    Console.Write("\nCidade: " + contato.endereco.cidade);
                    Console.Write("\nEstado: " + contato.endereco.estado);
                    Console.Write("\nCEP: " + contato.endereco.cep);
                    Console.Write("\nAniversario - Dia: " + contato.aniversario_dia);
                    Console.Write("\nAniversario - Mês: " + contato.aniversario_mes);
                    Console.Write("\nAniversario - Ano: " + contato.aniversario_ano);

                    if (cont % 3 == 0)
                    {
                        cont = 0;
                        pagina_atual++;
                        pagina_anterior = pagina_atual - 1;
                    }

                    //Quebra de Linha
                    Console.Write("\n\n");
                }
            }
        } // Fim da listagem de todos os contatos

        //Listar Todos os contatos aniversariantes
        public void ListarAniversariantes(CLista Agenda, int mes)
        {
            Console.WriteLine("LISTAGEM DE ANIVERSARIANTES");
            Console.WriteLine("=========================\n");

            foreach (Contato contato in Agenda)
            {
                // imprime dados dos aniversariantes
                if (contato.aniversario_mes == mes)
                {
                    Console.Write("\nNome: " + contato.nome);
                    Console.Write("\nCelular: " + contato.celular);
                    Console.Write("\nE-mail: " + contato.email);
                    Console.Write("\nData de Aniversario: " + contato.aniversario_dia + "/" + contato.aniversario_mes + "/" + contato.aniversario_ano);

                    //Quebra de Linha
                    Console.Write("\n\n");
                }
            }
        } // Fim da listagem de todos os contatos aniversariantes
    }
}
