namespace MethLab1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Student student = new Student();
            Console.WriteLine(student.ToShortString());
            Console.WriteLine($"{student[Education.Specialist]} {student[Education.Bachelor]} {student[Education.SecondEducation]}");

            
            student.Person = new Person();
            student.Education = new Education();
            student.GroupNumber = 1;
            student.Exams =  new Exam[1];       

            Console.WriteLine(student.ToString());

            Exam exam = new Exam();
            student.AddExams(exam);

            Console.WriteLine(student.ToString());

            var arr1 = new Exam[1000000];

            int timeStart = Environment.TickCount;

            for(int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = null;
            }

            int timeEnd = Environment.TickCount;

            Console.WriteLine($"Одномерный массив: {timeEnd - timeStart} ms");

            var arr2 = new Exam[1000, 1000];

            timeStart = Environment.TickCount;

            for(int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    arr2[i, j] = null;
                }
            }

            timeEnd = Environment.TickCount;

            Console.WriteLine($"Двуменрый массив: {timeEnd - timeStart} ms");

            Exam[][] arr3 = new Exam[1000][];
            for (int i = 0; i < arr3.Length; i++)
                arr3[i] = new Exam[1000];

            timeStart = Environment.TickCount;

            for (int i = 0; i < arr3.Length; i++)
            {
                for (int j = 0; j < arr3[i].Length; j++)
                {
                    arr3[i][j] = null;
                }
            }

            timeEnd = Environment.TickCount;

            Console.WriteLine($"Двуменрый ступенчатый массив: {timeEnd - timeStart} ms");
        }
        
        
       
    }
}