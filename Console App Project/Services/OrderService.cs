using Console_App_Project.Enums;
using Console_App_Project.Modles;
using Console_App_Project.Repository;
using Console_App_Project.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_Project.Services
{
    internal class OrderService
    {


        public readonly string _orderPath = Helper.OrderDataFilePathFinder();

        public readonly string _Productpath = Helper.ProductDataFilePathFinder();

        public Repository<Order> OrderRepository { get; set; } = new Repository<Order>();
        public Repository<Product> ProductRepository { get; set; } = new Repository<Product>();


        public void OrderProduct(string email)
        {

            List<Order> orders = OrderRepository.LoadOrCreateListFromJson(_orderPath);
            Order order = null;
            bool addingProducts = true;

            // Get Product Details from User

            OrderStatus status= OrderStatus.Pending;
            Console.Clear();
            Helper.LogoMini();

       

            order = new Order(email, status);

            while (addingProducts)
            {
                List<Product> products = ProductRepository.LoadOrCreateListFromJson(_Productpath);
                OrderItem item = null;
                while (true)
                {
                    // Show all products
                    ProductService ShowAllProducts = new ProductService();
                    ShowAllProducts.ShowAllProducts();
                    if(Helper.EscToCancer())
                        return;

                    //Product by Id
                    Helper.ColorfulWriteLine("Enter Product Id ", ConsoleColor.Green);
                    string id = Helper.GetStringInput();

                    //Count
                    Console.Clear();
                    Helper.LogoMini();
                    Helper.ColorfulWriteLine("Enter Count", ConsoleColor.Green);
                    int count = Helper.GetIntInput();


                    Product selectedProduct = products.FirstOrDefault(p => p.Id == id);

                    if (selectedProduct == null)
                    {
                        Console.Clear();
                        Helper.LogoMini();
                        Helper.ColorfulWriteLine("Product not found.", ConsoleColor.DarkRed);
                        Helper.Pause();
                        Console.Clear();
                    }

                    else if (selectedProduct.Stock < count)
                    {
                        Console.Clear();
                        Helper.LogoMini();
                        Helper.ColorfulWriteLine($"Not enough stock. Available: {selectedProduct.Stock}", ConsoleColor.DarkRed);
                        Helper.Pause();
                        Console.Clear ();
                    }

                    else
                    {
                        selectedProduct.Stock -= count;
                        item = new OrderItem(selectedProduct, count, selectedProduct.Price);
                        ProductRepository.SerializeJson(_Productpath, products);
                        break;
                    }
                }
                //Create Order Object

                var existedOrderItem = order.Items.FirstOrDefault(i => i.Product.Id == item.Product.Id);

                if (existedOrderItem != null)
                {
                    existedOrderItem.Price += item.Price;
                    existedOrderItem.Count += item.Count;
                }

                else
                   order.Items.Add(item);
                Console.WriteLine("Add another product?");
                addingProducts = Helper.GetYesNoChoice();


            }
            orders.Add(order);
            OrderRepository.SerializeJson(_orderPath, orders);
            Helper.ColorfulWriteLine("Order created", ConsoleColor.Green);
            order.PrintInfo();
            Helper.Pause();
            Console.Clear();
        }

        public void ShowAllOrders()
        {
            Console.Clear();
            List<Order> orders = OrderRepository.LoadOrCreateListFromJson(_orderPath);
            if (orders.Count == 0)
            {
                Console.WriteLine("No Ordes available.");
                return;
            }
            foreach (var order in orders) 
            {
                order.PrintInfo();
            }
            Helper.Pause();
            Console.Clear();
        }






        public void ChangeStatus()
        {
            ShowAllOrders();

            Helper.ColorfulWriteLine("Change Status ", ConsoleColor.Green);

            if (Helper.EscToCancer())
                return;
            while (true)
            {

                List<Order> orders = OrderRepository.LoadOrCreateListFromJson(_orderPath);

                Helper.ColorfulWriteLine("Enter Order Id  ", ConsoleColor.Cyan);

                string id = Helper.GetStringInput();

          

      


                Order selectedOrder = orders.FirstOrDefault(o => o.Id == id);


                if (selectedOrder == null)
                {
                    Helper.ColorfulWriteLine("Order not found", ConsoleColor.DarkRed);
                    Helper.Pause(); 
                    Console.Clear();
                    return;
                }

                bool status = true;

                Console.Clear();
                while (status)
                {
                    Console.Clear();

                    Helper.ShowOrderStatusMenu();
                    switch (Helper.GetIntInput())
                    {
                       
                        case 1:
                            selectedOrder.Status = OrderStatus.Pending;
                            status = false;
                            break;
                     
                        case 2:
                            selectedOrder.Status = OrderStatus.Confirmed;
                            status = false;
                            break;
                      
                        case 3:
                            selectedOrder.Status = OrderStatus.Completed;
                            status = false;

                            break;

                            //exit
                       
                        case 0:
                            Console.Clear();
                            Helper.ColorfulWriteLine("Are you sure you want to exit ?", ConsoleColor.Yellow);

                            if (Helper.GetYesNoChoice())
                            {
                                Helper.ColorfulWriteLine("Exiting the program", ConsoleColor.DarkRed);
                                Helper.Pause();
                                Console.Clear();
                                return;
                            }
                            break;

                            //default
                      
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                    Console.Clear();
                }

                OrderRepository.SerializeJson(_orderPath, orders);
                break;
            }
        }

    }
}