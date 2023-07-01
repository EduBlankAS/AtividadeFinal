using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Arquivos.Data;
using Arquivos.Models;

namespace Arquivos.Controllers
{
    public class AnimalController
    {   
        private string directoryName = "ReportFiles";

        private string fileName = "Animals.txt";

        public List<Animal> List()
        {
            return DataSet.Animals;
        }

        public bool Insert(Animal animal)
        {
            if(animal == null)
                return false;
            
            if(animal.Id <= 0)
                return false;
            
            if(string.IsNullOrWhiteSpace(animal.Name))
                return false;
            
            DataSet.Animals.Add(animal);
            return true;

        }

        public bool ExportToTextFile()
        {
            if(!Directory.Exists(directoryName))
                Directory.CreateDirectory(directoryName);
            
            string fileContent = string.Empty;
            foreach(Animal a in DataSet.Animals)
            {
                fileContent += $"{a.Id};{a.Peso};{a.Name};{a.Tipo}";
                fileContent += "\n";
            }
            
            try
            {
                StreamWriter sw = File.CreateText( $"{directoryName}\\{fileName}" );

                sw.Write(fileContent);
                sw.Close();     
            }
            catch(IOException ioEx)
            {
                Console.WriteLine("Erro ao manipular o arquivo.");
                Console.WriteLine(ioEx.Message);
                return false;
            }
            return true;

            
        }

        public bool ImportFromTxtFile()
        {
            try
            {
                StreamReader sr = new StreamReader(
                $"{directoryName}\\{fileName}"
            );

            string line = string.Empty;
            line = sr.ReadLine();
            while(line != null)
            {
                Animal animal = new Animal();
                string[] animalData = line.Split(';');
                animal.Id = Convert.ToInt32( animalData[0]);
                animal.Peso = animalData[1];
                animal.Name = animalData[2];
                animal.Tipo = animalData[3];

                DataSet.Medicos.Add(medico);

                line = sr.ReadLine();
            }

            return true;

            }
            catch(Exception ex)
            {
                Console.WriteLine("Oooops. Ocorreu um erro ao tentar importar os dados.");
                Console.WriteLine(ex.Message);
                return false;
            }
        }

         public List<Animal> SearchByName(string name)
        {
            if ( string.IsNullOrEmpty(name) ||
                 string.IsNullOrWhiteSpace(name) 
                )
                return null;

            List<Animal> animal = new List<Animal>();
            for(int i = 0; i < DataSet.Animals.Count; i ++)
            {
                var c = DataSet.Animals[i];
                if( c.FullName.ToLower().Contains(name.ToLower()) )
                {
                    animals.Add(c);
                }
            }
            return animals;
            
        }

        public int GetNextId()
        {
            int tam = DataSet.Animals.Count;

            if(tam > 0)
            {
                return DataSet.Animals[tam - 1].Id + 1;
            }
            else
                return 1;
        }        
    }
}