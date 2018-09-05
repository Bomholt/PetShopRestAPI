using Bomholt.PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bomholt.PetShop.UI.InterF
{
    public interface ILogic
    {
        void ShowAllPests();
        void Exit();
        void DeletePetById();
        void CreateNewPet();
        void DateTimeTest();
        void UpdatePet();
        void SearchPetsByType();
        void SortPetsByPrice();
        void Get5CheapestPets();
    }
}
