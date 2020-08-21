using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebMSFactory.DAC;

namespace WebMSFactory.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(EmployeeVO employeeVO)
        {
            EmployeeVO login = new EmployeeDAC().GetLoginEmployee(employeeVO.Employee_id, GetSHA256(employeeVO.Employee_pwd));

			if (login == null)
			{
				ViewBag.Msg = "로그인에 실패하였습니다. ID나 비밀번호를 확인해주시길 바랍니다.";
				return View();
			}
			else
			{
				Session["login"] = login;
				return Redirect("/");
			}
        }

		private string GetSHA256(string str)
		{
			StringBuilder builder = new StringBuilder();

			if (!string.IsNullOrEmpty(str.Trim()))
			{
				using (System.Security.Cryptography.SHA256 mySHA256 = System.Security.Cryptography.SHA256.Create())
				{
					try
					{
						// ComputeHash - returns byte array  
						byte[] bytes = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(str));

						// Convert byte array to a string   
						for (int i = 0; i < bytes.Length; i++)
						{
							builder.Append(bytes[i].ToString("x2"));
						}
					}
					catch (UnauthorizedAccessException err)
					{
						throw err;
					}
				}
			}

			return builder.ToString();
		}
	}
}