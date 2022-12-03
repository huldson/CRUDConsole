using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD
{
    internal class Cliente
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int imoveis { get; set; }
        public Cliente() { }
        public Cliente(int id, string nome, int imoveis)
        {
            this.id = id;
            this.nome = nome;
            this.imoveis = imoveis;

        }
        

        public override string ToString()
        {
            return "id: " + id + "\nnome: " + nome + "\nimoveis: " + imoveis;
        }
    }
}
