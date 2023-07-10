using DAL.EF;
using Home_task_2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_2.Repositories
{
    public class CvSkillRepository
    {
        private readonly PersonnelAgencyContext _dbContext;

        public CvSkillRepository(PersonnelAgencyContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Add(Cvskill cvSkill)
        {
            if (cvSkill == null)
            {
                throw new ArgumentNullException(nameof(cvSkill));
            }

            _dbContext.Cvskills.Add(cvSkill);
            _dbContext.SaveChanges();
        }

        public Cvskill GetByIds(int cvId, int skillId)
        {
            if (cvId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(cvId), "CV Id must be greater than zero.");
            }

            if (skillId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(skillId), "Skill Id must be greater than zero.");
            }

            return _dbContext.Cvskills.FirstOrDefault(cs => cs.IdCv == cvId && cs.IdSkill == skillId);
        }

        public List<Cvskill> GetByCvId(int cvId)
        {
            if (cvId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(cvId), "Cv Id must be greater than zero.");
            }

            return _dbContext.Cvskills.Where(cs => cs.IdCv == cvId).ToList();
        }


        public List<Cvskill> GetAll()
        {
            return _dbContext.Cvskills.ToList();
        }

        public void Update(Cvskill cvSkill)
        {
            if (cvSkill == null)
            {
                throw new ArgumentNullException(nameof(cvSkill));
            }

            _dbContext.Cvskills.Update(cvSkill);
            _dbContext.SaveChanges();
        }

        public void Delete(Cvskill cvSkill)
        {
            if (cvSkill == null)
            {
                throw new ArgumentNullException(nameof(cvSkill));
            }

            _dbContext.Cvskills.Remove(cvSkill);
            _dbContext.SaveChanges();
        }

        public void DeleteById(int cvId, int skillId)
        {
            if (cvId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(cvId), "CV Id must be greater than zero.");
            }

            if (skillId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(skillId), "Skill Id must be greater than zero.");
            }

            var cvSkillToDelete = _dbContext.Cvskills.FirstOrDefault(cs => cs.IdCv == cvId && cs.IdSkill == skillId);
            if (cvSkillToDelete != null)
            {
                _dbContext.Cvskills.Remove(cvSkillToDelete);
                _dbContext.SaveChanges();
            }
        }
    }

}
