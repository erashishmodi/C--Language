//Write A program to show the use of "dynamic(run time )" keyword
namespace UseOfDynamic
{
    class MainClass
    {
        static void Main()
        {
            dynamic variable = 10;   //int
            System.Console.WriteLine(variable);
            variable="The String type"; //<--string type
            System.Console.WriteLine(variable);

        }
    }
}
