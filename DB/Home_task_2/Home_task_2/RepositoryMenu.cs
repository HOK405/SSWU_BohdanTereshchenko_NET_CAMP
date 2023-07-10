using DAL.EF;
using Home_task_2.Entities;
using Home_task_2.Repositories;
using Home_task_2.Services;

namespace Home_task_2
{
    public class RepositoryMenu
    {
        private readonly AddressRepository _addressRepository;
        private readonly ApplicantRepository _applicantRepository;
        private readonly CvRepository _cvRepository;
        private readonly CvSkillRepository _cvSkillRepository;
        private readonly JobRepository _jobRepository;
        private readonly SkillRepository _skillRepository;
        private readonly CvInformationService _cvInformationService;

        public RepositoryMenu(PersonnelAgencyContext personnelAgencyContext)
        {
            _addressRepository = new AddressRepository(personnelAgencyContext);
            _applicantRepository = new ApplicantRepository(personnelAgencyContext);
            _cvRepository = new CvRepository(personnelAgencyContext);
            _cvSkillRepository = new CvSkillRepository(personnelAgencyContext);
            _jobRepository = new JobRepository(personnelAgencyContext);
            _skillRepository = new SkillRepository(personnelAgencyContext);
            _cvInformationService = new CvInformationService(_cvRepository, _applicantRepository, _addressRepository, _jobRepository, _skillRepository, _cvSkillRepository);
        }

