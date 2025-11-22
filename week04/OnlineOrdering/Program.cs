using System;

class Program
{
    static void Main(string[] args)
    {
        // ----- Order #1 -----
        Address address1 = new Address("123 Main St", "Salt Lake City", "UT", "USA");
        Customer customer1 = new Customer("Julio Castillo", address1);

        Product p1 = new Product("Water Bottle", "WB1001", 12.50, 2);
        Product p2 = new Product("Running Belt", "RB2003", 18.99, 1);

        Order order1 = new Order(customer1);
        order1.AddProduct(p1);
        order1.AddProduct(p2);

        Console.WriteLine("====== ORDER 1 ======");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalCost()}\n");


        // ----- Order #2 -----
        Address address2 = new Address("45 Avenida Norte", "Santo Domingo", "DN", "Dominican Republic");
        Customer customer2 = new Customer("Maria Gomez", address2);

        Product p3 = new Product("Yoga Mat", "YM3002", 25.00, 1);
        Product p4 = new Product("Dumbbells Set", "DS1500", 40.00, 1);
        Product p5 = new Product("Jump Rope", "JR500", 7.50, 3);

        Order order2 = new Order(customer2);
        order2.AddProduct(p3);
        order2.AddProduct(p4);
        order2.AddProduct(p5);

        Console.WriteLine("====== ORDER 2 ======");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalCost()}");
    }
}
