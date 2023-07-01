using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arquivos.Models
{// Início do escopo do Namespace...
    public class Medico
    { // Início do escopo da classe

        public string? FirstName {get; set;}
        public string? LastName {get; set;}
        public string? CPF {get; set;}
        public int Id {get; set;}
        public string Email {get; set;}
        public string Experiencia {get; set;}

        //Método SEMPRE utiliza ().
        
        // Os métodos contrutores são responsáveis por instanciar uma variável do tipo especificado pela classe.
        // A regra é de que o construtor tenha o mesmo nome da classe.
        public Medico()
        {

        }
        public Medico(string firstName, string lastName, string cPF, int id, string email, string experiencia)
        {
            FirstName = firstName;
            LastName = lastName;
            CPF = cPF;
            Id = id;
            Email = email;
            Experiencia = experiencia;
        }

        public string FullName => 
            $"{this.FirstName} {this.LastName}";

        public override string ToString()
        {
            return $"Id: {this.Id}; Name: {this.FullName} ";
        }
    } // Fim do escopo do classe...
}// Fim do escopo do Namespace...