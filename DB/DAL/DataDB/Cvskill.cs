using System;
using System.Collections.Generic;

namespace Home_task_2.DataDB;

public partial class Cvskill
{
    public int IdCv { get; set; }

    public int IdSkill { get; set; }

    public string? Description { get; set; }

    public virtual Cv IdCvNavigation { get; set; } = null!;

    public virtual Skill IdSkillNavigation { get; set; } = null!;
}
