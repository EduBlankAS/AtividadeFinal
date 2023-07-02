using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Arquivos.Data;
using Arquivos.Models;

namespace Arquivos.Controllers
{
    public class MedicoController
    {   
        private string directoryName = "ReportFiles";

        private string fileName = "Medicos.txt";

        public List<Medico> List()
        {
            return DataSet.Medicos;
        }

        public bool Insert(Medico medico)
        {
            if(medico == null)
                return false;
            
            if(medico.Id <= 0)
                return false;
            
            if(string.IsNullOrWhiteSpace(medico.FirstName))
                return false;
            
            DataSet.Medicos.Add(medico);
            return true;

        }

        public bool ExportToTextFile()
        {
            if(!Directory.Exists(directoryName))
                Directory.CreateDirectory(directoryName);
            
            string fileContent = string.Empty;
            foreach(Medico m in DataSet.Medicos)
            {
                fileContent += $"{m.Id};{m.CPF};{m.FirstName};{m.LastName};{m.Email};{m.Experiencia}";
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
                Medico medico = new Medico();
                string[] medicoData = line.Split(';');
                medico.Id = Convert.ToInt32( medicoData[0]);
                medico.CPF = medicoData[1];
                medico.FirstName = medicoData[2];
                medico.LastName = medicoData[3];
                medico.Email = medicoData[4];
                medico.Experiencia = medicoData[5];

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

         public List<Medico> SearchByName(string name)
        {
            if ( string.IsNullOrEmpty(name) ||
                 string.IsNullOrWhiteSpace(name) 
                )
                return null;

            List<Medico> medicos = new List<Medico>();
            for(int i = 0; i < DataSet.Medicos.Count; i ++)
            {
                var c = DataSet.Medicos[i];
                if( c.FullName.ToLower().Contains(name.ToLower()) )
                {
                    medicos.Add(c);
                }
            }
            return medicos;
            
        }

        public int GetNextId()
        {
            int tam = DataSet.Medicos.Count;

            if(tam > 0)
            {
                return DataSet.Medicos[tam - 1].Id + 1;
            }
            else
                return 1;
        }        
    }
}