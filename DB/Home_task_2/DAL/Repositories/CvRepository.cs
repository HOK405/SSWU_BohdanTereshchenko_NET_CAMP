using DAL.EF;
using Home_task_2.Entities;
using Microsoft.EntityFrameworkCore;

namespace Home_task_2.Repositories
{
    public class CvRepository
    {
        private readonly PersonnelAgencyContext _dbContext;

        public CvRepository(PersonnelAgencyContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Add(Cv cv)
        {
            if (cv == null)
            {
                throw new ArgumentNullException(nameof(cv));
            }

            _dbContext.Cvs.Add(cv);
            _dbContext.SaveChanges();
        }

        public Cv? GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero.");
            }

            return _dbContext.Cvs
                .Include(c => c.Applicant)
                .Include(c => c.Job)
                .FirstOrDefault(c => c.IdCv == id);
        }

        public List<Cv> GetAll()
        {
            return _dbContext.Cvs
                .Include(c => c.Applicant)
                .Include(c => c.Job)
                .ToList();
        }

        public void Update(Cv cv)
        {
            if (cv == null)
            {
                throw new ArgumentNullException(nameof(cv));
            }

            _dbContext.Cvs.Update(cv);
            _dbContext.SaveChanges();
        }

        public void Delete(Cv cv)
        {
            if (cv == null)
            {
                throw new ArgumentNullException(nameof(cv));
            }

            _dbContext.Cvs.Remove(cv);
            _dbContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero.");
            }

            var cvToDelete = _dbContext.Cvs.FirstOrDefault(c => c.IdCv == id);
            if (cvToDelete != null)
            {
                _dbContext.Cvs.Remove(cvToDelete);
                _dbContext.SaveChanges();
            }
        }
    }
}
