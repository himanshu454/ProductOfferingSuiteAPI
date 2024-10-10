using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductOfferingSuiteAPI.Domain.Login
{
    public class LoginModel
    {
        public int? PkUserIDInt { get; set; }
        public string UserNameV { get; set; }
        public string UserPassWord { get; set; }
        public string ISLoginC { get; set; }
        public string UserStatusV { get; set; }
        public string MachineID { get; set; }
        public string Emp_Active { get; set; }

    }

    public class LoginPOSModel
    {
        public int? ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNo { get; set; }
        public string EmailID { get; set; }

    }

    public class LoginPOSInputModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginPOSRegModel
    {
        public int ReturnValue { get; set; }
        public string OutputMsg { get; set; }
    }

    public class LoginPOSRegInputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

    public class LoginPOSUpdateProfileInputModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
    }

    public class LoginPOSChangePwdInputModel
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
