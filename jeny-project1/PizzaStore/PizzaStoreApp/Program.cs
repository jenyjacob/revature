using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
/*using PizzaStore.DataAccess.Entities;
using PizzaStore.Library;*/

namespace PizzaStoreApp
{
    public class Program
    {
        public static void Main()
        {

            //  IStoreRepo pizzaapp = Dependencies.CreateRepository();

            // GetCustomerByName(pizzaapp);
            // UiApp(pizzaapp);

        }



        /* public static void UiApp(IStoreRepo pizzaapp)
         {
             while (true)
             {
                 Console.WriteLine();
                 Console.WriteLine();
                 Console.WriteLine("  \t \t Welcome to Pizza Store");
                 Console.WriteLine();
                 Console.WriteLine("If you are a new Customer, Please type 'y' or else please type 'n' ");

                 Console.WriteLine();
                 Console.Write("Enter valid menu option, or \"q\" to quit: ");
                 var input = Console.ReadLine();

                 if (input == "y")
                 {
                     Console.WriteLine();
                     Console.WriteLine("Please enter your details: ");
                     var customer = new PizzaStore.Library.Customer();



                         Console.WriteLine();
                         try
                         {
                             Console.Write("Enter PhoneNumber: ");
                             input = Console.ReadLine();
                             bool isValid = input.Length == 10 && input.All(char.IsDigit);
                             if (isValid == true)
                             {
                                 customer.ID = input;
                                 Console.Write("Enter FirstName: ");
                                 input = Console.ReadLine();
                                 customer.FirstName = input;
                                 Console.Write("Enter LastName: ");
                                 input = Console.ReadLine();
                                 customer.LastName = input;
                             }
                             else
                             {
                                 Console.WriteLine("Is not a valid format,please enter the Phone Number ");
                                 Console.WriteLine();
                             }
                         }
                         catch (ArgumentException ex)
                         {

                             Console.WriteLine(ex.Message);
                         }


                     pizzaapp.AddCustomer(customer);

                     pizzaapp.Save();
                     Console.WriteLine("Your Details has been added succesfully");
                     Console.WriteLine();
                     Console.WriteLine("Here's the Display of Store Locations ");

                     pizzaapp.DisplayStore();
                     Console.WriteLine();
                    *//* Console.Write("Enter your Prefered Store Number from the above display: ");
                     var storeid = Console.ReadLine();*//*
                      Console.Write("Enter your Prefered Store Number from the above display: ");
                                 var storeid = Int32.Parse(Console.ReadLine());

                                 Console.WriteLine("Here's are the items available ");
                                 Console.WriteLine();
                                *//* var pro = pizzaapp.GetProductDetails(storeid);
                                 foreach (var prod in pro)
                                 {

                                     Console.WriteLine($" product Number: {prod.ProductId}, Product Name: {prod.ProductName},Price: {prod.Cost}" );


                                 }*//*



                 }
                 else if (input == "n")
                 {
                     Console.WriteLine();
                     Console.Write("please enter the FirstName : ");

                     var name = Console.ReadLine();
                     var resultset = pizzaapp.GetCustomerByName(name);
                     try
                     {
                         Console.WriteLine(resultset.FirstName + " " + resultset.LastName + ", Phone Number: " + resultset.ID);
                         pizzaapp.Save();
                         while (true)
                         {
                             Console.WriteLine();

                             Console.WriteLine("1:\t Place an order ");
                            // Console.WriteLine("2:\t Lookup order history");
                             Console.WriteLine("3:\t Lookup orders of a store");
                            // Console.WriteLine("4:\t ");
                             Console.WriteLine("type q to exit the order");
                             var option = Console.ReadLine();
                             //  Console.WriteLine("3:\t Lookup order history by Store");
                             if (option == "1")
                             {
                                 Console.WriteLine("Here are the list of Store Locations ");

                                 pizzaapp.DisplayStore();
                                 Console.WriteLine();



                             }
                     *//*        else if (option == "2")
                             {

                                 Console.WriteLine("enter your PhoneNumber : ");
                                 var fname = Console.ReadLine();
                                 //int fid = Int.Parse(fname);
                                // int con = Convert.ToDecimal(fid);

                                 try
                                 {
                                     var id = pizzaapp.DisplayOrderHistoryByCustomerName(fid).ToList();

                                     foreach (var cus in id)
                                     {



                                         Console.WriteLine($" Order Date: {cus.OrderDate}  ,PhomeNumber:{cus.CustomerId} and Order Id: {cus.OrderId}" );
                                        // var js = pizzaapp.GetProductDetails(cus.OrderId).ToList();

                                        // Console.WriteLine(js.);
                                     }

                                     //var js = pizzaapp.GetProductDetails().ToList();
                                    *//* foreach(var jj in js)
                                     {
                                         Console.WriteLine(jj.ProductId + " " +jj.ProductName);
                                     }*//*
                                 }
                                 catch (FormatException)
                                 {
                                     Console.WriteLine("Please enter the phone number ");
                                 }
                                 catch (ArgumentNullException)
                                 {
                                     Console.WriteLine("There is no order history ");
                                 }



                             }*//*
                             else if (option == "3")
                             {

                                 Console.WriteLine("enter store number: ");
                                 var z = int.Parse(Console.ReadLine());
                                 try
                                 {
                                     var id = pizzaapp.DisplayOrderHistoryByStoreId(z).ToList();
                                     foreach (var cus in id)
                                     {


                                         Console.WriteLine(cus.OrderDate + " " + cus.CustomerId + " " + cus.OrderId);

                                     }
                                 }
                                 catch (ArgumentNullException)
                                 { 
                                     Console.WriteLine("We couldn't find the store. ");
                                 }
                             }

                             else if(option == "q")
                             {
                                 break;
                             }
                             else
                             {
                                 Console.WriteLine();
                                 Console.WriteLine($"Invalid input \"{input}\".");

                             }


                         }
                     }
                     catch (NullReferenceException ex)
                     {
                         Console.WriteLine("Could not find the name.", ex);
                     }





                 }
                 else if (input== "q")
                 {

                     break;
                 }
                 else
                 {
                     Console.WriteLine();
                     Console.WriteLine($"Invalid input \"{input}\".");

                 }
             }
         }
     }
 }

 */

    }
}