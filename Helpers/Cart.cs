using System;
using System.ComponentModel.Design;
using System.IO.Compression;
using System.Security.Cryptography;

namespace PracticeFinal.Cart{
    public static class Constants{
        public const int CAP = 20;
        public const int ARR_LEN = 50;
        public static readonly string[] MENU_ITEMS = {
            "Add Item",
            "Remove Item",
            "Modify Item",
            "Print Cart",
            "Checkout"
        };
    }
    public class Item{
        public string? Name {get; set;}
        public double? Cost {get; set;}
        public int? Quantity {get; set;}

        public static void AddItem(List<Item> itemlist){
            string? nameBuffer = null;
            int? quantBuffer = null;
            double? costBuffer = null;

            Helpers.TextualInput("Name: ", ref nameBuffer);
            Helpers.GetInt("Quantity: ", ref quantBuffer);
            Helpers.GetDouble("Cost: ", ref costBuffer);
            
            Item newItem = new() {
                Name = nameBuffer,
                Quantity = quantBuffer,
                Cost = costBuffer
            };

            itemlist.Add(newItem);
            Console.WriteLine();
        }

        public static void PrintList(List<Item> itemList){
            for (int i = 0;i < itemList.Count(); i++){
                Console.Write($"0{i + 1} Name: {itemList[i].Name}, ");
                Console.Write($"Quantity: {itemList[i].Quantity}, ");
                Console.Write($"Cost: {itemList[i].Cost}, ");
                Console.WriteLine($"Total: {itemList[i].Cost * itemList[i].Quantity}");
            }
            Console.WriteLine();
        }

        public static void RemoveItem(List<Item> itemList){
            int menuOption = -1;

            PrintList(itemList);
            Helpers.MenuOption("Select a list item to remove: ", ref menuOption, itemList.Count());
        }
    }

    public class Helpers{
        public static void Menu(){
            for (int i = 0; i < Constants.MENU_ITEMS.Count(); i++){
                Console.WriteLine($"0{i + 1} {Constants.MENU_ITEMS[i]}");
            }
        }

        public static void MenuOption(string prompt, ref int option, int count){
            int inputBuffer;
            char inputCharacter;

            do{
                Console.Write(prompt);
                inputBuffer = Console.Read();
                Console.ReadLine();

                inputCharacter = (char)inputBuffer;
                if (char.IsDigit(inputCharacter)){
                    inputBuffer = (int)char.GetNumericValue(inputCharacter);
                    if(inputBuffer > 0 && inputBuffer < 6){
                        option = inputBuffer;
                    } else {
                        Console.WriteLine($"Menu options are 1 through {count}.");
                    }
                } else {
                        Console.WriteLine("Invalid menu option");
                }
            }while (option != inputBuffer);
        }

        public static void HandleOption(List<Item> itemList, int option){
            switch(option){
                case 1:
                    Item.AddItem(itemList);
                    break;
                case 2:
                    Item.RemoveItem(itemList);
                    break;
                case 3:
                    Console.WriteLine("3");
                    break;
                case 4:
                    Item.PrintList(itemList);
                    break;
                case 5:
                    Console.WriteLine("5");
                    break;
                default:
                    break;
            }
        }

        public static void TextualInput(string prompt, ref string? userString){
            do{
                Console.Write(prompt);
                userString = Console.ReadLine();
                if (userString == null || userString == ""){
                    Console.WriteLine($"Input error, please try again.");
                }
            }while(userString == null || userString == "");
        }

        public static void GetInt(string prompt, ref int? num){
            string? inputBuffer;
            bool loopState = true;

            do
            {
                Console.Write(prompt);
                inputBuffer = Console.ReadLine();
                if (int.TryParse(inputBuffer, out int tempNum)){
                    num = tempNum;
                    loopState = false;
                } else {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            }while (loopState);
        }
        
        public static void GetDouble(string prompt, ref double? num){
            string? inputBuffer;
            bool loopState = true;

            do{
                Console.Write(prompt);
                inputBuffer = Console.ReadLine();
                if (double.TryParse(inputBuffer, out double tempNum)){
                    num = tempNum;
                    loopState = false;
                } else {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }while (loopState);
        }
    }
}