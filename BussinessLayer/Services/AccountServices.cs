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

        public Response DeleteUser(long UserId)
        {
            using (Entities entities=new Entities ())
            {
                var DelUser = entities.Users.Where(x => x.userId == UserId).FirstOrDefault();
                if (DelUser!=null)
                {
                    entities.Users.Remove(DelUser);
                    entities.SaveChanges();
                    return new Response() { Status = ResponseTypes.ok };
                }
                else
                {
                    return new Response() { Status=ResponseTypes.invalid,ErrorMessageText="User not exits"};
                }
            }
        }

        public Response UpdateUser(UpdateUser updateUser)
        {
            using (Entities entities = new Entities())
            {
                var DelUser = entities.Users.Where(x => x.userId == updateUser.userId).FirstOrDefault();
                if (DelUser != null)
                {
                    DelUser.email = updateUser.Email;
                    DelUser.phone = updateUser.Phone.ToString();
                    DelUser.userName = updateUser.UserName;
                    entities.SaveChanges();
                    return new Response() { Status = ResponseTypes.ok };
                }
                else
                {
                    return new Response() { Status = ResponseTypes.invalid, ErrorMessageText = "User not exits" };
                }
            }
        }
    }
}
