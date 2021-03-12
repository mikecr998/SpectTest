using SpectTest.Models;
using SQLite;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SpectTest.DB
{
    public static class DBServices
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            // Get an absolute path to the database file
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyBD.db");
            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<User>();
        }

        public static async Task AddUser(string firstName, string lastName, string phone, string username, string password, DateTime date)
        {
            await Init();

            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Phone = phone,
                Username = username,
                Password = password,
                Date = date
            };

            var idUser = await db.InsertAsync(user);
        }
    }
}
