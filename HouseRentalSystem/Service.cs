using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Tools.Login;

namespace HouseRentalSystem
{
    class Service
    {
        Tools.Login.Service Javaservice = new Tools.Login.Service();
        Tools.MainFormTools.Means JavaMeans = new Tools.MainFormTools.Means();
        public string URIPath(string UserName)
        {
            try
            {
                DataTemp.HearPath = Javaservice.ImgPath(UserName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return DataTemp.HearPath;
        }
       
       
        public int SecurityCheck(string UserName,string Passwork)
        {
            //return Bll.LoginCheck(UserName, Passwork);
            //return Javaservice.CheckPermit(UserName, Passwork);
            return Javaservice.CheckPermit(UserName, Passwork);
        }

        public int RegisterSucceeded(string NewUserName,string NewPassword,string CheckPass,string NewPhone,int Code,string Gender)
        {
            DataTemp.Passage = Javaservice.CreateUser(NewUserName, NewPassword, NewPhone, Gender, CheckPass, Code);
            return DataTemp.Passage;
        }

        public int CheckPhone(string Phone)
        {
            DataTemp.PhoneCheckCode = Javaservice.PhoneCheckCode(Phone);
            return DataTemp.PhoneCheckCode;
        }

        #region 主要方法
        /// <summary>
        /// String[0]:ID String[1]:租客 String[2]:租期 String[3]:租金(月) String[4]:成交时间
        /// </summary>
        /// <returns></returns>
        public string[] RencentTenants()
        {
            return JavaMeans.LatelySales();
        }

        public string[] SecondRencentTenant()
        {
            return JavaMeans.SecondLatelySales();
        }


        /// <summary>
        /// [0]:房型 [1]:地址 [2]:租金 [3]:房主 [4]:状态 [5]:租客 [6]:房龄 [7]:表的创建时间
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public string[] OneHouseListInformation(string UserName)
        {
            return JavaMeans.MyHouseOne(UserName);
        }

        public string[] TwoHouseListInformation(string UserName)
        {
            return JavaMeans.MyHouseTwo(UserName);
        }

        public string[] ThreeHouseListInformation(string UserName)
        {
            return JavaMeans.MyHouseThree(UserName);
        }


        /// <summary>
        /// 1-12 为每个月份的销售
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public int[] GetSalesDataPoint(string UserName)
        {
            return JavaMeans.DataPoint(UserName,Convert.ToInt32(DateTime.Today.Year));
        }


        public string[] GetFriens(string UserName)
        {
            return JavaMeans.SeekFriends(UserName);
        }

        /// <summary>
        /// 0:市场房子的数量 1:好友数量 2:用户房源数量 3:出租数量
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public int[] AllCount(string UserName)
        {
            return JavaMeans.CheckCount(UserName);
        }



        private string PerDraw(string UserName)
        {
            return JavaMeans.PerDraw(UserName);
        }

        private string Draw()
        {
            return JavaMeans.Draw();
        }

        private string ChoiceDraw(int Num)
        {
            return JavaMeans.ChoiceDraw(Num);
        }


        /// <summary>
        /// 一个索引对应一个房子的信息
        /// </summary>
        /// <returns></returns>
        public List<string> DrawAll()
        {
            string receive = Draw();
            string[] all = receive.Split('|');
            List<string> result = new List<string>();
            foreach (string c in all)
            {
                result.Add(c);
            }
            return result;
        }

        public List<string> PerDrawAll(string UserName)
        {
            string receive = PerDraw(UserName);
            string[] all = receive.Split('|');
            List<string> result = new List<string>();
            foreach (string c in all)
            {
                result.Add(c);
            }
            return result;
        }

        public List<string> ChoiceDrawAll(int Num)
        {
            string receive = ChoiceDraw(Num);
            string[] all = receive.Split('|');
            List<string> result = new List<string>();
            foreach (string c in all)
            {
                result.Add(c);
            }
            if (string.IsNullOrEmpty(receive))
            {
                List<string> receiveList = new List<string>();
                return receiveList;
            }
            return result;
        }
        #endregion

        #region 辅助工具

        public List<string> SingleHouser(string be)
        {
            string[] all = be.Split(',');
            List<string> result = new List<string>();
            foreach (string c in all)
            {
                result.Add(c);
            }
            return result;
        }

        public string CheckHireUserName(string Name,string UserName)
        {
            string result = "租聘";
            if (Name.Equals(UserName))
            {
                result = "修改";
            }
            return result;
        }

        #endregion
    }
}
