using System;

namespace LocalVariable
{
    class LocalacVariableDemo
    {
        static void Main()
        {
            int no;
            //Console.Write(no);      <---This stament throws the error becouse variable must be initialized before its use
            //no++;                   <--_|
            no = 0;
            Console.WriteLine(no);

        }
    }
}
