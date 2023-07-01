using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arquivos.Data;
using Arquivos.Models;
using Arquivos.Controllers;
namespace Arquivos.Views
{
    public class MedicosView
    {
        private MedicoController medicoController;

        public MedicosView()
        {
            medicoController = new MedicoController();
            this.Init();
        }
        public void Init()
        {
            Console.WriteLine("*********************");
            Console.WriteLine("Você está em Médico.");
            Console.WriteLine("*********************");
            Console.WriteLine("");
            Console.WriteLine("1 - Inserir Médico");
            Console.WriteLine("2 - Listar Médico");
            Console.WriteLine("3 - Exportar Médico");
            Console.WriteLine("4 - Importar Médico");
            Console.WriteLine("5 - Pesquisar Médicos");
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
            List<Medico> listagem = medicoController.List();
            //Controlador + Acumulador + Flag
            for(int i = 0; i < listagem.Count; i++)
            {
                Console.WriteLine(Print(listagem[i]));
            }
        }

        private string Print(Medico medico)
        {
            string retorno = "";
            retorno += $"Id: {medico.Id} \n";
            retorno += $"Nome: {medico.FirstName} {medico.LastName} \n";
            retorno += "------------------------------------------- \n";

            return retorno;
        }


        private void Insert()
        {
            Medico medico = new Medico();
            medico.Id = medicoController.GetNextId();

            Console.WriteLine("\nInforme O Seu Primeiro Nome: ");
            medico.FirstName = Console.ReadLine();

            Console.WriteLine("\nInforme O Seu Sobrenome: ");
            medico.LastName = Console.ReadLine();

            Console.WriteLine("\nInforme O Seu CPF: ");
            medico.CPF = Console.ReadLine();
            
            Console.WriteLine("\nInforme O Seu Email: ");
            medico.Email = Console.ReadLine();

            Console.WriteLine("\nInforme Seu Tempo de Experiencia na área: ");
            medico.Email = Console.ReadLine();

            bool retorno = medicoController.Insert(medico);

            if(retorno == true)
            {
                Console.WriteLine("Médico inserido com sucesso!");
            }
            else
                Console.WriteLine("Falha ao inserir, verifique os dados!");
        }

        private void Export()
        {
            if( medicoController.ExportToTextFile() )
                Console.WriteLine("Arquivo gerado com sucesso!");
            else
                Console.WriteLine("Ooooops.");
        }

        private void Import()
        {
            if(medicoController.ImportFromTxtFile() )
                Console.WriteLine("Dados importados com sucesso!");
            else
                Console.WriteLine("Oooooops.");
        }
        
        private void SearchByName()
        {
            Console.WriteLine("Pesquisar Médico pelo nome.");
            Console.WriteLine("Digite o nome:");
            string name = Console.ReadLine();
            foreach( Medico m in 
            medicoController.SearchByName(name) )
            {
                Console.WriteLine( m.ToString() );
            }

            
        }
    }
}