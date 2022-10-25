// See https://aka.ms/new-console-template for more information
namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            int i=0;
            while(true)
            {
            Console.WriteLine("Hello World! {0}",i);
            i++;
            Thread.Sleep(2000);
            }
        }
    }
}