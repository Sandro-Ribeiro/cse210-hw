using System;
using System.Runtime.Loader;


public class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;


    public string GetStreet()
    {
        return _street;
    }

    public string GetCity()
    {
        return _city;
    }

    public string GetState()
    {
        return _state;
    }

    public string GetCountry()
    {
        return _country;
    }

    public void SetStreet(string street)
    {
        _street = street;
    }

    public void SetCity(string city)
    {
        _city = city;
    }

    public void SetState(string state)
    {
        _state = state;
    }

    public void SetCountry(string country)
    {
        _country = country;
    }

    public bool AddressInUSA()
    {
        if (_country == "USA")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public string Display()
    {
        string address = $"{_street}\n{_city}\n{_state}\n{_country}";
        return address;
    }

}