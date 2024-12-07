using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDL
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new GymContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Console.WriteLine("Database is opnieuw aangemaakt");
            }
        }

    }
}
