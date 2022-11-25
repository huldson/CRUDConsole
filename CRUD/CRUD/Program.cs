using System;
using System.Data;
using System.Data.SqlClient;

namespace CRUD
{
    internal class Program
    {
        static void Main(string[] args)
        { bool sair = true;
            while (sair) {
                string caminho = "Server=DESKTOP-BI33SL6;Database=CADASTRO;Trusted_Connection=True;";
                SqlConnection conexao = new SqlConnection(caminho);
                Console.Write("qual operação você deseja fazer:\n <salvar>\n <alterar>\n <deletar>\n <exibir>\n:");
                string operacao = Console.ReadLine();
                if (operacao == "salvar")
                {
                    try
                    {
                        string stringDeRetornoDoTamanho = "select count(*) FROM dbo.cliente";
                        SqlCommand comandoRetorno = new SqlCommand(stringDeRetornoDoTamanho, conexao);
                        comandoRetorno.CommandType = CommandType.Text;
                        conexao.Open();
                        SqlDataReader retornoDoTamanho = comandoRetorno.ExecuteReader();
                        int tamanho = 0;
                        if (retornoDoTamanho.Read())
                        {
                            tamanho = Convert.ToInt32(retornoDoTamanho[0]);
                        }
                        conexao.Close();
                        Console.Write("nome: ");
                        string nome = Console.ReadLine();
                        Console.Write("imoveis: ");
                        int imoveis = int.Parse(Console.ReadLine());
                        conexao.Open();
                        string stringDeSalvar = $"INSERT INTO dbo.cliente (id, nome, imoveis) VALUES (" + tamanho + ",'" + nome + "' ," + imoveis + " )";
                        SqlCommand comandoDeSalvar = new SqlCommand(stringDeSalvar, conexao);
                        comandoDeSalvar.CommandType = CommandType.Text;
                        int valor = comandoDeSalvar.ExecuteNonQuery();
                        conexao.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }


                }
                else if (operacao == "alterar")
                {
                    try
                    {
                        Console.Write("id da conta que deseja alterar nome : ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("nome: ");
                        string nome = Console.ReadLine();

                        conexao.Open();
                        string stringUpdate = "UPDATE dbo.cliente SET nome = '" + nome + "' WHERE id=" + id;
                        SqlCommand comandoUpadate = new SqlCommand(stringUpdate, conexao);
                        comandoUpadate.CommandType = CommandType.Text;
                        comandoUpadate.ExecuteNonQuery();
                        conexao.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (operacao == "deletar")
                {
                    try
                    {
                        Console.Write("id da conta que deseja deletar: ");
                        int id = int.Parse(Console.ReadLine());
                        conexao.Open();
                        string stringDeletar = "DELETE FROM dbo.cliente WHERE id=" + id;
                        SqlCommand comandoDeletar = new SqlCommand(stringDeletar, conexao);
                        comandoDeletar.CommandType = CommandType.Text;
                        comandoDeletar.ExecuteNonQuery();
                        conexao.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (operacao == "exibir") {
                    try
                    {   conexao.Open();
                        Console.WriteLine("exibir todos os dados:");
                        string stringDeExibicao = "select * FROM dbo.cliente";
                        SqlCommand comandoExibicao = new SqlCommand(stringDeExibicao, conexao);
                        comandoExibicao.CommandType = CommandType.Text;
                        SqlDataReader retornoExibicao = comandoExibicao.ExecuteReader();
                        while (retornoExibicao.Read())
                        {
                            Cliente cliente = new Cliente(Int32.Parse(retornoExibicao[0].ToString()), retornoExibicao[1].ToString(), Int32.Parse(retornoExibicao[2].ToString()));
                            Console.Write(cliente+"\n\n\n");
                            
                        }
                        conexao.Close();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine();
                    }

                }
                else if (operacao=="sair") {
                    sair = false;                
                }            
                
            }
            
        }
    }
}
