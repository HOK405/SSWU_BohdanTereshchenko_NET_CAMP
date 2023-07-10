using System;
using System.Collections.Generic;

namespace Home_task_2.DataDB;

public partial class Job
{
    public int IdJob { get; set; }

    public string JobTitle { get; set; } = null!;

    public string? JobLevel { get; set; }

    public virtual ICollection<Cv> Cvs { get; set; } = new List<Cv>();

    public virtual ICollection<Vacancy> Vacancies { get; set; } = new List<Vacancy>();
}
