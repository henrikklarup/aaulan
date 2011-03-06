using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AAUlan.Models;

namespace AAUlan.Models
{
    public class DatabaseReposity
    {
        AAUlanDatabaseEntities aauEnt = new AAUlanDatabaseEntities();

        public bool AddOrder(Pizza pizza)
        {
            //Find last id
            Pizza idpizza = aauEnt.Pizza.Where(s => s.ID > 0).OrderByDescending(s => s.ID).FirstOrDefault();
            if (idpizza == null)
            {
                pizza.ID = 1;
            }
            else
            {
                pizza.ID = idpizza.ID;
                pizza.ID++;
            }

            aauEnt.AddToPizza(pizza);
            Save();
            return true;
        }

        public void Save()
        {
            aauEnt.SaveChanges();
        }

    }
}