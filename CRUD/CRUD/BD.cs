using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CRUD
{
    internal class BD
    {
        public SqlConnection Conexão { get; set; }

        public BD() { }

        public BD(string str){
        Conexão= new SqlConnection(str);
        }
        public void SalvarBanco(int tamanho,string nome,int imoveis)
        {
            string stringDeSalvar = $"INSERT INTO dbo.cliente (id, nome, imoveis) VALUES (" + tamanho + ",'" + nome + "' ," + imoveis + " )";
            SqlCommand comandoSalvar = new SqlCommand(stringDeSalvar, this.Conexão);
            comandoSalvar.CommandType = CommandType.Text;
            this.Conexão.Open();
            comandoSalvar.ExecuteNonQuery();
            this.Conexão.Close();
        }
        public void AlterarBanco(int id,string nome)
        {

            string stringDeAlteracao= "UPDATE dbo.cliente SET nome = '" + nome + "' WHERE id=" + id;
            SqlCommand comandoAlterar = new SqlCommand(stringDeAlteracao, this.Conexão);
            comandoAlterar.CommandType = CommandType.Text;
            this.Conexão.Open();
            comandoAlterar.ExecuteNonQuery();
            this.Conexão.Close();
        }
        public void DeletarBanco(int id)
        {
            string stringDeDelete = "DELETE FROM dbo.cliente WHERE id =" + id;
            SqlCommand comandoDeletar = new SqlCommand(stringDeDelete, this.Conexão);
            comandoDeletar.CommandType = CommandType.Text;
            this.Conexão.Open();
            comandoDeletar.ExecuteNonQuery();
            this.Conexão.Close();
        }
        public void Exibir()
        {
            Console.WriteLine("exibir todos os dados:");
            string stringDeExibicao = "select * FROM dbo.cliente";
            SqlCommand comandoExibicao = new SqlCommand(stringDeExibicao, this.Conexão);
            comandoExibicao.CommandType = CommandType.Text;
            this.Conexão.Open();
            SqlDataReader retornoExibicao = comandoExibicao.ExecuteReader();
            while (retornoExibicao.Read())
            {
                Cliente cliente = new Cliente(Int32.Parse(retornoExibicao[0].ToString()), retornoExibicao[1].ToString(), Int32.Parse(retornoExibicao[2].ToString()));
                Console.Write(cliente + "\n\n\n");

            }
            this.Conexão.Close();
        }
    }
}