        public void Run()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Repository Menu ===");
                Console.WriteLine("1. Address Repository");
                Console.WriteLine("2. Applicant Repository");
                Console.WriteLine("3. CV Repository");
                Console.WriteLine("4. CV Skill Repository");
                Console.WriteLine("5. Job Repository");
                Console.WriteLine("6. Skill Repository");
                Console.WriteLine("7. Print related information from Address-Applicant-CV-Job-Skill");
                Console.WriteLine("0. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddressRepositoryMenu();
                        break;
                    case "2":
                        ApplicantRepositoryMenu();
                        break;
                    case "3":
                        CvRepositoryMenu();
                        break;
                    case "4":
                        CvSkillRepositoryMenu();
                        break;
                    case "5":
                        JobRepositoryMenu();
                        break;
                    case "6":
                        SkillRepositoryMenu();
                        break;
                    case "7":
                        PrintRelatedInfo();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void PrintRelatedInfo()
        {
            Console.WriteLine(_cvInformationService.GetAllCvsInformation()); 
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void AddressRepositoryMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Address Repository Menu ===");
                Console.WriteLine("1. Add Address");
                Console.WriteLine("2. Get Address by ID");
                Console.WriteLine("3. Get All Addresses");
                Console.WriteLine("4. Update Address");
                Console.WriteLine("5. Delete Address");
                Console.WriteLine("0. Back");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddAddress();
                        break;
                    case "2":
                        GetAddressById();
                        break;
                    case "3":
                        GetAllAddresses();
                        break;
                    case "4":
                        UpdateAddress();
                        break;
                    case "5":
                        DeleteAddress();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void AddAddress()
        {
            Console.WriteLine("Enter address details:");
            Console.Write("Country: ");
            string country = Console.ReadLine();
            Console.Write("Region: ");
            string region = Console.ReadLine();
            Console.Write("City: ");
            string city = Console.ReadLine();
            Console.Write("Street: ");
            string street = Console.ReadLine();
            Console.Write("Building Number: ");
            string buildingNumber = Console.ReadLine();
            Console.Write("Apartment Number: ");
            string apartmentNumber = Console.ReadLine();
            Console.Write("Floor: ");
            int? floor = int.TryParse(Console.ReadLine(), out int floorValue) ? floorValue : null;
            Console.Write("Postal Code: ");
            string postalCode = Console.ReadLine();

            Address address = new Address
            {
                Country = country,
                Region = region,
                City = city,
                Street = street,
                BuildingNumber = buildingNumber,
                ApartmentNumber = apartmentNumber,
                Floor = floor,
                PostalCode = postalCode
            };

            _addressRepository.Add(address);
            Console.WriteLine("Address added successfully.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


        private void GetAddressById()
        {
            Console.Write("Enter Address ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Address address = _addressRepository.GetById(id);
                if (address != null)
                {
                    Console.WriteLine(address.ToString());
                }
                else
                {
                    Console.WriteLine("Address not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void GetAllAddresses()
        {
            List<Address> addresses = _addressRepository.GetAll();
            if (addresses.Count > 0)
            {
                foreach (Address address in addresses)
                {
                    Console.WriteLine(address.ToString());
                    Console.WriteLine("--------------------");
                }
            }
            else
            {
                Console.WriteLine("No addresses found.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void UpdateAddress()
        {
            Console.Write("Enter Address ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Address address = _addressRepository.GetById(id);
                if (address != null)
                {
                    Console.WriteLine("Enter new address details:");
                    Console.Write("Country: ");
                    string country = Console.ReadLine();
                    Console.Write("Region: ");
                    string region = Console.ReadLine();
                    Console.Write("City: ");
                    string city = Console.ReadLine();
                    Console.Write("Street: ");
                    string street = Console.ReadLine();
                    Console.Write("Building Number: ");
                    string buildingNumber = Console.ReadLine();
                    Console.Write("Apartment Number: ");
                    string apartmentNumber = Console.ReadLine();
                    Console.Write("Floor: ");
                    int? floor = int.TryParse(Console.ReadLine(), out int floorValue) ? floorValue : null;
                    Console.Write("Postal Code: ");
                    string postalCode = Console.ReadLine();

                    address.Country = country;
                    address.Region = region;
                    address.City = city;
                    address.Street = street;
                    address.BuildingNumber = buildingNumber;
                    address.ApartmentNumber = apartmentNumber;
                    address.Floor = floor;
                    address.PostalCode = postalCode;

                    _addressRepository.Update(address);
                    Console.WriteLine("Address updated successfully.");
                }
                else
                {
                    Console.WriteLine("Address not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


        private void DeleteAddress()
        {
            Console.Write("Enter Address ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Address address = _addressRepository.GetById(id);
                if (address != null)
                {
                    Console.WriteLine("Are you sure you want to delete this address? (Y/N)");
                    string confirmation = Console.ReadLine();
                    if (confirmation.ToUpper() == "Y")
                    {
                        _addressRepository.Delete(address);
                        Console.WriteLine("Address deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Deletion canceled.");
                    }
                }
                else
                {
                    Console.WriteLine("Address not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void ApplicantRepositoryMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Applicant Repository Menu ===");
                Console.WriteLine("1. Add Applicant");
                Console.WriteLine("2. Get Applicant by ID");
                Console.WriteLine("3. Get All Applicants");
                Console.WriteLine("4. Update Applicant");
                Console.WriteLine("5. Delete Applicant");
                Console.WriteLine("0. Back");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddApplicant();
                        break;
                    case "2":
                        GetApplicantById();
                        break;
                    case "3":
                        GetAllApplicants();
                        break;
                    case "4":
                        UpdateApplicant();
                        break;
                    case "5":
                        DeleteApplicant();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void AddApplicant()
        {
            // Додати функціональність для додавання заявника
        }

        private void GetApplicantById()
        {
            // Додати функціональність для отримання заявника за ID
        }

        private void GetAllApplicants()
        {
            // Додати функціональність для отримання всіх заявників
        }

        private void UpdateApplicant()
        {
            // Додати функціональність для оновлення заявника
        }

        private void DeleteApplicant()
        {
            // Додати функціональність для видалення заявника
        }

        private void CvRepositoryMenu()
        {
            // Меню для CvRepository
        }

        private void CvSkillRepositoryMenu()
        {
            // Меню для CvSkillRepository
        }

        private void JobRepositoryMenu()
        {
            // Меню для JobRepository
        }

        private void SkillRepositoryMenu()
        {
            // Меню для SkillRepository
        }
    }

}
