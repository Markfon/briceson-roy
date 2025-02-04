﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantDL;
using RestaurantBL;
using Models;

namespace RestaurantUI
{
    internal class AddReviewMenu : IMenu
    {
        int id;

        private static Review newReview = new Review();
        private IRepository _repository = new SqlRepository();

        public AddReviewMenu(int id)
        {
            this.id = id;    
        }

        public void Display()
        {
            Console.WriteLine("Press <1> to add stars to your Review");
            Console.WriteLine("Press <2> to add a Note to the review");
            Console.WriteLine("Press <3> to save the review");
            Console.WriteLine("Press <0> to return to the main menu");
        }

        public string UserChoice()
        {
            Display();
            string userInput = Console.ReadLine();
            switch (userInput) {
                case "0":
                    return "MainMenu";
                case "1":
                    Console.Write("Please Add the star count to the review: ");
                    newReview.Rating = Convert.ToInt32(Console.ReadLine());
                    goto case "2";
                case "2":
                    Console.Write("Please enter any specific notes you want to add about the service. ");
                    newReview.Note = Console.ReadLine();
                    goto case "3";
                case "3":
                  try
                    {
                        newReview.RestaurantId = id;
                        _repository.AddReview(newReview);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    return "MainMenu";
                /// Add more cases for any other attributes of pokemon
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "AddRestaurant";
            }
        }
    }
}
     