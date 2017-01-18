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
            using (var entity = new ModelContext())
            {

                entity.Profile.Include("Perfil").Where(p => p.Id == 1).First();

                var perfil = entity.Profile.Find(1);

                var person = new Person() { Name = "Adriano La Selva", Email = "adrianolaselva123@gmail.com", LastName = "Moreira La Selva", Perfil = perfil };

                person = entity.People.Add(person);

                entity.PersonLog.Add(new PersonLog { DateTime = DateTime.Now, Person = person });
                //person.PersonLogs.Add(new PersonLog { DateTime = DateTime.Now });

                Console.WriteLine(person.Id);

                entity.SaveChanges();
            }
        }
    }
}
