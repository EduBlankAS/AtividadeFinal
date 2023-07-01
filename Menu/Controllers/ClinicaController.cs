using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Arquivos.Data;
using Arquivos.Models;

namespace Menu.Controllers
{
    public class ClinicaController
    {   
        private string directoryName = "ReportFiles";

        private string fileName = "Clients.txt";

        public List<Clinica> List()
        {
            return DataSet.Clinicas;
        }

        public bool Insert(Clinica clinica)
        {
            if(clinica == null)
                return false;
            
            if(clinica.Id <= 0)
                return false;
            
            if(string.IsNullOrWhiteSpace(clinica.Name))
                return false;
            
            DataSet.Clinicas.Add(clinica);
            return true;

        }

        public bool ExportToTextFile()
        {
            if(!Directory.Exists(directoryName))
                Directory.CreateDirectory(directoryName);
            
            string fileContent = string.Empty;
            foreach(Clinica c in DataSet.Clinicas)
            {
                fileContent += $"{cl.Id};{cl.CNPJ};{cl.Name};{cl.Address};{cl.Telephone}";
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
                Clinica clinica = new Clinica();
                string[] clinicaData = line.Split(';');
                clinica.Id = Convert.ToInt32( clinicaData[0]);
                clinica.CNPJ = clinicaData[1];
                clinica.Name = clinicaData[2];
                clinica.Address = clinicaData[3];
                clinica.Telephone = clinicaData[4];

                DataSet.Clinicas.Add(clinica);

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

        public List<Client> SearchByName(string name)
        {
            if ( string.IsNullOrEmpty(name) ||
                 string.IsNullOrWhiteSpace(name) 
                )
                return null;

            List<Clinica> clinicas = new List<Clinica>();
            for(int i = 0; i < DataSet.Clinica.Count; i ++)
            {
                var c = DataSet.Clinicas[i];
                if( c.FullName.ToLower().Contains(name.ToLower()) )
                {
                    clinicas.Add(c);
                }
            }
            return clinicas;
            
        }

        public int GetNextId()
        {
            int tam = DataSet.Clinicas.Count;

            if(tam > 0)
            {
                return DataSet.Clinicas[tam - 1].Id + 1;
            }
            else
                return 1;
        }        
    }
}