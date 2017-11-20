using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcPool.DAL;
using PcPool.DAL.Models;

namespace PcPool.DevTest.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var pc=new PcPoolEntities();
           var user=new PcPoolModels.User() {FirstName = "23"};
            pc.Users.Add(user);
            pc.SaveChanges();
        }
    }
}
