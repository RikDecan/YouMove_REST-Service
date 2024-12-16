using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymBL.Interfaces;
using GymDL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


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
