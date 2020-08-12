using System;

namespace Cliente.Domain.Entities
{
    public class Cliente
    {
        public Cliente(string nome, int idade)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Idade = idade;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
    }
}
