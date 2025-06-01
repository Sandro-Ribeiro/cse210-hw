using System;

class Program
{
    static void Main(string[] args)
    {
        // ----- CUSTOMER 1 (Lives in USA) -----
        Address address1 = new Address();
        address1.SetStreet("123 Maple Street");
        address1.SetCity("Springfield");
        address1.SetState("IL");
        address1.SetCountry("USA");

        Customer customer1 = new Customer();
        customer1.SetName("Joseph Smith");
        customer1.SetAddress(address1);

        Order order1 = new Order(customer1);
        Product prod1 = new Product();
        prod1.SetId(101);
        prod1.SetName("Wireless Mouse");
        prod1.SetPrice(25.00);
        prod1.SetQuantify(2);

        Product prod2 = new Product();
        prod2.SetId(102);
        prod2.SetName("Keyboard");
        prod2.SetPrice(45.00);
        prod2.SetQuantify(1);

        order1.AddProduct(prod1);
        order1.AddProduct(prod2);

        // ----- CUSTOMER 2 (Lives outside USA) -----
        Address address2 = new Address();
        address2.SetStreet("Alameda Vermelha, 345");
        address2.SetCity("Uberaba");
        address2.SetState("MG");
        address2.SetCountry("Brazil");

        Customer customer2 = new Customer();
        customer2.SetName("Ana Clara Rocha Ribeiro");
        customer2.SetAddress(address2);

        Order order2 = new Order(customer2);
        Product prod3 = new Product();
        prod3.SetId(201);
        prod3.SetName("Notebook");
        prod3.SetPrice(3000.00);
        prod3.SetQuantify(1);

        Product prod4 = new Product();
        prod4.SetId(202);
        prod4.SetName("Backpack");
        prod4.SetPrice(150.00);
        prod4.SetQuantify(1);

        order2.AddProduct(prod3);
        order2.AddProduct(prod4);

        Console.Clear();

        // ----- DISPLAYING ORDER 1 -----
        Console.Clear();
        Console.WriteLine(order1.GenerateOrderReceipt());

        Console.WriteLine();
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();



        // ----- DISPLAYING ORDER 2 -----
        Console.Clear();
        Console.WriteLine(order2.GenerateOrderReceipt());

        Console.WriteLine();
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
        
        Console.Clear();

    }
}
