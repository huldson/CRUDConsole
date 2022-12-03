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
                BD banco= new BD(caminho);

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
                        banco.SalvarBanco(tamanho, nome, imoveis);
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
                         banco.AlterarBanco(id, nome);                      
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
                        banco.DeletarBanco(id);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (operacao == "exibir") {
                    try
                    {   
                         banco.Exibir();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
                else if (operacao=="sair") {
                    sair = false;                
                }                            
            }
            
        }
    }
}
