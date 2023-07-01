using Arquivos.Views;
using Menu.Utils;
using manipulacao_de_datas;

/*
    Programa para leitura de dados de pessoas
    e exportação em arquivo .txt
*/
Bootstrapper.ChargeClients();

int option = 0;

do
{
    Console.WriteLine("***************************");
    Console.WriteLine("Menu da Clínica Veterinária");
    Console.WriteLine("***************************");
    Console.WriteLine("");
    DateTime data = DateTime.Now;
    Console.WriteLine(data.ToLocalTime());
    Console.WriteLine("1 - Clientes");
    Console.WriteLine("2 - Animais");
    Console.WriteLine("3 - Médicos");
    Console.WriteLine("4 - Clínicas");
    Console.WriteLine("0 - SAIR");
    
    option = Convert.ToInt32(Console.ReadLine());

    switch(option)
    {
        case 1 :
            Console.WriteLine("Opção Clientes");
            ClientView clientView = new ClientView();
        break;

        case 2 :
            Console.WriteLine("Opção Animais");
            AnimalsView animalsViews = new AnimalsView();
        break;
        
        case 3 :
            Console.WriteLine("Opção Médicos");
            MedicosView medicoViews = new MedicosView();
        break;
        
        case 4 :
            Console.WriteLine("Opção Clínicas");

        break;
    }




}
while(option > 0);