
using ConsoleTables;
using System;
using System.Collections.Generic;
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
            List<String> Nomes = new List<string> { };
            List<Candidatos> listaCandidatos = new List<Candidatos> { };
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

                Console.Clear();
                inicio.Rows.Clear();
                Console.WriteLine("Bom dia, escolha o modo pra prosseguir o mascote oficial da turma ds");
                inicio.AddRow("Cadastrar Candidatos", "1");
                inicio.AddRow("Atualizar quantidade de eleitores", "2");
                inicio.AddRow("Pesquisar candidatos", "3");
                inicio.AddRow("Votar", "4");
                inicio.AddRow("Apresentar resultados", "5");
                inicio.Write(Format.Alternative);

                // codigo base para o formato
                //inicio.Rows.Clear();
                //inicio.AddRow("Cadastrar Candidatos", "1");
                //inicio.Write(Format.Alternative);
                // ::)

                int selecionado = 0;
                try
                {
                    selecionado = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    // codigo base para o formato
                    //inicio.Rows.Clear();
                    //inicio.AddRow("Cadastrar Candidatos", "1");
                    //inicio.Write(Format.Alternative);
                    // ::)
                    aviso.Rows.Clear();
                    inicio.Rows.Clear();
                    aviso.Rows.Clear();
                    aviso.AddRow("Digite um numero valido:", "1.à.5");
                    aviso.AddRow("Para sair da tela de aviso, tecle qualquer tecla e presisone enter", ".");
                    aviso.Write(Format.Alternative);
                    Console.ReadKey();

                }

                if (eleitores == 0)
                {
                    proibir1 = true;
                }
                switch (selecionado)
                {

                    case 1:
                        aviso.Rows.Clear();
                        inicio.Rows.Clear();
                        aviso.Rows.Clear();
                        pesquisa_candidatos.Rows.Clear();
                        eleitorestable.Rows.Clear();
                        Console.Clear();
                        if (proibir == true)
                        {


                            aviso.AddRow("Após o primeiro voto computado, não é possível cadastrar novos candidatos ou atualizar a quantidade de eleitores", "Digite qualquer tecla para sair");
                            aviso.Write(Format.Alternative);
                            Console.ReadLine();
                            break;
                        }
                        else
                            aviso.AddRow("Voce escolheu o cadastrar candidatos:", "Digite o nome do novo candidato");
                        aviso.Write(Format.Alternative);
                        string nome = Console.ReadLine();

                        if (cadastrar(nome) == true)
                        {
                            aviso.Rows.Clear();
                            aviso.AddRow($"Candidato: '{nome}' salvo ", "Pressione Enter <- para sair");
                            aviso.Write();
                            Console.ReadLine();
                            proibir1 = false;
                            break;

                        }
                        else
                        {
                            aviso.Rows.Clear();
                            aviso.AddRow($"Candidato: '{nome}' ja existe", "Pressione Enter <- para sair");
                            aviso.Write();
                            Console.ReadLine();

                            break;
                        }

                        break;
                    case 2:
                        Console.Clear();

                        aviso.Rows.Clear();
                        inicio.Rows.Clear();
                        aviso.Rows.Clear();
                        pesquisa_candidatos.Rows.Clear();
                        eleitorestable.Rows.Clear();

                        eleitorestable.AddRow("Voce escolheu o Atualizar quantidade de eleitores:", "");
                        eleitorestable.AddRow("No sistema há esta quantidade de eleitores. ->", Convert.ToString(eleitores));
                        //eleitorestable.AddRow(eleitores);

                        eleitorestable.Write(Format.Alternative);
                        if (proibir == true)
                        {
                            aviso.AddRow("não pode altertar a quantidade de eleitores, apenas vizualizar a mesma", "Digite qualquer tecla para sair :)");
                            aviso.Write();
                            Console.ReadKey();
                            break;
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
                        switch (sn)
                        {
                            case 1:
                                eleitorestable.Rows.Clear();
                                aviso.Rows.Clear();
                                eleitorestable.AddRow("Digite a nova quantidade de eleitores", "");
                                eleitorestable.Write();
                                eleitores = Convert.ToInt32(Console.ReadLine());
                                eleitorestable.Rows.Clear();
                                aviso.Rows.Clear();
                                eleitorestable.AddRow("Beleza a nova quantidade é ", Convert.ToString(eleitores));
                                eleitorestable.AddRow("---->", "digite qualquer tecla pra sair");
                                eleitorestable.Write(Format.Alternative);
                                Console.ReadKey();
                                proibir1 = false;
                                break;
                            case 2:
                                aviso.Rows.Clear();
                                eleitorestable.Rows.Clear();
                                eleitorestable.AddRow("Quantidadel atual", Convert.ToString(eleitores));
                                aviso.AddRow("Obrigado :)", "Pressione Enter <-");
                                eleitorestable.Write();
                                aviso.Write();

                                Console.ReadKey();
                                break;

                        }
                        break;
                    case 3:
                        if (quantidadeDeCandidatos < 2)
                        {
                            Console.Clear();
                            aviso.Rows.Clear();
                            aviso.AddRow("Nao há candidatos suficientes para mostrar pesquisa, crie pelo menos 2", "Pressine Enter <--");
                            aviso.Write();
                            Console.ReadKey();
                            break;
                        }
                        Console.Clear();
                        aviso.Rows.Clear();
                        inicio.Rows.Clear();
                        aviso.Rows.Clear();
                        pesquisa_candidatos.Rows.Clear();
                        eleitorestable.Rows.Clear();
                        Console.Clear();
                        pesquisa_candidatos.AddRow("Voce escolheu pesquisar candidatos:", "", "");

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

                        switch (sn1)
                        {
                            case 1:

                                Console.Clear();
                                pesquisa_candidatos.Rows.Clear();
                                pesquisa_candidatos.AddRow("Digite o nome do seu candidato", "", "");
                                pesquisa_candidatos.Write(Format.Alternative);

                                string nomedocand = Console.ReadLine();

                                if (Nomes.Contains(nomedocand) == true)
                                {
                                    foreach (string nomesz in Nomes)
                                    {
                                        int x = 0;
                                        if (nomesz == nomedocand)
                                        {
                                            Console.Clear();
                                            pesquisa_candidatos.Columns.Remove("Saida");
                                            pesquisa_candidatos.Columns.Add("n° do Voto");
                                            pesquisa_candidatos.AddRow("O(a) candidato(a) existe, e voce pode votar nele(a)", nomedocand, "(" + (x + 1) + ")");
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
                                    break;
                                }
                                Console.Clear();
                                aviso.Rows.Clear();
                                pesquisa_candidatos.Rows.Clear();
                                pesquisa_candidatos.AddRow("O(A) candidat(o) não existe", nomedocand, "INEXISTENTE");
                                aviso.AddRow("-------->", "Pressione Enter <--");
                                pesquisa_candidatos.Write(Format.Alternative);
                                aviso.Write();
                                Console.ReadKey();
                                break;
                            case 2:

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

                                break;
                        }

                        break;
                    case 4:
                        aviso.Rows.Clear();
                        inicio.Rows.Clear();
                        aviso.Rows.Clear();
                        pesquisa_candidatos.Rows.Clear();
                        eleitorestable.Rows.Clear();
                        Console.Clear();


                        aviso.AddRow("Voce escolheu votar:", "");
                        aviso.Write();
                        if (listaCandidatos.Count <= 1)
                        {

                            Console.Clear();
                            aviso.Rows.Clear();
                            aviso.AddRow("Para fazer a votação deve se ter no minimo dois candidatos.", "Pressione Enter <--");
                            aviso.Write();
                            Console.ReadKey();
                            break;
                        }
                        if (proibir1 == true)
                        {
                            Console.Clear();
                            aviso.Rows.Clear();
                            aviso.AddRow("Não há candidatos ou eleitores, portanto nao se pode votar", "Pressione Enter <--");
                            aviso.Write();
                            Console.ReadKey();
                            break;
                        }
                        pesquisa_candidatos.Rows.Clear();

                        pesquisa_candidatos.Columns.Remove("Saida");
                        pesquisa_candidatos.Columns.Add("n° do Voto");
                        while (eleitores > 0)
                        {
                            quantidadeDeCandidatos = quantidadeDeCandidatos / quantidadeDeCandidatos;
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
                                Console.Clear();
                                aviso.Rows.Clear();
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
                                Console.Clear();
                                aviso.Rows.Clear();
                                aviso.AddRow($"Voto Computado para", listaCandidatos[candidatoSupracitado].getNome());
                                aviso.AddRow($"Restam:{eleitores} eleitores para votarem!", "Pressione Enter <--");
                                aviso.Write();
                                Console.ReadKey();
                                break;
                            }
                            else
                            {
                                aviso.AddRow("Erro", "Pressione Enter <--");
                                aviso.Write();
                            }
                        }
                        break;

                    case 5:
                        Console.Clear();
                        aviso.Rows.Clear();
                        aviso.AddRow("Voce escolheu apresentar resultados>", "");
                        aviso.Write();
                        if (eleitores == 0)
                        {
                            if (listaCandidatos.Count == 0)
                            {
                                aviso.AddRow("Não é possivel, pois nao ha candidatos", "Pressione Enter <--");
                                aviso.Write();
                                Console.ReadKey();
                                break;
                            }
                            int[] maiorVoto = new int[100];

                            int cont = 0;
                            while (cont < listaCandidatos.Count)
                            {
                                maiorVoto[cont] = listaCandidatos[quantidadeDeCandidatos].GetVoto();
                                cont++;
                            }
                            string vencedor;
                                int votosdoganhador;
                            int n = listaCandidatos.Count, maior = -1;
                            for (int i = 0; i < n; i++)
                            {
                                if (i == 0)
                                {
                                    maiorVoto[i] = maior;
                                }
                                if (maiorVoto[i] > maior)
                                {
                                    maior = i;
                                   
                                }
                            }
                            vencedor = listaCandidatos[maior].getNome();
                            votosdoganhador = listaCandidatos[maior].GetVoto();
                            aviso.Rows.Clear();
                            aviso.Columns.Remove("Aviso");
                            aviso.Columns.Remove("Saida");
                            aviso.Columns.Add("Candidato Vencedor");
                            aviso.Columns.Add("Número de votos");
                           

                            aviso.AddRow($"{vencedor}", $"{votosdoganhador}");
                            aviso.Write(Format.Alternative);
                            // =================== // 
                            aviso.Rows.Clear();
                            aviso.Columns.Remove("Candidato Vencedor");
                            aviso.Columns.Remove("Número de votos");
                            aviso.Columns.Add("Outros Candidatos");
                            aviso.Columns.Add("Votos");

                            // =====================//
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
                        }
                        else if (eleitores > 0)
                        {
                            aviso.Rows.Clear();
                            Console.Clear();
                            aviso.AddRow("Ainda há eleitores para votar em seus canditaos.", "Pressione Enter <--");
                            aviso.Write();
                            Console.ReadKey();
                            break;
                        }
                        break;
                }


                bool cadastrar(string nome)
                {
                    if (Nomes.Contains(nome))
                    {
                        return false;
                    }
                    else
                    {
                        Nomes.Insert(quantidadeDeCandidatos, nome);
                        foreach (string x in Nomes)
                        {
                            string user = x;
                            listaCandidatos.Add(new Candidatos(user));
                        }

                        quantidadeDeCandidatos++;
                        return true;
                    }
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
                // Essas || para
                // Linhas || dar
                // Vazias ||
                // Sao      ||
            }
        }
    }
}



// 