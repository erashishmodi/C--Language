namespace DemoNS
{
    public class Work 
    {

        static void Main()
        {
            System.Console.WriteLine("THE MAIN METHOD OF CLASS WORK OF NAME SPACE DemoNS");
        }
    }

}

public class Work 
{
    public void print()
    {
        System.Console.WriteLine("THE MAIN METHOD OF CLASS WORK ");
    }
}
class Test
{
    static void main()
    {
        global::Work w;
        w = new Work(); 

        w.print();
        //DemoNS.Work wrk1;
    }
}
