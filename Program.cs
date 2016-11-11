using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var entity = new Model())
            {
                Pessoa person = new Pessoa() { Name = "Adriano La Selva", Email = "adrianolaselva123@gmail.com" };

                person = entity.Pessoa.Add(person);

                Console.WriteLine(person.Id);

                entity.SaveChanges();
            }
        }
    }
}
