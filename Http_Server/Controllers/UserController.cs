using Microsoft.AspNetCore.Mvc;
using SDK.API;
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
            API.Print(username, " ", password);
            //Ŀǰ��֧�������ַ��¼���Ժ󿪷�������ʽ��¼
            //������ʽ��¼��ֻ��Ҫ���������$"EmailAddress = '{username.Trim()}'"��ʹ�÷���API.CheckString()�Ϳ����жϳ���¼��ʽ
            if (!user.IsPassword($"EmailAddress = '{username.Trim()}'", password.Trim()))
            {
                yield return "{status:false,msg:�û������������}";
            }
            else yield return "{status:true}";
        }
        [HttpGet]
        public IEnumerable<string> UserRegister (string username, string password)
        {
            Users user = new Users("Users");
            int num = user.SignUpNewUser(username.Trim(), password.Trim());
            switch (num)
            {
                case -1:
                    yield return "{status:false,msg:�����Ѿ�ע��}";
                    break;
                case -2:
                    yield return "status:false,msg:ע��ʧ�ܣ�����ϵ����Ա";
                    break;
                default:
                    yield return $"status:true,msg:ע��ɹ�������UIDΪ��{num}";
                    break;
            }
        }
    }
}