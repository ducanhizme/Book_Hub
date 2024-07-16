using BookHub.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace BookHub.data.Repository
{
    public class UserRepository
    {
        public bool AuthenticateUser(string email, string password)
        {
            using (var context = new AppContext())
            {
                string hashedPassword = ComputeHash(password);
                return context.Users.Any(u => u.Email == email && u.Password == hashedPassword);
            }
        }

        public bool RegisterUser(string email, string password, string name)
        {
            using (var context = new AppContext())
            {
                if (context.Users.Any(u => u.Email == email))
                {
                    return false;
                }
                else
                {
                    string hashedPassword = ComputeHash(password);
                        var newUser = new User
                        {
                            Email = email,
                            Password = hashedPassword,
                            Username = name,
                            CreatedAt = DateTime.Now,
                            Role = "User"
                        };
                        context.Users.Add(newUser);
                        context.SaveChanges();
                        return true;
                }
            }
        }

        public User FindUserByEmail(string email)
        {
            using (var context = new AppContext())
            {
                return context.Users.FirstOrDefault(u => u.Email == email);
            }
        }

        private string ComputeHash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }


}