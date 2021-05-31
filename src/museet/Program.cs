
namespace museet
{  
    class Program
    {
        static void Main(string[] args)
        {
            //mouse over class names and method calls to see documentation comments

            View myView = new View();
            
            DataRepository myRepository = new DataRepository();
            myView.WriteInstructions();
            myRepository.SelectMuseumContent(myView.MyMuseum);
            myView.ViewRoom(0);
        }
    }
}
