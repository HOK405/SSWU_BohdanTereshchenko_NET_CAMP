using Home_task_2.DataDB;

namespace Home_task_2.Repositories
{
    public class SkillRepository
    {
        private readonly PersonnelAgencyContext _dbContext;

        public SkillRepository(PersonnelAgencyContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Add(Skill skill)
        {
            if (skill == null)
            {
                throw new ArgumentNullException(nameof(skill));
            }

            _dbContext.Skills.Add(skill);
            _dbContext.SaveChanges();
        }

        public Skill GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero.");
            }

            return _dbContext.Skills.FirstOrDefault(s => s.IdSkill == id);
        }

        public List<Skill> GetAll()
        {
            return _dbContext.Skills.ToList();
        }

        public void Update(Skill skill)
        {
            if (skill == null)
            {
                throw new ArgumentNullException(nameof(skill));
            }

            _dbContext.Skills.Update(skill);
            _dbContext.SaveChanges();
        }

        public void Delete(Skill skill)
        {
            if (skill == null)
            {
                throw new ArgumentNullException(nameof(skill));
            }

            _dbContext.Skills.Remove(skill);
            _dbContext.SaveChanges();
        }
    }

}
