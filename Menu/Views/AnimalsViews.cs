using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arquivos.Data;
using Arquivos.Models;
using Arquivos.Controllers;
namespace Arquivos.Views
{
    public class AnimalsView
    {
        private AnimalController animalController;

        public AnimalsView()
        {
            animalController = new AnimalController();
            this.Init();
        }
        public void Init()
        {
            Console.WriteLine("*********************");
            Console.WriteLine("Você está em animais.");
            Console.WriteLine("*********************");
            Console.WriteLine("");
            Console.WriteLine("1 - Inserir animais");
            Console.WriteLine("2 - Listar animais");
            Console.WriteLine("3 - Exportar animais");
            Console.WriteLine("4 - Importar animais");
            Console.WriteLine("5 - Pesquisar Animais");
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
            List<Animal> listagem = animalController.List();
            //Controlador + Acumulador + Flag
            for(int i = 0; i < listagem.Count; i++)
            {
                Console.WriteLine(Print(listagem[i]));
            }
        }

        private string Print(Animal animal)
        {
            string retorno = "";
            retorno += $"Id: {animal.Id} \n";
            retorno += $"Nome: {animal.Name} \n";
            retorno += "-------------------- \n";

            return retorno;
        }


        private void Insert()
        {
            Animal animal = new Animal();
            animal.Id = animalController.GetNextId();

            Console.WriteLine("\nInforme O Nome do animal: ");
            animal.Name = Console.ReadLine();

            Console.WriteLine("\nInforme O Seu Peso: ");
            animal.Peso = Console.ReadLine();
            
            Console.WriteLine("\nInforme O Seu Tipo: ");
            animal.Tipo = Console.ReadLine();

            bool retorno = animalController.Insert(animal);

            if(retorno == true)
            {
                Console.WriteLine("Animal inserido com sucesso!");
            }
            else
                Console.WriteLine("Falha ao inserir, verifique os dados!");
        }

        private void Export()
        {
            if( animalController.ExportToTextFile() )
                Console.WriteLine("Arquivo gerado com sucesso!");
            else
                Console.WriteLine("Ooooops.");
        }
        private void Import()
        {
            if(animalController.ImportFromTxtFile() )
                Console.WriteLine("Dados importados com sucesso!");
            else
                Console.WriteLine("Oooooops.");
        }

        private void SearchByName()
        {
            Console.WriteLine("Pesquisar Animal pelo nome.");
            Console.WriteLine("Digite o nome:");
            string name = Console.ReadLine();
            foreach( Animal a in 
            animalController.SearchByName(name) )
            {
                Console.WriteLine( a.ToString() );
            }

            
        }

    }
}