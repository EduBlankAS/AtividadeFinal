using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arquivos.Data;
using Arquivos.Models;
using Arquivos.Controllers;
namespace Arquivos.Views
{
    public class ClinicasViews
    {
        private ClinicaController clinicaController;

        public ClinicasViews()
        {
            clinicaController = new ClinicaController();
            this.Init();
        }
        public void Init()
        {
            Console.WriteLine("*********************");
            Console.WriteLine("Você está em clinicas.");
            Console.WriteLine("*********************");
            Console.WriteLine("");
            Console.WriteLine("1 - Inserir clínica");
            Console.WriteLine("2 - Listar clínica");
            Console.WriteLine("3 - Exportar clínica");
            Console.WriteLine("4 - Importar clínica");
            Console.WriteLine("5 - Pesquisar clínica");
            Console.WriteLine("0 - Volta ao início do Menu");
            Console.WriteLine("");

            int option = 0;

            option = Convert.ToInt32(Console.ReadLine());
            
            switch(option)
            {
                case 1 :
                    Insert();
                break;
                case 2 :
                    List();
                break;

                case 3:
                    Export();
                break;

                case 4:
                    Import();
                break;

                 case 5:
                    SearchByName();
                break;

                default:
                break;
            }
            
        }

        private void List()
        {
            List<Clinica> listagem = clinicaController.List();
            //Controlador + Acumulador + Flag
            for(int i = 0; i < listagem.Count; i++)
            {
                Console.WriteLine(Print(listagem[i]));
            }
        }

        private string Print(Clinica clinica)
        {
            string retorno = "";
            retorno += $"Id: {clinica.Id} \n";
            retorno += $"Nome: {clinica.Name} \n";
            retorno += "-------------------- \n";

            return retorno;
        }


        private void Insert()
        {
            Clinica clinica = new Clinica();
            clinica.Id = clinicaController.GetNextId();

            Console.WriteLine("\nInforme O Nome da Clínica: ");
            clinica.Name = Console.ReadLine();

            Console.WriteLine("\nInforme O Seu Telefone: ");
            clinica.Telephone = Console.ReadLine();
            
            Console.WriteLine("\nInforme O Seu Endreço: ");
            clinica.Address = Console.ReadLine();

            bool retorno = animalController.Insert(animal);

            if(retorno == true)
            {
                Console.WriteLine("Clinica inserida com sucesso!");
            }
            else
                Console.WriteLine("Falha ao inserir, verifique os dados!");
        }

        private void Export()
        {
            if( clinicaController.ExportToTextFile() )
                Console.WriteLine("Arquivo gerado com sucesso!");
            else
                Console.WriteLine("Ooooops.");
        }

        private void SearchByName()
        {
            Console.WriteLine("Pesquisar Clínica pelo nome.");
            Console.WriteLine("Digite o nome:");
            string name = Console.ReadLine();
            foreach( Clinica a in 
            clinicaController.SearchByName(name) )
            {
                Console.WriteLine( a.ToString() );
            }

            
        }

    }
}