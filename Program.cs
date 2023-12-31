﻿using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace PROVA
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> Nomes = new() { };
            List<Candidatos> listaCandidatos = new() { };
            int rotativo = 0;
            int quantidadeDeCandidatos = 0;
            int eleitores = 0;
            bool proibir = false;
            bool proibir1 = false;
            var inicio = new ConsoleTable("Opcões||Digite o numero respectivo", "Modos");
            var aviso = new ConsoleTable("Aviso", "Saida");
            var pesquisa_candidatos = new ConsoleTable("Aviso", "Candidatos", "Saida");
            ConsoleTable eleitorestable = new ConsoleTable("Aviso", "eleitores");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.Gray;
            while (true)
            {
                // Tudo foi separado em funções para ser possivel analiza-las uma a uma e o codigo ficar mais organizado.
                int escolha = tela_inicial();

                if (eleitores == 0)
                {
                    if (rotativo > 0)
                    {
                        proibir1 = true;
                    }
                    else { }
                }
                switch (escolha)
                {
                    case 1:
                        case_1();
                        break;
                    case 2:
                        case_2();
                        break;
                    case 3:
                        case_3();
                        break;
                    case 4:
                        case_4();
                        break;
                    case 5:
                        case_5();
                        break;
                }
            }
            // Foi criada uma função para dar um clear em certas coisas para evitar a repetição que aqui estava
            void limpa_tudo(int x)
            {

                if (x == 1) { aviso.Rows.Clear(); }
                else if (x == 2) { inicio.Rows.Clear(); }
                else if (x == 3) { pesquisa_candidatos.Rows.Clear(); }
                else if (x == 4) { eleitorestable.Rows.Clear(); }
                else if (x == 5) { Console.Clear(); }
                else if (x == 10)
                {
                    aviso.Rows.Clear();
                    inicio.Rows.Clear();
                    pesquisa_candidatos.Rows.Clear();
                    eleitorestable.Rows.Clear();
                    Console.Clear();
                }
                else
                {
                    x = 1;
                }






            }

            bool cadastrar(string nome)
            {
                if (Nomes.Contains(nome))
                {
                    return false;
                }
                // Removido else redundante

                // Trocada pela função add, pois, ele sempre será no último indice da lista, então, não precisa falar que é
                Nomes.Add(nome);
                foreach (string x in Nomes)
                {
                    string user = x;
                    listaCandidatos.Add(new Candidatos(user));
                }

                // Removida a necessidade de fazer conta com a quantidade de candidatos
                quantidadeDeCandidatos = listaCandidatos.Count;
                return true;
            }

            bool votar(int voto)
            {
                quantidadeDeCandidatos = 1;
                int cont = 0;
                while (cont < listaCandidatos.Count)
                {


                    if (quantidadeDeCandidatos == voto)
                    {
                        listaCandidatos[quantidadeDeCandidatos].SetVoto(1);
                        cont++;

                        string nome = listaCandidatos[quantidadeDeCandidatos].getNome();
                        return true;
                    }
                    quantidadeDeCandidatos++;
                }
                return false;
            }

            int tela_inicial()
            {
                rotativo++;
                limpa_tudo(10);
                Console.WriteLine("Bom dia, escolha o modo pra prosseguir o mascote oficial da turma ds");
                inicio.AddRow("Cadastrar Candidatos", "1");
                inicio.AddRow("Atualizar quantidade de eleitores", "2");
                inicio.AddRow("Pesquisar candidatos", "3");
                inicio.AddRow("Votar", "4");
                inicio.AddRow("Apresentar resultados", "5");
                inicio.Write(Format.Alternative);

                int selecionado = 0;
                try
                {
                    selecionado = Convert.ToInt32(Console.ReadLine());
                    return selecionado;
                }
                catch (Exception e)
                {
                    //   limpa_tudo(dr_aviso = true, r_incio = true);
                    aviso.AddRow("Digite um numero valido:", "1.à.5");
                    aviso.AddRow("Para sair da tela de aviso, tecle qualquer tecla e presisone enter", ".");
                    aviso.Write(Format.Alternative);
                    Console.ReadKey();
                    return 0;
                }

            }
            void case_1()
            {
                string nome = "";
                limpa_tudo(10);
                if (proibir == true)
                {
                    aviso.AddRow("Após o primeiro voto computado, não é possível cadastrar novos candidatos ou atualizar a quantidade de eleitores", "Digite qualquer tecla para sair");
                    aviso.Write(Format.Alternative);
                    Console.ReadLine();
                    return;
                }

                else
                {
                    aviso.AddRow("Voce escolheu o cadastrar candidatos:", "Digite o nome do novo candidato");
                    aviso.Write(Format.Alternative);
                    nome = Console.ReadLine();
                }
                if (cadastrar(nome) == true)
                {
                    aviso.Rows.Clear();
                    aviso.AddRow($"Candidato: '{nome}' salvo ", "Pressione Enter <- para sair");
                    aviso.Write();
                    Console.ReadLine();
                    proibir1 = false;
                    return;

                }
                // else redundante removido
                aviso.Rows.Clear();
                aviso.AddRow($"Candidato: '{nome}' ja existe", "Pressione Enter <- para sair");
                aviso.Write();
                Console.ReadLine();

                return;
            }
            void case_2()
            {
                limpa_tudo(10);
                eleitorestable.AddRow("Voce escolheu o Atualizar quantidade de eleitores:", "");
                eleitorestable.AddRow("No sistema há esta quantidade de eleitores. ->", Convert.ToString(eleitores));
                //eleitorestable.AddRow(eleitores);

                eleitorestable.Write(Format.Alternative);
                if (proibir == true)
                {
                    aviso.AddRow("não pode altertar a quantidade de eleitores, apenas vizualizar a mesma", "Digite qualquer tecla para sair :)");
                    aviso.Write();
                    Console.ReadKey();
                    return;
                }
                else
                    aviso.AddRow("Deseja adicionar eleitores?", "");
                aviso.AddRow("Sim", "(1)");
                aviso.AddRow("Não", "(2)");
                aviso.Write();
                aviso.Rows.Clear();

                int sn = 0;
                try
                {
                    sn = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception) { }

                // switch case desnecessario removido, tinham apenas 2 opções e causava mais indents
                if (sn == 1)
                {

                    limpa_tudo(10);
                    eleitorestable.AddRow("Digite a nova quantidade de eleitores", "");
                    eleitorestable.Write();
                    eleitores = Convert.ToInt32(Console.ReadLine());
                    limpa_tudo(10);
                    eleitorestable.AddRow("Beleza a nova quantidade é ", Convert.ToString(eleitores));
                    eleitorestable.AddRow("---->", "digite qualquer tecla pra sair");
                    eleitorestable.Write(Format.Alternative);
                    Console.ReadKey();
                    proibir1 = false;
                    return;
                }

                else if (sn == 2)
                {
                    limpa_tudo(10);
                    eleitorestable.AddRow("Quantidadel atual", Convert.ToString(eleitores));
                    aviso.AddRow("Obrigado :)", "Pressione Enter <-");
                    eleitorestable.Write();
                    aviso.Write();

                    Console.ReadKey();
                    return;
                }
                return;
            }
            void case_3()
            {
                if (quantidadeDeCandidatos < 2)
                {
                    limpa_tudo(10);
                    // Frase reformulada
                    aviso.AddRow("Minimo de candidatos necessários para realiza a pesquisa: 2", "Pressine Enter <--");
                    aviso.Write();
                    Console.ReadKey();
                    return;
                }
                limpa_tudo(10);
                // Faltou acento no você
                pesquisa_candidatos.AddRow("Você escolheu pesquisar candidatos:", "", "");

                pesquisa_candidatos.AddRow("Pesquisar candidato por nome, verificar se existe o candidato", "", "(1)");
                pesquisa_candidatos.AddRow("Listar todos os candidatos e seus respectivos n°", "", "(2)");
                pesquisa_candidatos.Write(Format.Alternative);
                int sn1 = 0;
                try
                {
                    sn1 = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    aviso.AddRow("Digite apenas os numeros:", "1 ou 2");
                    aviso.AddRow("--------- >", "Digite qualquer tecla para sair :)");
                    aviso.Write();
                    Console.ReadKey();
                }

                // switch case desnecessario removido, tinham apenas 2 opções e causava mais indents
                if (sn1 == 1)
                {
                    limpa_tudo(10);
                    pesquisa_candidatos.AddRow("Digite o nome do seu candidato", "", "");
                    pesquisa_candidatos.Write(Format.Alternative);

                    string nomedocand = Console.ReadLine();


                    // removido a redundancia do == e invertido a função para ter menos indents e ficar mais legivel o código
                    if (!Nomes.Contains(nomedocand))
                    {
                        limpa_tudo(10);
                        pesquisa_candidatos.AddRow("O(A) candidat(o) não existe", nomedocand, "INEXISTENTE");
                        aviso.AddRow("-------->", "Pressione Enter <--");
                        pesquisa_candidatos.Write(Format.Alternative);
                        aviso.Write();
                        Console.ReadKey();
                        return;
                    }

                    foreach (string nomesz in Nomes)
                    {
                        // Inicializar a variável com o valor de 1 ao envés de 0 para não precisar somá-la a nada quando colocar no pesquisa_candiatos
                        int x = 1;
                        if (nomesz == nomedocand)
                        {
                            Console.Clear();
                            pesquisa_candidatos.Columns.Remove("Saída");
                            pesquisa_candidatos.Columns.Add("n° do Voto");
                            // arrumado alguns erros(de varios) de português
                            pesquisa_candidatos.AddRow("O(a) candidato(a) existe, e você pode votar nele(a)", nomedocand, "(" + x + ")");
                            pesquisa_candidatos.Write(Format.Alternative);
                            Console.WriteLine("aperte qualquer tecla para sair :)");
                            pesquisa_candidatos.Columns.Remove("n° do Voto");
                            pesquisa_candidatos.Columns.Add("Saida");
                            Console.ReadLine();
                        }
                        x++;
                    }
                    aviso.Rows.Clear();
                    aviso.AddRow("--------->", "Pressione Enter <-");
                    aviso.Write();
                    return;
                }

                else if (sn1 == 2)
                {

                    pesquisa_candidatos.Rows.Clear();

                    pesquisa_candidatos.Columns.Remove("Saida");
                    pesquisa_candidatos.Columns.Add("n° do Voto");
                    quantidadeDeCandidatos = quantidadeDeCandidatos / quantidadeDeCandidatos;
                    foreach (string x in Nomes)
                    {
                        pesquisa_candidatos.AddRow("Candidatos existentes->", x, "(" + (quantidadeDeCandidatos) + ")");

                        quantidadeDeCandidatos++;
                    }
                    pesquisa_candidatos.Write(Format.Alternative);
                    pesquisa_candidatos.Columns.Remove("n° do Voto");
                    pesquisa_candidatos.Columns.Add("Saida");
                    aviso.Rows.Clear();
                    aviso.AddRow("->", "Pressione Enter <--");
                    aviso.Write();
                    Console.ReadKey();
                    return;
                }

                return;
            }
            void case_4()
            {
                limpa_tudo(10);
                aviso.AddRow("Voce escolheu votar:", "");
                aviso.Write();
                if (listaCandidatos.Count <= 1)
                {
                    limpa_tudo(10);
                    aviso.AddRow("Para fazer a votação deve se ter no minimo dois candidatos.", "Pressione Enter <--");
                    aviso.Write();
                    Console.ReadKey();
                    return;
                }
                if (proibir1 == true)
                {
                    limpa_tudo(10);
                    aviso.AddRow("Não há candidatos ou eleitores, portanto nao se pode votar", "Pressione Enter <--");
                    aviso.Write();
                    Console.ReadKey();
                    return;
                }
                pesquisa_candidatos.Rows.Clear();
                pesquisa_candidatos.Columns.Remove("Saida");
                pesquisa_candidatos.Columns.Add("n° do Voto");
                while (eleitores > 0)
                {
                    quantidadeDeCandidatos = 1;
                    foreach (string x in Nomes)
                    {
                        pesquisa_candidatos.AddRow("Candidatos existentes->", x, "(" + (quantidadeDeCandidatos) + ")");
                        quantidadeDeCandidatos++;

                    }
                    pesquisa_candidatos.AddRow("Dos candidatos supracitado, qual deles tera seu voto?", "", $"0 à {(quantidadeDeCandidatos - 1)}");

                    pesquisa_candidatos.Write(Format.Alternative);
                    pesquisa_candidatos.Columns.Remove("n° do Voto");
                    pesquisa_candidatos.Columns.Add("Saida");

                    int candidatoSupracitado = 0;
                    try
                    {
                        candidatoSupracitado = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        limpa_tudo(10);
                        aviso.AddRow("Digite apenas os numeros opcionais para votos", "Pressione Enter <--");
                        aviso.Write();
                        Console.ReadKey();
                    }
                    catch (Exception)
                    {

                    }
                    if (votar(candidatoSupracitado) == true)
                    {
                        proibir = true;
                        eleitores--;
                        limpa_tudo(10);
                        aviso.AddRow($"Voto Computado para", listaCandidatos[candidatoSupracitado].getNome());
                        aviso.AddRow($"Restam:{eleitores} eleitores para votarem!", "Pressione Enter <--");
                        aviso.Write();
                        Console.ReadKey();
                        break;
                    }
                    // Removido else redunante
                    aviso.AddRow("Erro", "Pressione Enter <--");
                    aviso.Write();
                }
                return;
            }
            void case_5()
            {
                limpa_tudo(10);
                aviso.AddRow("Voce escolheu apresentar resultados>", "");
                aviso.Write();

                // Função if invertida para diminuir os indents
                if (eleitores != 0)
                {
                    limpa_tudo(10);
                    aviso.AddRow("Ainda há eleitores para votar em seus canditaos.", "Pressione Enter <--");
                    aviso.Write();
                    Console.ReadKey();
                    return;
                }

                if (listaCandidatos.Count == 0)
                {
                    aviso.AddRow("Não é possivel, pois nao ha candidatos", "Pressione Enter <--");
                    aviso.Write();
                    Console.ReadKey();
                    return;
                }

                int[] maiorVoto = new int[100];

                int cont = 0;
                int index = 0;
                int outrocont = 0;
                while (cont <= listaCandidatos.Count)
                {
                    maiorVoto[cont] = listaCandidatos[quantidadeDeCandidatos].GetVoto();

                    if (maiorVoto[cont] >= outrocont)
                    {
                        index = cont;
                    }
                    cont++;
                    outrocont++;
                }

                string vencedor = listaCandidatos[index].getNome();
                int votosdoganhador = listaCandidatos[index].GetVoto();
                aviso.Rows.Clear();
                aviso.Columns.Remove("Aviso");
                aviso.Columns.Remove("Saida");
                aviso.Columns.Add("Candidato Vencedor");
                aviso.Columns.Add("Número de votos");


                aviso.AddRow($"{vencedor}", $"{votosdoganhador}");
                aviso.Write(Format.Alternative);

                aviso.Rows.Clear();
                aviso.Columns.Remove("Candidato Vencedor");
                aviso.Columns.Remove("Número de votos");
                aviso.Columns.Add("Outros Candidatos");
                aviso.Columns.Add("Votos");

                foreach (Candidatos candidato in listaCandidatos)
                {
                    if (candidato.GetVoto() > 0)
                    {
                        aviso.AddRow($"{candidato.getNome()}", $"{candidato.GetVoto()}");
                    }
                }
                aviso.Write();
                aviso.Columns.Remove("Outros Candidatos");
                aviso.Columns.Remove("Votos");
                aviso.Columns.Add("Aviso");
                aviso.Columns.Add("Saida");
                aviso.AddRow("Obrigado", "Pressione Enter <--");
                Console.ReadKey();
                return;
            }
        }
    }
}