using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class BeverageCollection 
    {

        // Added bev id#'s: 
        /* RRZZZ
         * RMZZZ
         * RRZZ3
         * RMZZ3
        */
        // Created in instance
        UserInterface userInterface = new UserInterface();
        BeverageJWallerEntities dbBeverage = new BeverageJWallerEntities();
        // variables
        int counter = 0;
        public void printBeverage()
        {
            counter = 0;

            foreach (Beverage beverage in dbBeverage.Beverages)
            {
                counter = counter + 1;
                Console.WriteLine(beverage.id + " " + beverage.name + "" + beverage.pack + "" + beverage.price);
                //Console.WriteLine("_____________________________________________________________________________");
            }
            Console.WriteLine("*************************************************");
            Console.WriteLine("There are (" + counter + ") items in the database"); // how many items were loaded
            Console.WriteLine("*************************************************");
        }


        // Search from class
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
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("!!Beverage Not Found!!");
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!");
                  
                }
                
            }
           
        }


        public void AddBeverage()
        {
            counter = 0;
            string userInput = string.Empty;
            string idInput = string.Empty;
            bool same = false;
            //Console.WriteLine("Enter beverage ID");
            Beverage newBeverage = new Beverage();
            while (same != true)
            {
                Console.Write("Enter id ");
                idInput = Console.ReadLine();
                Console.WriteLine("Checking...");
                foreach (Beverage beverage in dbBeverage.Beverages) // Runs through databse
                {
                    //idInput.CompareTo(beverage.id);
                    counter = counter + 1;

                    if (idInput == beverage.id)// checks to see if id is already used
                    {
                        
                        Console.WriteLine("The ID "+ idInput +" is already taken"); // if the id is taken this you get this line 
                        same = false; // stay false if id is the same
                    }
                    else
                    {
                      
                        newBeverage.id = idInput; // take iInput and stores as the new bev id
                        same = true; // same turn true if id is diffrent
                    }
                }
                Console.WriteLine(counter + " Beverage(s) checked"); // how many items were checked
            }
            
            Console.Write("Enter name ");
            userInput = Console.ReadLine();
            newBeverage.name = userInput; // stores nam as new bev name
            Console.Write("Enter pack ");
            userInput = Console.ReadLine();
            newBeverage.pack = userInput; // stores pack as new bev pack
            Console.Write("Enter price ");
            userInput = Console.ReadLine();
            newBeverage.price = Int32.Parse(userInput); // store as price as new bev price

            Console.WriteLine("Are you sure you want to add " + newBeverage.name + " to the database "); // if  you want store the new bev or not
            Console.Write("Y or N ");
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
