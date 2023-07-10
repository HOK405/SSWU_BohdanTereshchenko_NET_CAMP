using Home_task_2.DataDB;
using Microsoft.EntityFrameworkCore;

namespace Home_task_2.Repositories
{
    public class ApplicantRepository
    {
        private readonly PersonnelAgencyContext _dbContext;

        public ApplicantRepository(PersonnelAgencyContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Add(Applicant applicant)
        {
            if (applicant == null)
            {
                throw new ArgumentNullException(nameof(applicant));
            }

            _dbContext.Applicants.Add(applicant);
            _dbContext.SaveChanges();
        }

        public Applicant? GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero.");
            }

            return _dbContext.Applicants.Include(a => a.Address).FirstOrDefault(a => a.IdApplicant == id);
        }

        public List<Applicant> GetAll()
        {
            return _dbContext.Applicants.ToList();
        }

        public void Update(Applicant applicant)
        {
            if (applicant == null)
            {
                throw new ArgumentNullException(nameof(applicant));
            }

            _dbContext.Applicants.Update(applicant);
            _dbContext.SaveChanges();
        }

        public void Delete(Applicant applicant)
        {
            if (applicant == null)
            {
                throw new ArgumentNullException(nameof(applicant));
            }

            _dbContext.Applicants.Remove(applicant);
            _dbContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero.");
            }

            var applicantToDelete = _dbContext.Applicants.FirstOrDefault(a => a.IdApplicant == id);
            if (applicantToDelete != null)
            {
                _dbContext.Applicants.Remove(applicantToDelete);
                _dbContext.SaveChanges();
            }
        }
    }
}
