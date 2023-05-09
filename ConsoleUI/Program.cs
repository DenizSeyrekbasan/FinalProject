using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            var result = productManager.GetProductDetails();

            if (result.Success==true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + "/" + product.CategoryId);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            




            //ProductManager productManager = new ProductManager(new EfProductDal());
            //foreach (var product in productManager.GetProductDetails())
            //{
            //    Console.WriteLine(product.ProductName + "/" + product.CategoryId);
            //}

            //EmployeeManager employeeManager = new EmployeeManager(new EfEmployeeDal());
            //foreach (var employee in employeeManager.GetAll())
            //{
            //    Console.WriteLine(employee.FirstName);
            //}

            //ProductManager productManager = new ProductManager(new EfProductDal());
            //foreach (var product in productManager.GetByUnitPrice(50, 500))
            //{
            //    Console.WriteLine(product.ProductName);
            //}

            //OrderManager orderManager = new OrderManager(new EfOrderDal());
            //foreach (var order in orderManager.GetAll())
            //{
            //    Console.WriteLine(order.OrderID);
            //}


            Console.Read();
        }
    }
}