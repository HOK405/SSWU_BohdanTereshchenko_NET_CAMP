using Home_task_2.DataDB;

namespace Home_task_2.Repositories
{
    public class AddressRepository
    {
        private readonly PersonnelAgencyContext _dbContext;

        public AddressRepository(PersonnelAgencyContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Add(Address address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            _dbContext.Addresses.Add(address);
            _dbContext.SaveChanges();
        }

        public Address? GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero.");
            }

            return _dbContext.Addresses.FirstOrDefault(a => a.IdAddress == id);
        }

        public List<Address> GetAll()
        {
            return _dbContext.Addresses.ToList();
        }

        public void Update(Address address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            _dbContext.Addresses.Update(address);
            _dbContext.SaveChanges();
        }

        public void Delete(Address address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            _dbContext.Addresses.Remove(address);
            _dbContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero.");
            }

            Address? addressToDelete = _dbContext.Addresses.FirstOrDefault(a => a.IdAddress == id);
            if (addressToDelete != null)
            {
                _dbContext.Addresses.Remove(addressToDelete);
                _dbContext.SaveChanges();
            }
        }
    }

}
