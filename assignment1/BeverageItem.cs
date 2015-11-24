using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class BeverageItem
    {
        // variables
        string userInput = string.Empty;
        // Created in instance
        UserInterface userInterface = new UserInterface();
        BeverageJWallerEntities itemmBeverage = new BeverageJWallerEntities();

        // updates existing bev
        public void UpdateBeverge()
        {
         

                Console.Write("Enter id of beverage you want to update ");
                userInput = Console.ReadLine();
                Beverage updateDrink = itemmBeverage.Beverages.Find(userInput); // finds bev
                try
                {
                   
                    Console.WriteLine(updateDrink.id + " " + updateDrink.name + " " + " " + updateDrink.pack + " " + updateDrink.price); // prints put existing bev
                   
                }
                catch
                {
                    Console.WriteLine("Beverage dose not exist");
                    UpdateBeverge();
                }
               
            
            
                Console.WriteLine("****************");
                Console.WriteLine("1. Update ID ");
                Console.WriteLine("2. Update Name ");
                Console.WriteLine("3. Update pack ");
                Console.WriteLine("4. Update price ");
                Console.WriteLine("5. Update all ");
                Console.WriteLine("m. Main Menu");
                Console.Write("Choose an option ");
                userInput = Console.ReadLine();



                if (userInput == "1")
                {
                    userInput = null; // set userInput to null
                    Console.Write("Enter New id ");
                    userInput = Console.ReadLine();
                    updateDrink.id = userInput;
                    itemmBeverage.SaveChanges();// save updated item to database

                }
                else if (userInput == "2")
                {
                    userInput = null; // set userInput to null
                    Console.Write("Enter New name ");
                    userInput = Console.ReadLine();
                    updateDrink.name = userInput;
                    itemmBeverage.SaveChanges();// save updated item to database
                }
                else if (userInput == "3")
                {
                    userInput = null;// set userInput to null
                    Console.Write("Enter New pack ");
                    userInput = Console.ReadLine();
                    updateDrink.pack = userInput;
                    itemmBeverage.SaveChanges();// save updated item to database
                }
                else if (userInput == "4")
                {
                    userInput = null;// set userInput to null
                    Console.Write("Enter New price ");
                    userInput = Console.ReadLine();
                    updateDrink.price = Int32.Parse(userInput);
                    itemmBeverage.SaveChanges();// save updated item to database

                }
                    // updates all
                else if (userInput == "5")
                {
                    userInput = null;// set userInput to null
                    Console.Write("Enter New id ");
                    userInput = Console.ReadLine();
                    updateDrink.id = userInput;
                    Console.Write("Enter New name ");
                    userInput = Console.ReadLine();
                    updateDrink.name = userInput;
                    Console.Write("Enter New pack ");
                    userInput = Console.ReadLine();
                    updateDrink.pack = userInput;
                    Console.Write("Enter New price ");
                    userInput = Console.ReadLine();
                    updateDrink.price = Int32.Parse(userInput);
                    itemmBeverage.SaveChanges(); // save updated item to database
                }
                else if (userInput.Equals("m", StringComparison.OrdinalIgnoreCase))
                {
                    int choice = userInterface.DisplayMenuAndGetResponse();
                }
                else
                {
                    Console.WriteLine("Not A Valid Choice!!");
                }

            
        }
        // Delete from class
        public void DeleteBeverage()
        {
            Console.Write("Enter beverage id");
            userInput = Console.ReadLine();
            Beverage deleteBeverage = itemmBeverage.Beverages.Find(userInput);
            try
            {
                itemmBeverage.Beverages.Remove(deleteBeverage);
                itemmBeverage.SaveChanges();// save changes to database
            }
            catch
            {
                Console.WriteLine("Beverage dose not exist");
                DeleteBeverage();
            }
           
        }
    }

}



