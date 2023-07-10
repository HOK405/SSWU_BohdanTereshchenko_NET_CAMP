using System;
using System.Collections.Generic;

namespace Home_task_2.DataDB;

public partial class Address
{
    public int IdAddress { get; set; }

    public string Country { get; set; } = null!;

    public string Region { get; set; } = null!;

    public string City { get; set; } = null!;

    public string? Street { get; set; }

    public string? BuildingNumber { get; set; }

    public string? ApartmentNumber { get; set; }

    public int? Floor { get; set; }

    public string? PostalCode { get; set; }

    public virtual ICollection<Applicant> Applicants { get; set; } = new List<Applicant>();

    public virtual ICollection<Company> IdCompanies { get; set; } = new List<Company>();

    public override string ToString()
    {
        return $"Address ID: {IdAddress}\n" +
               $"Country: {Country}\n" +
               $"Region: {Region}\n" +
               $"City: {City}\n" +
               $"Street: {Street}\n" +
               $"Building Number: {BuildingNumber}\n" +
               $"Apartment Number: {ApartmentNumber}\n" +
               $"Floor: {Floor}\n" +
               $"Postal Code: {PostalCode}";
    }
}
