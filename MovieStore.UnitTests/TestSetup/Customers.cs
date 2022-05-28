using MovieStoreUI.DbOperations;
using MovieStoreUI.Entities;

namespace MovieStore.UnitTests.TestSetup
{
    public static class Customers
    {
        private static byte[] PasswordHash = {109, 113, 161, 170, 96, 205, 218, 192, 159, 108, 97, 196, 210, 33, 87, 101, 10, 191, 99, 186, 38, 231, 145, 137, 2,
        13, 66, 224, 22, 181, 69, 14, 66, 31, 158, 38, 133, 113, 140, 16, 243, 92, 160, 218, 118, 101, 129, 7, 88, 222, 84, 69, 229, 120, 218, 158, 214, 95, 131, 136, 114, 219, 208, 108};
        private static byte[] PasswordSalt = {147, 148, 186,  167, 85, 41, 233, 209, 34, 36, 44, 183, 197, 13, 243, 112, 212, 156, 241, 114, 4, 82, 95, 144, 164};

        public static void AddCustomers(this MovieStoreDbContext context)
        {
            context.AddRange(
                new Customer {FirstName ="Ayhan", LastName="Karaman", Email= "ayhan@gmail.com", PasswordHash = PasswordHash, PasswordSalt = PasswordSalt },
                new Customer {FirstName ="Yasin", LastName="Şahin", Email= "yasin@gmail.com", PasswordHash = PasswordHash, PasswordSalt = PasswordSalt },
                new Customer {FirstName ="Okan", LastName="Ünal", Email= "okan@gmail.com", PasswordHash = PasswordHash, PasswordSalt = PasswordSalt }

            );
        }
    }
}

