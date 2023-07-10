using Home_task_2.DataDB;
using Home_task_2.Repositories;
using System.Text;

namespace Home_task_2.Services
{
    public class CvInformationService
    {
        private readonly CvRepository _cvRepository;
        private readonly ApplicantRepository _applicantRepository;
        private readonly AddressRepository _addressRepository;
        private readonly JobRepository _jobRepository;
        private readonly SkillRepository _skillRepository;
        private readonly CvSkillRepository _cvSkillRepository;

        public CvInformationService(
            CvRepository cvRepository,
            ApplicantRepository applicantRepository,
            AddressRepository addressRepository,
            JobRepository jobRepository,
            SkillRepository skillRepository,
            CvSkillRepository cvSkillRepository)
        {
            _cvRepository = cvRepository ?? throw new ArgumentNullException(nameof(cvRepository));
            _applicantRepository = applicantRepository ?? throw new ArgumentNullException(nameof(applicantRepository));
            _addressRepository = addressRepository ?? throw new ArgumentNullException(nameof(addressRepository));
            _jobRepository = jobRepository ?? throw new ArgumentNullException(nameof(jobRepository));
            _skillRepository = skillRepository ?? throw new ArgumentNullException(nameof(skillRepository));
            _cvSkillRepository = cvSkillRepository ?? throw new ArgumentNullException(nameof(cvSkillRepository));
        }

        public string GetAllCvsInformation()
        {
            StringBuilder sb = new StringBuilder();

            List<Cv> cvs = _cvRepository.GetAll();

            foreach (Cv cv in cvs)
            {
                sb.AppendLine($"CV ID: {cv.IdCv}");

                Applicant? applicant = _applicantRepository.GetById(cv.ApplicantId);
                if (applicant != null)
                {
                    sb.AppendLine($"Applicant Name: {applicant.Name}");

                    Address? address = _addressRepository.GetById(applicant.AddressId.GetValueOrDefault());
                    if (address != null)
                    {
                        sb.AppendLine($"Address: {address}");
                    }
                }

                Job job = _jobRepository.GetById(cv.JobId);
                if (job != null)
                {
                    if (job.JobLevel != null)
                    {
                        sb.AppendLine($"Desired job: {job.JobLevel} {job.JobTitle}");
                    }
                    sb.AppendLine($"Salary: {cv.Salery}");
                }


                List<Cvskill> cvSkills = _cvSkillRepository.GetByCvId(cv.IdCv);
                if (cvSkills.Any())
                {
                    sb.AppendLine("Skills:");
                    foreach (Cvskill cvSkill in cvSkills)
                    {
                        Skill skill = _skillRepository.GetById(cvSkill.IdSkill);
                        if (skill != null)
                        {
                            sb.AppendLine($"- {skill.Name}");
                        }
                    }
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }

}
