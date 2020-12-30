using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kutuphane
{
    public static class SeedCreate
    {
        public static void GenerateSeedData(KutuphaneContext context)
        {

            context.Books.Add(
            new Book
            {
                Id = 1,
                Name = "Harry potter ve ateş kadehi",
                RegisterationTime = DateTime.Now,
                Author = "J.K. Rowling",
                NumberOfBooks = 20
            });


            context.Members.Add(
                new Member
                {
                    Id = 1,
                    Name = "William Shakespeare",
                    Age = 31,
                    Adress = "Minnesota carolina st 21",
                    RegisterationTime = DateTime.Now
                }
            );
            context.SaveChanges();
        }
    }
}
