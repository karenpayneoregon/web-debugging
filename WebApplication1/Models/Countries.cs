﻿
#nullable disable
namespace WebApplication1.Models;

public partial class Countries
{
    public int Id { get; set; }

    public string Iso { get; set; }

    public string Name { get; set; }

    public string Iso3 { get; set; }

    public int? NumCode { get; set; }

    public int PhoneCode { get; set; }
}