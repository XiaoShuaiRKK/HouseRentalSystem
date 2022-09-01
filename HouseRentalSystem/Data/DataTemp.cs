using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentalSystem
{
    class DataTemp
    {
        private static string username;

        public static string Username { get => username; set => username = value; }

        public static string HearPathTitle = "pack://application:,,,";

        private static string hearPath = "/img/LoadUser.png";

        public static string WarningTips;

        public static int WarningNum = 0;

        private int permit;
        public int Permit { get => permit; set => permit = value; }
        public static string HearPath { get => hearPath = HearPathTitle + hearPath; set => hearPath = value; }

        #region MenuImg

        public static string HomeMenuBlueImg = HearPathTitle + "/img/HomePageBlue.png";

        public static string HomeMenuAsIsImg = HearPathTitle + "/img/HomePage.png";

        public static string LeaseMenuBlueImg = HearPathTitle + "/img/LeaseBlue.png";

        public static string LeaseAsIsImg = HearPathTitle + "/img/Lease.png";

        public static string StatisticsBlueImg = HearPathTitle + "/img/StatisticsBlue.png";

        public static string StatisticsAsIsImg = HearPathTitle + "/img/Statistics.png";

        public static string ToMoDaChiBlueImg = HearPathTitle + "/img/ToMoDaChiBlue.png";

        public static string ToMoDaChiAsIsImg = HearPathTitle + "/img/ToMoDaChi.png";

        public static string UserBlueImg = HearPathTitle + "/img/224UserBlue.png";

        public static string UserAsIsImg = HearPathTitle + "/img/224User.png";

        #endregion

        private static int passage;
        public static int Passage { get => passage; set => passage = value; }


        private static string gender;
        public static string Gender { get => gender; set => gender = value; }

        public static int PhoneCheckCode { get => phoneCheckCode; set => phoneCheckCode = value; }
        

        private static int phoneCheckCode;


        #region SalesListinformation
        private static string tenantUser;

        private static string leaseTerm;

        private static string rent;

        private static string time;

        public static string TenantUser { get => tenantUser; set => tenantUser = value; }
        public static string LeaseTerm { get => leaseTerm; set => leaseTerm = value; }
        public static string Rent { get => rent; set => rent = value; }
        public static string Time { get => time; set => time = value; }
        public static string SecondTenantUser { get => secondTenantUser; set => secondTenantUser = value; }
        public static string SecondLeaseTerm { get => secondLeaseTerm; set => secondLeaseTerm = value; }
        public static string SecondRent { get => secondRent; set => secondRent = value; }
        public static string SecondTime { get => secondTime; set => secondTime = value; }
       

        private static string secondTenantUser;

        private static string secondLeaseTerm;

        private static string secondRent;

        private static string secondTime;
        #endregion


        #region HouseListInformation
        private static string oneHouseType;

        private static string oneHouseMonthlyRent;

        private static string oneHouserState;

        private static string twoHouseType;

        private static string twoHouseMonthlyRent;

        private static string twoHouserState;

        private static string threeHouseType;

        private static string threeHouseMonthlyRent;

        private static string threeHouserState;

        public static string OneHouseType { get => oneHouseType; set => oneHouseType = value; }
        public static string OneHouseMonthlyRent { get => oneHouseMonthlyRent; set => oneHouseMonthlyRent = value; }
        public static string OneHouserState { get => oneHouserState; set => oneHouserState = value; }
        public static string TwoHouseType { get => twoHouseType; set => twoHouseType = value; }
        public static string TwoHouseMonthlyRent { get => twoHouseMonthlyRent; set => twoHouseMonthlyRent = value; }
        public static string TwoHouserState { get => twoHouserState; set => twoHouserState = value; }
        public static string ThreeHouseType { get => threeHouseType; set => threeHouseType = value; }
        public static string ThreeHouseMonthlyRent { get => threeHouseMonthlyRent; set => threeHouseMonthlyRent = value; }
        public static string ThreeHouserState { get => threeHouserState; set => threeHouserState = value; }


        public static string OneHouseAddress { get => oneHouseAddress; set => oneHouseAddress = value; }
        public static string TwoHouseAddress { get => twoHouseAddress; set => twoHouseAddress = value; }
        public static string ThreeHouseAddress { get => threeHouseAddress; set => threeHouseAddress = value; }
        

        private static string oneHouseAddress;

        private static string twoHouseAddress;

        private static string threeHouseAddress;
        #endregion

        #region FriendsListInformation

        public static string FriendName { get => friendName; set => friendName = value; }
        public static string FriendNameRecentChat { get => friendNameRecentChat; set => friendNameRecentChat = value; }
        public static string LastLoginTime { get => lastLoginTime; set => lastLoginTime = value; }


        private static string friendName;

        private static string friendNameRecentChat;

        private static string lastLoginTime;

        #endregion


        #region 其它

        private static string hire;

        public static string Hire { get => hire; set => hire = value;}


        private static int marketPageNum;

        public static int MarketPageNum { get => marketPageNum; set => marketPageNum = value; }


        private static int personalPageNum;

        public static int PersonalPageNum { get => personalPageNum; set => personalPageNum = value; }

        #endregion

    }
}
