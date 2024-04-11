
using System;

public class CountrySelectedEventArgs  : EventArgs
{
    public Country selectedCountry;

    public CountrySelectedEventArgs(Country selectedCountry)
    {
        this.selectedCountry = selectedCountry;
    }
}
