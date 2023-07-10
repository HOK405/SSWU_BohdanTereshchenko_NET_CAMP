using Home_task_2.DataDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_2.Repositories
{
    public class JobRepository
    {
        private readonly PersonnelAgencyContext _dbContext;

        public JobRepository(PersonnelAgencyContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Add(Job job)
        {
            if (job == null)
            {
                throw new ArgumentNullException(nameof(job));
            }

            _dbContext.Jobs.Add(job);
            _dbContext.SaveChanges();
        }

        public Job GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero.");
            }

            return _dbContext.Jobs.FirstOrDefault(j => j.IdJob == id);
        }

        public List<Job> GetAll()
        {
            return _dbContext.Jobs.ToList();
        }

        public void Update(Job job)
        {
            if (job == null)
            {
                throw new ArgumentNullException(nameof(job));
            }

            _dbContext.Jobs.Update(job);
            _dbContext.SaveChanges();
        }

        public void Delete(Job job)
        {
            if (job == null)
            {
                throw new ArgumentNullException(nameof(job));
            }

            _dbContext.Jobs.Remove(job);
            _dbContext.SaveChanges();
        }
    }

}
