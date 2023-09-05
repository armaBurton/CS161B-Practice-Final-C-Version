using System;
using System.ComponentModel.Design;
using System.Linq;
using PracticeFinal.Cart;

namespace PracticeFinal{
    class Program{
        static void Main(){
            List<Item> itemList = new List<Item>();
            int option = 0;
            do{
                Helpers.Menu();
                Console.WriteLine();
                Helpers.MenuOption("What would you like to do? ", ref option, Constants.MENU_ITEMS);
                Helpers.HandleOption(itemList, option);
            }while(option != 5);
        }
    }
}

