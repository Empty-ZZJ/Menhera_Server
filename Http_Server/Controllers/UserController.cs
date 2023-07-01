using Microsoft.AspNetCore.Mvc;
using ������.GameSDKS;
namespace Http_Server.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class UserController : ControllerBase
    {

        [HttpPost]
        public IEnumerable<string> UserLogin (string username, string password)
        {
            Users user = new Users("Users");
            if (!user.IsPassword($"EmailAddress = '{username.Trim()}'", password.Trim()))
            {
                yield return "{status:false,msg:�û������������}";
            }
            yield return "{status:true}";
        }
        [HttpGet]
        public IEnumerable<string> UserRegister (string username, string password)
        {
            Users user = new Users("Users");
            int num = user.SignUpNewUser(username, password);
            switch (num)
            {
                case -1:
                    yield return "{status:false,msg:�����Ѿ�ע��}";
                    break;
                case -2:
                    yield return "status:false,msg:ע��ʧ�ܣ�����ϵ����Ա";
                    break;
                default:
                    yield return "{status:true,msg:ע��ɹ�}";
                    break;
            }
        }
    }
}