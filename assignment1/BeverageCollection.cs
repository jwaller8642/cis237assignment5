using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class BeverageCollection
    {
        UserInterface userInterface = new UserInterface();
        BeverageJWallerEntities dbBeverage = new BeverageJWallerEntities();
        public void printBeverage()
        {
           

            foreach (Beverage beverage in dbBeverage.Beverages)
            {
                Console.WriteLine(beverage.id + " " + beverage.name + "" + beverage.pack + "" + beverage.price);
            }
        }



        public void SearchBeverage()
        {
            bool found = false;

            while (found != true)
            {
                string userInput = string.Empty;
                Console.Write("Find beverage by ID ");
                userInput = Console.ReadLine();
                try
                {
                    Beverage findBeverage = dbBeverage.Beverages.Where(beverage => beverage.id == userInput).First();

                    Console.WriteLine(findBeverage.id + " " + findBeverage.name + "" + findBeverage.pack + "" + findBeverage.price);
                    found = true;
                }
                catch
                {
                    Console.WriteLine("Beverage Not Found!!");
                  
                }
                //return true;
            }
           
        }


        public void AddBeverage()
        {
            string userInput = string.Empty;
            //Console.WriteLine("Enter beverage ID");
            Beverage newBeverage = new Beverage();
            Console.Write("Enter id ");
            userInput = Console.ReadLine();
            newBeverage.id = userInput;
            Console.Write("Enter name ");
            userInput = Console.ReadLine();
            newBeverage.name = userInput;
            Console.Write("Enter pack ");
            userInput = Console.ReadLine();
            newBeverage.pack = userInput;
            Console.Write("Enter price ");
            userInput = Console.ReadLine();
            newBeverage.price = Int32.Parse(userInput);

            Console.WriteLine("Are you sure you want to add " + newBeverage.name + " to the database ");
            Console.Write("Y or N");
            userInput = Console.ReadLine();

            if (userInput.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                dbBeverage.Beverages.Add(newBeverage);
                dbBeverage.SaveChanges();
            }
            else if (userInput.Equals("n", StringComparison.OrdinalIgnoreCase))
            {
                int choice = userInterface.DisplayMenuAndGetResponse();
            }
            else
            {
                Console.WriteLine("Invalid entry");
            }


        }
    }
}
