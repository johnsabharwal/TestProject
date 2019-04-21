using Common.Account;
using NUnit.Framework;
using Services.InterfaceImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.NUnit
{
    [TestFixture]
    public class TestClass
    {
        [TestCase]
        [Category("pass")]
        public void Compare()
        {
            AccountServices a = new AccountServices();
            CreateUser c = new CreateUser();
            c.Password = "admin";
            c.ConfirmPassword = "admin";
            c.Address = "asr";
            c.UserName = "john";
            c.Email = "johnsabharwal@zoho.com";
            c.Phone = 9803482335;
            var res = c.Password == c.ConfirmPassword;
            a.CreateUser(c);
            
            Assert.AreEqual(true, res);
        }
        [TestCase]
        [Category("fail")]
        public void CompareAgain()
        {
            AccountServices a = new AccountServices();
            CreateUser c = new CreateUser();
            c.Password = "admin";
            c.ConfirmPassword = "superadmin";
            c.Address = "asr";
            c.UserName = "john";
            c.Email = "johnsabharwal@zoho.com";
            c.Phone = 9803482335;
            var res = c.Password == c.ConfirmPassword;
            a.CreateUser(c);

            Assert.AreEqual(false, res);
        }
    }
}
