using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MethLab1.Program;

namespace MethLab1
{
    public enum Education
    {
        Specialist,
        Bachelor,
        SecondEducation
    }

    class Student: Person, IDateAndCopy
    {
        private Education _education;
        private int _groupNumber;
        private System.Collections.ArrayList tests;
        private System.Collections.ArrayList _exams;

        public Education Education { get { return _education; } set { _education = value; } }
        public int GroupNumber
        {
            get { return _groupNumber; }
            set
            {
                if (value < 100 || value > 599)
                {
                    throw new ArgumentOutOfRangeException("Значение группы должно быть < 100 и > 599");
                }

                _groupNumber = value; 
            }
        }
        public Person Person { get { return (Person)this; } set { firstName = value.FirstName; lastname = value.LastName; dateBirth = value.DateBirth; } }
        public System.Collections.ArrayList Exams { get { return _exams; } set { _exams = value; } }


        public Student(Person person, Education education, int groupNumber)
        {
            firstName = person.FirstName;
            lastname = person.LastName;
            dateBirth = person.DateBirth;
            _education = education;
            _groupNumber = groupNumber;
            _exams = new System.Collections.ArrayList();
            tests = new System.Collections.ArrayList();
        }

        public Student():base()
        {
            _education = Education.Specialist;
            _groupNumber = 0;
            _exams = new System.Collections.ArrayList();
            tests = new System.Collections.ArrayList();
        }

        public double AverageGrade { get
            {
                double sum = 0;
                foreach (object obj in _exams)
                {
                    Exam? exam = obj as Exam;
                    if(exam != null)
                    sum += exam.grade;
                }

                double result = sum / _exams.Count;
                return result;
            } }

        public bool this [Education index]
        {
            get
            {
                if (index == _education)
                {
                    return true;
                }
                else return false;
            }
        }

        public void AddExams(params Exam[] exams)
        {
            for(int i = 0; i < exams.Length; i++)
            {
               _exams.Add(exams[i]);
            }
        }

        public void AddTest(params Test[] _tests)
        {
            for (int i = 0; i < _tests.Length; i++)
            {
                tests.Add(_tests[i]);
            }
        }

        public override string ToString()
        {
            string arrE = "";
            string arrT = "";
            for(int i = 0; i < _exams.Count; i++)
            {
                if (_exams[i] is not null)
                    arrE += _exams[0].ToString();
            }
            for (int i = 0; i < tests.Count; i++)
            {
                if (tests[i] is not null)
                    arrT += tests[0].ToString();
            }
            string output = $"{firstName} {lastname} {dateBirth} {_education} {_groupNumber} {AverageGrade} {arrE} {arrT}";
            return output;
        }

        public override string ToShortString()
        {
            string output = $"{firstName} {lastname} {dateBirth} {_education} {_groupNumber} {AverageGrade}";
            return output;
        }

        public override object DeepCopy()
        {
            Student student = new Student(Person, Education, GroupNumber);
            student.tests = tests;
            student._exams = _exams;
            return student;
        }

        public List<Object> EnumElements()
        {
            List<Object> list = new List<Object>();
            foreach (var exam in _exams)
            {
                list.Add(exam);
            }            
            foreach(var test in tests)
            {
                list.Add(test);
            }
            return list;
        }

        public List<Exam> ExamsGradeOver(int min)
        {
            List<Exam> list = new List<Exam>();
            foreach (var exam in _exams)
            {
                Exam ex = (Exam)exam;
                if (ex.grade > min)
                    list.Add(ex);
            }
            return list;
        }
    }
}
