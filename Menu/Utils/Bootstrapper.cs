using Arquivos.Data;
using Arquivos.Models;
namespace Menu.Utils

{
    public static class Bootstrapper
    {
        public static void ChargeClients()
        {
            var c1 = new Client{
                Id = 1,
                FirstName = "Eduardo Blank",
                LastName = "Arrais Silva",
                CPF = "000.000.000-00",
                Email = "eduardoblankarraissilva@gmail.com",
            };
            DataSet.Clients.Add(c1);

            DataSet.Clients.Add(
                new Client{
                    Id = 2,
                    FirstName = "Eduardo",
                    LastName = "Blank",
                    CPF = "000.000-01",
                    Email= "eduardoblankarraissilva@gmail.com"
                }
            );
            DataSet.Clients.Add(
                new Client{
                    Id = 3,
                    FirstName = "Luiz",
                    LastName = "Henrique",
                    CPF = "000.000-02",
                    Email= "luizhenrique@gmail.com"
                }
            );
        }

        public static void ChargeMedicos()
        {
            var m1 = new Medico{
                Id = 1,
                FirstName = "Peter",
                LastName = "Parker",
                CPF = "000.000.000-00",
                Email = "peterparker@gmail.com",
            };
            DataSet.Medicos.Add(m1);

            DataSet.Medicos.Add(
                new Medico{
                    Id = 2,
                    FirstName = "Doctor",
                    LastName = "Room",
                    CPF = "000.000-04",
                    Email= "doctorroom@gmailhotmail.com"
                }
            );
            DataSet.Medicos.Add(
                new Medico{
                    Id = 3,
                    FirstName = "Light",
                    LastName = "Yagami",
                    CPF = "000.000-06",
                    Email= "lightyagami@hotmail.com"
                }
            );
        }

        public static void ChargeClinicas()
        {
            var cl1 = new Clinica{
                Id = 1,
                Name = "My pet My home",
                Address = "Marechal Floriano",
                CNPJ = "00.000.000/0000-11",
                Telephone = "(49)-90000-0000",
            };
            DataSet.Clinicas.Add(cl1);

            DataSet.Clinicas.Add(
                new Clinica{
                    Id = 2,
                    Name = "My Baby Pet",
                    Address = "Vizan Ruando",
                    CNPJ = "00.000.000/0000-12",
                    Telephone= "(49)-90000-0001"
                }
            );
            DataSet.Clinicas.Add(
                new Clinica{
                    Id = 3,
                    Name = "Infinite Pet",
                    Address = "Arlong Better",
                    CNPJ = "00.000.000/0000-13",
                    Telephone= "(49)-90000-0002"
                }
            );
        }

        public static void ChargeAnimals()
        {
            var n1 = new Animal{
                Id = 1,
                Name = "Flok",
                Peso = "3kg",
                Tipo = "Femea",
            };
            DataSet.Animals.Add(n1);

            DataSet.Animals.Add(
                new Animal{
                    Id = 2,
                    Name = "Pingu",
                    Peso = "2kg",
                    Tipo = "Macho",
                }
            );
            DataSet.Animals.Add(
                new Animal{
                    Id = 3,
                    Name = "Pluto",
                    Peso = "1kg",
                    Tipo = "Macho",
                }
            );
        }
    }
}