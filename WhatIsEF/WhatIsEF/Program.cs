using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WhatIsEF
{
    class Program
    {
        static void Main(string[] args)
        {
            //            ShowStudents();
            //            UseDatabaseLog();
            //            ShowStudentsUseAsync();
            //            UseView();
            UseStoreProcedures();
            Console.ReadKey();
        }

        static void ShowStudents()
        {
            using (var context = new SchooldbEntities())
            {
                int count = 0;
                var query = from s in context.Students
                            select s;

                foreach (var s in query)
                {
                    Console.WriteLine(s.Sname);
                }
                Console.WriteLine($"共有学生{count}人");
            }
        }

        static void UseDatabaseLog()
        {
            using (var context = new SchooldbEntities())
            {
                context.Database.Log = Console.WriteLine;

                var query = from s in context.Students
                            select s;
                List<Student> students = query.ToList();
                Console.WriteLine("学生信息提取完毕");
            }
        }

        static async void ShowStudentsUseAsync()
        {
            using (var context = new SchooldbEntities())
            {
                await context.Students.ForEachAsync((student) => { Console.WriteLine(student.Sname); });
            }
           
        }

        static void UseView()
        {
            using (var context = new SchooldbEntities())
            {
                foreach (var record in context.SC_Details)
                {
                    Console.WriteLine($"{record.Sno}, {record.Sname}, {record.Cno}, {record.Cname.Trim()}, {record.Grade}");
                }
            }
        }

        static void UseStoreProcedures()
        {
            using (var context = new SchooldbEntities())
            {
                var student = context.Get_Student(Console.ReadLine()).ToList();
                Console.WriteLine(student[0].Sname);
                
            }
        }
    }
}
