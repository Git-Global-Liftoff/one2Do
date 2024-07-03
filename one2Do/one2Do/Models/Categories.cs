using System;
using System.ComponentModel;

namespace one2Do.Models;

public class Categories
{
public int Id { get; set; }
public string[] ListType = new string[]
{
    "household",
    "errands",
    "professional",
    "personal"
};

public Categories(int id, string[] listType)
{
    Id = id;
    ListType = listType;

}
    

public Categories()
{

}

}




