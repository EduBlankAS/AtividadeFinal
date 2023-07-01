using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Models
{// Início do escopo do Namespace...
    public class Clinica
    { // Início do escopo da classe

        public string? Name {get; set;}
        public string? Address {get; set;}
        public string? CNPJ {get; set;}
        public int Id {get; set;}
        public string Telephone {get; set;}

        //Método SEMPRE utiliza ().
        
        // Os métodos contrutores são responsáveis por instanciar uma variável do tipo especificado pela classe.
        // A regra é de que o construtor tenha o mesmo nome da classe.
        public Client()
        {

        }
        public Client(string? name, string? address, string? cNPJ, int id, string telephone)
        {  // Início do escopo deste método...  
            Name = name;
            Address = address;
            CNPJ = cNPJ;
            Id = id;
            Telephone = telephone;
        } // Fim do escopo deste método...

        public string FullName => 
            $"{this.Name} {this.CNPJ}";

        public override string ToString()
        {
            return $"Id: {this.Id}; Name: {this.FullName} ";
        }
    } // Fim do escopo do classe...
}// Fim do escopo do Namespace...