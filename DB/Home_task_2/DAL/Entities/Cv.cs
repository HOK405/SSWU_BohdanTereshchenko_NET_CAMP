using System;
using System.Collections.Generic;

namespace Home_task_2.Entities;

public partial class Cv
{
    public int IdCv { get; set; }

    public int ApplicantId { get; set; }

    public int JobId { get; set; }

    public int? Salery { get; set; }

    public virtual Applicant Applicant { get; set; } = null!;

    public virtual ICollection<Cvskill> Cvskills { get; set; } = new List<Cvskill>();

    public virtual ICollection<Interview> Interviews { get; set; } = new List<Interview>();

    public virtual Job Job { get; set; } = null!;

    public override string ToString()
    {
        string salaryInfo = Salery.HasValue ? $"Salary: {Salery}" : "Salary information not available";

        return $"CV ID: {IdCv}\n" +
               $"Applicant ID: {ApplicantId}\n" +
               $"Job ID: {JobId}\n" +
               salaryInfo;
    }
}
