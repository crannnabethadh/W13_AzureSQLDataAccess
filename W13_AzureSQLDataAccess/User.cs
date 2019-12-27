using System;

namespace W13_AzureSQLDataAccess
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }

        private string _fullUserInfo;
        public string FullUserInfo
        {
            get
            {
                _fullUserInfo = Id + ", " + FirstName + LastName + ", " + Nickname + ", "
                    + Email + ", " + RegisterDate.Date;
                return _fullUserInfo;
            }
            set { _fullUserInfo = value; }
        }

    }
}
