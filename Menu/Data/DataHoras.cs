namespace manipulacao_de_datas
{
    public class DataHoras
    {
         public DataHoras()
        {
            Main();
        }
        static void Main()
        {
            DateTime data = DateTime.Now;
            Console.WriteLine(data.ToLocalTime());
            Console.ReadKey();
        }
    }
}