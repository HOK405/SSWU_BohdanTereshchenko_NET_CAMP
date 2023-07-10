using DAL.EF;

namespace Home_task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new PersonnelAgencyContext())
            {
                RepositoryMenu menu = new RepositoryMenu(dbContext);

                menu.Run();

                /*// Додавання адреси
                var newAddress = new Address
                {
                    Country = "Ukraine",
                    Region = "Kyiv",
                    City = "Kyiv",
                    Street = "Main Street",
                    BuildingNumber = "123",
                    ApartmentNumber = "4A",
                    Floor = 2,
                    PostalCode = "12345"
                };
                addressRepository.Add(newAddress);

                // Отримання адреси за ID
                var retrievedAddress = addressRepository.GetById(7);
                Console.WriteLine(retrievedAddress);

                // Оновлення адреси
                retrievedAddress.City = "Poltava";
                retrievedAddress.Region = "Poltava";
                addressRepository.Update(retrievedAddress);

                // Видалення адреси
                addressRepository.Delete(retrievedAddress);

                // Отримання всіх адрес
                foreach (Address address in addressRepository.GetAll())
                {
                    Console.WriteLine(address);
                    Console.WriteLine(new string('-', 10));
                }



                // Отримання заявника за ID
                var retrievedApplicant = applicantRepository.GetById(1);
                Console.WriteLine(retrievedApplicant);

                // Отримання всіх заявників
                foreach (Applicant applicant in applicantRepository.GetAll())
                {
                    Console.WriteLine(applicant);
                    Console.WriteLine(new string('-', 15));
                }


                // Отримання всіх резюме
                foreach (Cv cv in cvRepository.GetAll())
                {
                    Console.WriteLine(cv);
                    Console.WriteLine(new string('-', 15));
                }


                // Отримання всіх CvSkill
                foreach (Cvskill cvSkill in cvSkillRepository.GetAll())
                {
                    Console.WriteLine($"CV ID:{cvSkill.IdCv}, Skill ID:{cvSkill.IdSkill}");
                    Console.WriteLine(cvSkill.Description);
                    Console.WriteLine(new string('-', 20));
                }*/

            }
        }
    }
}