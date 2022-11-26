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
        public void salvarBanco(int tamanho,string nome,int imoveis)
        {
            string stringDeSalvar = $"INSERT INTO dbo.cliente (id, nome, imoveis) VALUES (" + tamanho + ",'" + nome + "' ," + imoveis + " )";
            SqlCommand comandoSalvar = new SqlCommand(stringDeSalvar, this.Conexão);
            comandoSalvar.CommandType = CommandType.Text;
            this.Conexão.Open();
            comandoSalvar.ExecuteNonQuery();
            this.Conexão.Close();
        }
    }
}
