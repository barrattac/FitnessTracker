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

        public UserFM GetUser(int userID)
        {
            return new UserFM(new UserVM(userID));
        }

        private User ConvertUser(UserFM fm)
        {
            User user = new User();
            user.ID = fm.ID;
            user.Email = fm.Email.ToLower();
            user.Password = fm.Password;
            user.FirstName = fm.FirstName;
            user.LastName = fm.LastName;
            return user;
        }

        public int CreateUser(UserFM user)
        {
            UserDAO dao = new UserDAO();
            return dao.CreateUser(ConvertUser(user));
        }

        public string GetErrorNewUser(UserFM user)
        {
            string errorMessage = "An Unknown Error Occurred.";
            if (!ValidPasswords(user))
            {
                errorMessage = PasswordError(user);
            }
            if (!ValidEmail(user))
            {
                errorMessage = "Your email address must be a valid email address.  Please check your email and try again.";
            }
            if (!ValidNames(user))
            {
                errorMessage = "Your first and last name must each be between 1 and 25 characters long.  Please shorten any name too long.";
            }
            if (IsExistingUser(user))
            {
                errorMessage = "User already exist.  Please chose a different email address or sign in with your current account.";
            }
            return errorMessage;
        }

        private string PasswordError(UserFM user)
        {
            if (user.Password != null && user.ConfirmPass != null && user.Password == user.ConfirmPass)
            {
                return "Your password must be between 8 and 50 characters long.  Please choose a valid password.";
            }
            else
            {
                return "Your password and confirm password do not match.  Please try again.";
            }
        }

        public int Login(UserFM user)
        {
            UserDAO dao = new UserDAO();
            return dao.Login(ConvertUser(user));
        }

        public bool UpdateUserInfo(UserFM fm)
        {
            UserDAO dao = new UserDAO();
            User user = dao.GetUserByID(fm.ID);
            if (fm.Password == null)
            {
                fm.Password = user.Password;
                fm.ConfirmPass = fm.Password;
            }
            if (ValidPasswords(fm) && ValidEmail(fm) && ValidNames(fm))
            {
                if (user.Email == fm.Email || !IsExistingUser(fm))
                {
                    dao.UpdateUser(ConvertUser(fm));
                    return true;
                }
            }
            return false;
        }

        public string GetUpdateUserError(UserFM fm)
        {
            string errorMessage = "An Unknown Error Occurred.";
            UserDAO dao = new UserDAO();
            if (!ValidPasswords(fm))
            {
                errorMessage = PasswordError(fm);
            }
            if (!ValidEmail(fm))
            {
                errorMessage = "Your email address must be a valid email address.  Please check your email and try again.";
            }
            if (!ValidNames(fm))
            {
                errorMessage = "Your first and last name must each be between 1 and 25 characters long.  Please shorten any name too long.";
            }
            if (dao.GetUserByID(fm.ID).Email != fm.Email && IsExistingUser(fm))
            {
                errorMessage = "That email address already exist.  Please use another email address.";
            }
            return errorMessage;
        }
    }
}