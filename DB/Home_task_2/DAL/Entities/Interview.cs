using System;
using System.Collections.Generic;

namespace Home_task_2.Entities;

public partial class Interview
{
    public int IdInterview { get; set; }

    public int IdCv { get; set; }

    public int IdVacancy { get; set; }

    public DateTime InterviewDate { get; set; }

    public bool? ResultIsSuccessful { get; set; }

    public string? Description { get; set; }

    public virtual Cv IdCvNavigation { get; set; } = null!;

    public virtual Vacancy IdVacancyNavigation { get; set; } = null!;
}
