using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arquivos.Models
{// Início do escopo do Namespace...
    public class Animal
    { // Início do escopo da classe

        public string? Name {get; set;}
        public string? Peso {get; set;}
        public string? Tipo {get; set;}
        public int Id {get; set;}

        //Método SEMPRE utiliza ().
        
        // Os métodos contrutores são responsáveis por instanciar uma variável do tipo especificado pela classe.
        // A regra é de que o construtor tenha o mesmo nome da classe.
        public Animal()
        {

        }
        public Animal(string? name, string? peso, string? tipo, int id)
        {
            Name = name;
            Peso = peso;
            Tipo = tipo;
            Id = id;
        }

        public string FullName => 
            $"{this.FirstName} {this.Tipo}";

        public override string ToString()
        {
            return $"Id: {this.Id}; Name: {this.FullName} ";
        }
    } // Fim do escopo do classe...
}// Fim do escopo do Namespace...