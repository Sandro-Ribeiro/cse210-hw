using System;
using System.Runtime.CompilerServices;

public class Order
{
    private Customer _customer;

    private List<Product> _products;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public Customer GetCustomer()
    {
        return _customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalCostWithoutShipping()
    {
        double totalCostWithoutShipping = 0;
        foreach (Product product in _products)
        {
            totalCostWithoutShipping += product.GetTotalCost();
        }
        return totalCostWithoutShipping;
    }

    public double CalculateShipping()
    {
        double shipping;
        if (_customer.IsLiveInUSA())
        {
           shipping = 5.00;
        }
        else
        {
            shipping = 35.00;
        }
        return shipping;
        
    }

    public double CalculateTotalCostWithShipping(double totalCostWithoutShipping)
    {
        Double totalCostWithShipping = totalCostWithoutShipping + CalculateShipping();
        return totalCostWithShipping;
    }

    public string GeneratePackingLabel()
    {
        string packingLabel = "*** Packing Label ***\n";
        foreach (Product product in _products)
        {
            packingLabel += $"{product.GetName()} (ID: {product.GetId()})\n";
        }
        return packingLabel;
    }

    public string GenerateShippingLabel()
    {
        string shippingLabel = "*** Shipping Label ***\n";
        shippingLabel += "Customer:\n";
        shippingLabel += $"{_customer.GetName()}\n";
        shippingLabel += $"{_customer.GetAddress().GetStreet()}\n";
        shippingLabel += $"{_customer.GetAddress().GetCity()}\n";
        shippingLabel += $"{_customer.GetAddress().GetCountry()}\n";

        return shippingLabel;
    }

    public string GenerateOrderReceipt()
    {
        int widthMax = 50;
        string titleOrder = $"ORDER RECEIPT";
        int widthRemaining = widthMax - titleOrder.Length;
        int widthLeft = widthRemaining / 2;
        int widthRight = widthRemaining - widthLeft;
        string leftPadding = new string(' ', widthLeft);
        string rightPadding = new string(' ', widthRight);

        string orderReceipt = "";
        orderReceipt += new string('-', widthMax) + "\n";
        orderReceipt += new string(' ', widthMax) + "\n";
        orderReceipt += $"{leftPadding}{titleOrder}{rightPadding}" + "\n";
        orderReceipt += new string(' ', widthMax) + "\n";
        orderReceipt += new string('-', widthMax) + "\n";
        orderReceipt += "\n";
        orderReceipt += GeneratePackingLabel();
        orderReceipt += "\n";
        orderReceipt += GenerateShippingLabel();
        orderReceipt += "\n";

        string term1 = "Product";
        string term2 = "Qty";
        string term3 = "Price";
        string term4 = "Total";
        string term5 = "Subtotal(Without shipping)";
        string term6 = "Shipping";
        string term7 = "Total";

        orderReceipt += new string('-', widthMax) + "\n";
        orderReceipt += $"{term1.PadRight(27)}" +
                        $"{term2.PadLeft(3)}" +
                        $"{term3.PadLeft(10)}" +
                        $"{term4.PadLeft(10)}\n";
        orderReceipt += new string('-', widthMax) + "\n";

        foreach (Product product in _products)
        {
            orderReceipt += $"{product.GetName().PadRight(27)}" +
                            $"{product.GetQuantify().ToString().PadLeft(3)}" +
                            $"{product.GetPrice().ToString("F2").PadLeft(10)}" +
                            $"{product.GetTotalCost().ToString("F2").PadLeft(10)}\n";
            orderReceipt += new string('-', widthMax) + "\n";
        }

        double shipping = CalculateShipping();
        double totalCostWithoutShipping = CalculateTotalCostWithoutShipping();
        double totalCostWithShipping = CalculateTotalCostWithShipping(totalCostWithoutShipping);

        orderReceipt += $"{term5.PadRight(40)}" +
                        $"{totalCostWithoutShipping.ToString("F2").PadLeft(10)}\n";
        orderReceipt += $"{term6.PadRight(40)}" +
                        $"{shipping.ToString("F2").PadLeft(10)} \n";
        orderReceipt += $"{term7.PadRight(40)}" +
                        $"{totalCostWithShipping.ToString("F2").PadLeft(10)} \n";
        orderReceipt += new string('-', widthMax) + "\n";

        return orderReceipt;
        
    }
}