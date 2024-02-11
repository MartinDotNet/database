using ConsoleApp.Contexts;
using ConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Repositories
{
    internal class AdressRepository : Repo<AdressEntity>
    {
        public AdressRepository(DataContext context) : base(context)
        {

        }
    }

}
