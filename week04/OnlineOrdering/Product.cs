using System;

public class Product
{
    private int _id;
    private string _name;
    private double _price;
    private int _quantity;

    public int GetId()
    {
        return _id;
    }

    public string GetName()
    {
        return _name;
    }

    public double GetPrice()
    {
        return _price;
    }

    public int GetQuantify()
    {
        return _quantity;
    }

    public void SetId(int id)
    {
         _id = id;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public void SetPrice(double price)
    {
        _price = price;
    }

    public void SetQuantify(int quantify)
    {
        _quantity = quantify;
    }


    public double GetTotalCost()
    {
        return _price * _quantity;
    }
}