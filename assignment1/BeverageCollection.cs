using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class BeverageCollection
    {
        public void printBeverage()
        {
            BeverageJWallerEntities dbBeverage = new BeverageJWallerEntities();

            foreach (Beverage beverage in dbBeverage.Beverages)
            {
                Console.WriteLine(beverage.id + " " + beverage.name + " " + beverage.pack + " " + beverage.price);
            }
        }
    }
}
