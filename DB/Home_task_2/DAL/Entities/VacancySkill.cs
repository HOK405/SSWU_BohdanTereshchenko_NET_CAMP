using System;
using System.Collections.Generic;

namespace Home_task_2.Entities;

public partial class VacancySkill
{
    public int IdSkill { get; set; }

    public int IdVacancy { get; set; }

    public string? Description { get; set; }

    public virtual Skill IdSkillNavigation { get; set; } = null!;

    public virtual Vacancy IdVacancyNavigation { get; set; } = null!;
}
