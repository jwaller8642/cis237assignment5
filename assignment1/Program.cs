//Author: David Barnes
//CIS 237
//Assignment 1
/*
 * The Menu Choices Displayed By The UI
 * 1. Load Wine List From CSV
 * 2. Print The Entire List Of Items
 * 3. Search For An Item
 * 4. Add New Item To The List
 * 5. Exit Program
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Set a constant for the size of the collection
            const int wineItemCollectionSize = 4000;
            // path to BevCollection class
            BeverageCollection dbBev = new BeverageCollection();
            // path to bev item class
            BeverageItem beverageItem = new BeverageItem();
            //Set a constant for the path to the CSV File
            const string pathToCSVFile = "../../../datafiles/winelist.csv";

            //Create an instance of the UserInterface class
            UserInterface userInterface = new UserInterface();

            //Create an instance of the WineItemCollection class
            IWineCollection wineItemCollection = new WineItemCollection(wineItemCollectionSize);

            //Create an instance of the CSVProcessor class
            CSVProcessor csvProcessor = new CSVProcessor();

            //Display the Welcome Message to the user
            userInterface.DisplayWelcomeGreeting();

            //Display the Menu and get the response. Store the response in the choice integer
            //This is the 'primer' run of displaying and getting.
            int choice = userInterface.DisplayMenuAndGetResponse();

            while (choice != 6)
            {
                switch (choice)
                {
                    case 111:
                        //Load the CSV File
                        bool success = csvProcessor.ImportCSV(wineItemCollection, pathToCSVFile);
                        if (success)
                        {
                            //Display Success Message
                            userInterface.DisplayImportSuccess();
                        }
                        else
                        {
                            //Display Fail Message
                            userInterface.DisplayImportError();
                        }
                        break;

                    case 112:
                        //Print Entire List Of Items
                        string[] allItems = wineItemCollection.GetPrintStringsForAllItems();
                        if (allItems.Length > 0)
                        {
                            //Display all of the items
                            userInterface.DisplayAllItems(allItems);
                        }
                        else
                        {
                            //Display error message for all items
                            userInterface.DisplayAllItemsError();
                        }
                        break;

                    case 113:
                        //Search For An Item
                        string searchQuery = userInterface.GetSearchQuery();
                        string itemInformation = wineItemCollection.FindById(searchQuery);
                        if (itemInformation != null)
                        {
                            userInterface.DisplayItemFound(itemInformation);
                        }
                        else
                        {
                            userInterface.DisplayItemFoundError();
                        }
                        break;

                    case 114:
                        //Add A New Item To The List
                        string[] newItemInformation = userInterface.GetNewItemInformation();
                        if (wineItemCollection.FindById(newItemInformation[0]) == null)
                        {
                            wineItemCollection.AddNewItem(newItemInformation[0], newItemInformation[1], newItemInformation[2]);
                            userInterface.DisplayAddWineItemSuccess();
                        }
                        else
                        {
                            userInterface.DisplayItemAlreadyExistsError();
                        }
                        break;

                    case 1:
                        // calls print method
                        dbBev.printBeverage();
                        break;

                    case 2:
                        // calls add method
                        dbBev.AddBeverage();
                        break;
                    case 3:
                        // calls search method
                        dbBev.SearchBeverage();
                        break;
                    case 4:
                        // calls update method
                        beverageItem.UpdateBeverge();
                        break;
                    case 5:
                        //calls delte method
                        beverageItem.DeleteBeverage();
                        break;

                }

                //Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();
            }

        }
    }
}
