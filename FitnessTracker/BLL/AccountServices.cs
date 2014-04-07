using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Net.Mail;

namespace BLL
{
    public class AccountServices
    {
        public bool ValidateNewUser(UserFM user)
        {
            return (user != null && !IsExistingUser(user) && ValidEmail(user) && ValidNames(user) && ValidPasswords(user));
        }

        private bool IsExistingUser(UserFM user)
        {
            if (GetUser(user) == null)
            {
                return false;
            }
            return true;
        }

        private bool ValidEmail(UserFM user)
        {
            if (user.Email.Length > 5 && user.Email.Length < 257)
            {
                try
                {
                    MailAddress email = new MailAddress(user.Email);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        private bool ValidNames(UserFM user)
        {
            return (user.FirstName != null && user.LastName != null && user.FirstName.Length < 26 && user.LastName.Length < 26);
        }

        private bool ValidPasswords(UserFM user)
        {
            return (user.Password != null && user.ConfirmPass != null && user.Password.Length > 7 && user.Password.Length < 51 && user.Password == user.ConfirmPass);
        }

        private User GetUser(UserFM user)
        {
            UserDAO dao = new UserDAO();
            return dao.GetUser(ConvertUser(user));
        }

        private User ConvertUser(UserFM fm)
        {
            User user = new User();
            user.ID = fm.ID;
            user.Password = fm.Password;
            user.FirstName = fm.FirstName;
            user.LastName = fm.LastName;
            return user;
        }

        private UserVM ConvertUser(User user)
        {
            UserVM vm = new UserVM();
            vm.ID = user.ID;
            vm.FirstName = user.FirstName;
            vm.LastName = user.LastName;
            return vm;
        }

        public int CreateUser(UserFM user)
        {
            UserDAO dao = new UserDAO();
            return dao.CreateUser(ConvertUser(user));
        }
    }
}