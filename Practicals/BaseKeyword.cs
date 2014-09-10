using System;

namespace InheritanceNs
{
    class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public Person(int age, string name)
        {
            this.Age = age;
            this.Name = name;
             
        }

        class Student : Person
        {
            public string ClassName { get; set; }
            public Student() : base(0," "){}
            public Student(string Name, int age, string classname)
                : base(age, Name)
            {
                this.ClassName = classname;
            }


        }
        class Test
        {
            static void Main()
            {
                Student s = new Student("RAJ", 10, "3rd");
            }
        }
    }
}