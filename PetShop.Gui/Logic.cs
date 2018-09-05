using Bomholt.PetShop.Core.ApplicationService;
using Bomholt.PetShop.Core.Entities;
using Bomholt.PetShop.UI.InterF;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace Bomholt.PetShop.UI
{
    class Logic : ILogic 
    {
        private IPetService _petService;

        public Logic(IPetService petService)
        {
            _petService = petService;
        }

        public void DateTimeTest()
        {
            DateTime dateTime;
            while (!DateTime.TryParse(AskQuestion("Type In DateTime"), out dateTime))
            {
                Console.WriteLine("WRONG!!!!");
            }
            Console.WriteLine("DateTime: {0}", dateTime);

            //bool TryParse(string s, out DateTime result);
        }

        public void CreateNewPet()
        {
            Console.WriteLine("You chose: Create a new Pet");
            Pet newPet = new Pet()
            {
                Name = AskQuestion("Type Name Please:"),
                Type = AskQuestion("Type Type Please:"),
                Color = AskQuestion("Type Color Please:"),
                Birthdate = AskForDate("Type pets birthdate:"),
                Solddate = AskForDate("Type sold date"),
                PreviousOwner = AskQuestion("Type Name of former owner Please:"),
                Price = Convert.ToDouble(AskQuestion("Type in prize please:"))
            };
            bool success = _petService.CreateNewPet(newPet);
        }

        public void DeletePetById()
        {
            Console.WriteLine("You chose: Delete a Pet");
            //OneLiner!!!
            Console.WriteLine( _petService.DeletePetById(AskForInt("Type the id of the pet to delete:"))? "\nThe Pet was successfully deleted!" : "\nNo Pet with that id found!");

            //int petId;
            //while (!int.TryParse(AskQuestion("Type the id of the pet to delete:"), out petId))
            //{
            //    Console.WriteLine("A number please!");
            //}
            //bool Succes = _petService.DeletePetById(petId);
            //if (Succes)
            //{
            //    Console.WriteLine("\nThe Pet was successfully deleted!");
            //}
            //else
            //{
            //    Console.WriteLine("\nNo Pet with that id found!");
            //}
        }

        public void Exit()
        {
            Console.Clear();
            for (int i = 0; i < 327; i++)
            {
                Console.Write("       EXIT");
                Thread.Sleep(1);
            }
        }

        public void ShowAllPests()
        {
            var list = _petService.GetAllPets();
            PrintListOfPets(list);
        }

        private string AskQuestion(string quest)
        {
            Console.Write(" {0} ", quest);
            return Console.ReadLine();
        }

        public DateTime AskForDate(string q)
        {
            Console.WriteLine(q);
            DateTime dateTime;
            while (!DateTime.TryParse(AskQuestion("Type In Date in format: DD/MM/YY "), out dateTime))
            {
                Console.WriteLine("WRONG!!!!");
            }
            return dateTime;
        }

        private int AskForInt(string q)
        {
            int number;
            while (!int.TryParse(AskQuestion(q), out number))
            {
                Console.WriteLine("A number please!");
            }
            return number;
        }

        private double AskForDouble(string q)
        {
            double number;
            while (!double.TryParse(AskQuestion(q), out number))
            {
                Console.WriteLine("A double please!");
            }
            return number;
        }

        private void PrintListOfPets(List<Pet> list)
        {
            Console.WriteLine("\nPESTS:\n");
            Console.WriteLine("| {0,-2}| {1,-10}| {2,-10}| {3,-10}| {4,-10}| {5,-10}| {6,-20}| {7,-14}| ", 
                "ID", "NAME", "TYPE", "COLOR", "BIRTHDATE", "SOLDDATE", "PREVIOUSOWNER", "PRICE");
            Console.WriteLine("+---+-----------+-----------+-----------+-----------+-----------+---------------------+---------------+");
            foreach (var item in list)
            {
                Console.WriteLine("| {0,2}| {1,-10}| {2,-10}| {3,-10}| {4,10}| {5,10}| {6,-20}| {7,14}|", 
                    item.ID, item.Name, item.Type, item.Color, item.Birthdate.ToShortDateString() , item.Solddate.ToShortDateString(), 
                    item.PreviousOwner, item.Price.ToString("C2",CultureInfo.CreateSpecificCulture("da-DK")));
                Console.WriteLine("+---+-----------+-----------+-----------+-----------+-----------+---------------------+---------------+");

            }
        }

        public void UpdatePet()
        {
            Console.WriteLine("You chose: Update a Pet");
            Pet UpdatedPet = new Pet()
            {
                ID = AskForInt("Type the id of the pet you want to update"),
                Name = AskQuestion("Type new Name Please:"),
                Type = AskQuestion("Type new Type Please:"),
                Color = AskQuestion("Type new Color Please:"),
                Birthdate = AskForDate("Type pets birthdate:"),
                Solddate = AskForDate("Type sold date"),
                PreviousOwner = AskQuestion("Type Name of former owner Please:"),
                Price = AskForDouble("Type in prize please:")
            };
            bool success = _petService.UpdatePet(UpdatedPet);
            Console.WriteLine(success?"Pet updated successsfuly":"No pet with that id found");
        }

        public void SearchPetsByType()
        {
            Console.WriteLine("You chose: Search Pets by Type");
            string SearchType = AskQuestion("What type do you want to search for?");
            List<Pet> PetByType = _petService.SearchPetsByType(SearchType);
            if (PetByType.Count==0)
            {
                Console.WriteLine("No pets of that type was found");
            }
            else
            {
                PrintListOfPets(PetByType);
            }
        }

        public void SortPetsByPrice()
        {
            Console.WriteLine("You chose: Sort Pets By Price");
            List<Pet> ByPrice = _petService.SortPetsByPrice();
            PrintListOfPets(ByPrice);
        }

        public void Get5CheapestPets()
        {
            Console.WriteLine("You chose: Get 5 cheapest available Pets");
            List<Pet> FiveCheapest = _petService.Get5CheapestPets();
            PrintListOfPets(FiveCheapest);
        }
    }
}
