using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Login;

namespace Analysis
{
    public class Bll
    {
        //java.security.Security Security;
        
        Tools.Login.Service service = new Service();
        public int LoginCheck(string UserName,string Password)
        {
            return service.CheckPermit(UserName, Password);
        }
    }
}
