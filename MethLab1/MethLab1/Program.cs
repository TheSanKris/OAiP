namespace MethLab1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Person person1 = new Person("Alexandr", "Alexandrov", new DateTime(2022, 10, 7));
            Person person2 = new Person("Alexandr", "Alexandrov", new DateTime(2022, 10, 7));

            Console.WriteLine(person1.Equals(person2));
            Console.WriteLine(person1 == person2);
            Console.WriteLine($"Хэш1: {person1.GetHashCode()} Хэш2: {person2.GetHashCode()} ");

            Student student = new Student();
            student.AddExams(new Exam("OAIP", 5, DateTime.Now));
            student.AddExams(new Exam());
            student.AddTest(new Test());

            Console.WriteLine(student.ToString());

            Student studentClone = (Student)student.DeepCopy();
            student.FirstName = "Alexandr";
            Console.WriteLine();
            Console.WriteLine($"Исходный объект: {student}");
            Console.WriteLine($"Склонированный объект: {studentClone}");

            try
            {
                student.GroupNumber = 0;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();

            foreach(var l in student.EnumElements())
            {
                Console.WriteLine(l.ToString());
            }

            Console.WriteLine();

            foreach (var exam in student.ExamsGradeOver(3))
            {
                Console.WriteLine(exam.ToString());
            }

        }
        
        
       
    }
}