using System;
using System.Collections.Generic;

namespace Home_task_2.Entities;

public partial class Company
{
    public int IdCompany { get; set; }

    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public int? AddressId { get; set; }

    public virtual ICollection<Vacancy> Vacancies { get; set; } = new List<Vacancy>();

    public virtual ICollection<Address> IdAddresses { get; set; } = new List<Address>();
}
