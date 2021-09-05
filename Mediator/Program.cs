using System;
using System.Collections.Generic;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();
            Teacher teacher = new Teacher(mediator);
            var student = new Student(mediator);
            student.Name = "Furkan";
            mediator.Students = new List<Student>();
            mediator.Students.Add(student);
            teacher.SendNewImageUrl("url");

        }
    }
    public abstract class CourseMember
    {
        protected readonly Mediator Mediator;
        public CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }
    public class Teacher : CourseMember
    {
        public Teacher(Mediator mediator) : base(mediator)
        {

        }
        public void ReceiveQuestion(string questionText, Student student)
        {
            Console.WriteLine($"Teacher received Question from {0},{1}", student.Name, questionText);
        }
        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("The teacher changed the image");
            Mediator.UpdateImage(url);
        }
        public void AnswerQuestion(string answer,Student student)
        {
            Console.WriteLine($"Teacher answered question {student.Name} {answer}");
        }
    }
    public class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {

        }
        public string Name { get; set; }
        internal void ReceiveImage(string url)
        {
            Console.WriteLine($"Student received image:{url}");
        }

        internal void ReceiveAnswer(string answerText)
        {
            Console.WriteLine($"Student received answer{answerText}");
        }
    }
    public class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }
        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.ReceiveImage(url);
            }
        }
        public void SenQuestion(string questionText, Student student)
        {
            Teacher.ReceiveQuestion(questionText, student);
        }
       
        public void SendAnswer(string answerText, Student student)
        {
            student.ReceiveAnswer(answerText);
        }
    }
}
