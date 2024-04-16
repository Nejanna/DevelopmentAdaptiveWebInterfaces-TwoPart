using System.ComponentModel.DataAnnotations;
using Serilog;

namespace WebApplication4.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                Log.Debug("FirstName changed to: {FirstName}", value);
            }
        }
        private string _firstName;

        [Required]
        [StringLength(15)]
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                Log.Debug("LastName changed to: {LastName}", value);
            }
        }
        private string _lastName;

        [Required]
        [EmailAddress]
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                Log.Debug("Email changed to: {Email}", value);
            }
        }
        private string _email;

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                _dateOfBirth = value;
                Log.Debug("DateOfBirth changed to: {DateOfBirth}", value);
            }
        }
        private DateTime _dateOfBirth;

        [Required]
        public string PasswordHash
        {
            get => _passwordHash;
            set
            {
                _passwordHash = value;
                Log.Debug("PasswordHash changed");
            }
        }
        private string _passwordHash;

        [DataType(DataType.DateTime)]
        public DateTime LastLogin
        {
            get => _lastLogin;
            set
            {
                _lastLogin = value;
                Log.Debug("LastLogin changed to: {LastLogin}", value);
            }
        }
        private DateTime _lastLogin;

        public int FailedLoginAttempts
        {
            get => _failedLoginAttempts;
            set
            {
                _failedLoginAttempts = value;
                Log.Debug("FailedLoginAttempts changed to: {FailedLoginAttempts}", value);
            }
        }
        private int _failedLoginAttempts;
    }
}
