using System;
using System.Collections.Generic;

namespace Home_task_2.Entities;

public partial class Skill
{
    public int IdSkill { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Cvskill> Cvskills { get; set; } = new List<Cvskill>();

    public virtual ICollection<VacancySkill> VacancySkills { get; set; } = new List<VacancySkill>();
}
