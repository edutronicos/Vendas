using System;
using System.Collections.Generic;
using System.Linq;

namespace VendasWebMvc.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public double SalarioBase { get; set; }
        public Departament Departament { get; set; }
        public ICollection<RegistroVenda> Vendas { get; set; } = new List<RegistroVenda>();

        public Vendedor()
        {

        }

        public Vendedor(int id, string nome, string email, DateTime dataNascimento, double salarioBase, Departament departament)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            SalarioBase = salarioBase;
            Departament = departament;
        }

        public void AddVendedores(RegistroVenda rv)
        {
            Vendas.Add(rv);
        }

        public void RemoveVendedores(RegistroVenda rv)
        {
            Vendas.Remove(rv);
        }

        public double TotalVendas(DateTime initial, DateTime final)
        {
            return Vendas.Where(rv => rv.Data >= initial && rv.Data <= final).Sum(rv => rv.Quantia);
        }
    }
}
