using System;
using System.Collections.Generic;

namespace Home_task_2.DataDB;

public partial class Applicant
{
    public int IdApplicant { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public DateTime? DateOfBirth { get; set; }

    public int? AddressId { get; set; }

    public virtual Address? Address { get; set; }

    public virtual ICollection<Cv> Cvs { get; set; } = new List<Cv>();

    public override string ToString()
    {
        string addressInfo = Address != null ? $"Address: {Address}" : "No address information";

        return $"Applicant ID: {IdApplicant}\n" +
               $"Name: {Name}\n" +
               $"Email: {Email}\n" +
               $"Phone: {Phone}\n" +
               $"Date of Birth: {DateOfBirth?.ToString("yyyy-MM-dd") ?? "N/A"}\n" +
               addressInfo;
    }
}
