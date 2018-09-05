using Bomholt.PetShop.UI.InterF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Bomholt.PetShop.UI
{
    public class RunProgram : IRunProgram
    {
        private ILogic _logic;

        public RunProgram(ILogic logic)
        {
            this._logic = logic;
        }
        public void Run()
        {
            Console.WriteLine("PETSHOP CONSOLE MENU");

            bool on = true;
            do
            {
                switch (PrintMenu())
                {
                    case 1:
                        _logic.ShowAllPests();
                        break;
                    case 2:
                        _logic.SearchPetsByType();
                        break;
                    case 3:
                        _logic.CreateNewPet();
                        break;
                    case 4:
                        _logic.DeletePetById();
                        break;
                    case 5:
                        _logic.UpdatePet();
                        break;
                    case 6:
                        _logic.SortPetsByPrice();
                        break;
                    case 7:
                        _logic.Get5CheapestPets();
                        break;
                    case 8:
                         _logic.Exit();
                        on = false;
                        break;
                }
            } while (on);
        }

        public int PrintMenu()
        {
            string[] MenuItems = { "Show list of all Pets", "Search Pets by Type", "Create a new Pet", "Delete Pet", "Update a Pet", "Sort Pets By Price", "Get 5 cheapest available Pets", "Exit" };
            int Select;
            Console.WriteLine();
            for (int i = 0; i < MenuItems.Length; i++)
            {
                Console.WriteLine($"{i + 1} | {MenuItems[i]}");
            }

            do
            {
                Console.Write("Select 1-8 and press enter: ");
            } while (!int.TryParse(Console.ReadLine(), out Select) || Select > 8 || Select < 1);
            return Select;
        }

        
    }
}
