using System;
using System.Collections.Generic;

namespace Home_task_2.DataDB;

public partial class Vacancy
{
    public int IdVacancy { get; set; }

    public int JobId { get; set; }

    public string? VacancyDescription { get; set; }

    public int CompanyId { get; set; }

    public int? Salery { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<Interview> Interviews { get; set; } = new List<Interview>();

    public virtual Job Job { get; set; } = null!;

    public virtual ICollection<VacancySkill> VacancySkills { get; set; } = new List<VacancySkill>();
}
