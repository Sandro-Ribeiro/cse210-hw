using System;
using System.Runtime.Loader;

public class Customer
{
    private string _name;
    private Address _address;

    public string GetName()
    {
        return _name;
    }

    public Address GetAddress()
    {
        return _address;
    }

   public void SetName(string name)
    {
        _name = name;
    }

    public void SetAddress(Address address)
    {
        _address = address;
    }

    public bool IsLiveInUSA()
    {
        if (_address.AddressInUSA())
        {
            return true;
        }
        else
        {
            return false;            
        }
    }
}