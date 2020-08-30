using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEFThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            //Normal....
            //EmployeerMV emp = new EmployeerMV();
            //var list= emp.GetAll();

            //foreach (var item in list)
            //{
            //    Console.WriteLine(item.FirstName);
            //}

            //Task here...
            //EmployeerMV emp = new EmployeerMV(true);
            //Console.WriteLine("Hola mundo.");
            //Task<IEnumerable<DimEmployee>> mytask = Task<IEnumerable<DimEmployee>>.Factory.StartNew(()=> {
            //    Console.WriteLine("Soy un hilo.");
            //    return emp.GetAll();
            //});

            //Console.WriteLine("Sali del hilo.");
            //var lis = mytask.Result;

            var empTask = new EmployeerThreaded();

            var task = empTask.GetAll();
            
            task.Wait();

            var lis = task.Result;

            foreach (var item in lis)
            {
                Console.WriteLine(item.FirstName);
            }

           
            Console.ReadKey();
        }
    }
}
