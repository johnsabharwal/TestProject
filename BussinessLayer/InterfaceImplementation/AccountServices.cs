using Common.Account;
using Common.Enum;
using Common.Response;
using DataLayer;
using NUnit.Framework;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.InterfaceImplementation
{
    public class AccountServices : IAccountServices
    {
        [Test]
        public Response CreateUser(CreateUser createUser)
        {

            using (Entities enties = new Entities())
            {
                if (!enties.Users.Where(x => x.email.ToLower() == createUser.Email.ToLower()).Any())
                {
                    enties.Users.Add(new User()
                    { email = createUser.Email, phone = createUser.Phone.ToString(), createdDate = DateTime.Now, userName = createUser.UserName, });
                    enties.SaveChanges();
                    return new Response() {Status=ResponseTypes.ok, };
                }
                else
                {
                    return new Response() { Status = ResponseTypes.invalid,ErrorMessageText="User Already Exists" };
                }

            }
         
        }
    }
}
