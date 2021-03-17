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
            if (db != null)
                return;

            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UsersDB.db");
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
            var list = await db.Table<User>().ToListAsync();
        }

        public static async Task<string[]> GetUser(string _username, string _password)
        {
            await Init();
            string[] response = new string[2];

            var user = await db.Table<User>().Where(x => x.Username == _username).FirstOrDefaultAsync();
            if(user != null)
            {
                if(user.Password == _password)
                {
                    response[0] = "OK";
                    response[1] = user.Username;
                    return response;
                } else
                {
                    response[0] = "ERROR";
                    response[1] = "Incorrect password, Try again";
                    return response;
                }
            } else
            {
                response[0] = "ERROR";
                response[1] = "User doesn't exist";
                return response;
            }
            
        }
    }
}
