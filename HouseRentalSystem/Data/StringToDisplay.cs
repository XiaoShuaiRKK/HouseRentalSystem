using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentalSystem.Data
{
    class StringToDisplay:INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private string text;

        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                NotifyChanged("Text");
            }
        }

        #region Sales列表的用户信息
        private string oneUserName;

        public string OneUserName
        {
            get { return oneUserName; }
            set
            {
                oneUserName = value;
                NotifyChanged("OneUserName");
            }
        }

        private string oneRent;

        public string OneRent
        {
            get { return oneRent; }
            set
            {
                oneRent = value;
                NotifyChanged("OneRent");
            }
        }

        private string oneLeaseTerm;

        public string OneLeaseTerm
        {
            get { return oneLeaseTerm; }
            set
            {
                oneLeaseTerm = value;
                NotifyChanged("OneLeaseTerm");
            }
        }

        private string secondUserName;

        public string SecondUserName
        {
            get { return secondUserName; }
            set
            {
                secondUserName = value;
                NotifyChanged("secondUserName");
            }
        }

        private string secondRent;

        public string SecondRent
        {
            get { return secondRent; }
            set
            {
                secondRent = value;
                NotifyChanged("secondRent");
            }
        }

        private string secondLeaseTerm;

        public string SecondLeaseTerm
        {
            get { return secondLeaseTerm; }
            set
            {
                secondLeaseTerm = value;
                NotifyChanged("secondLeaseTerm");
            }
        }
        #endregion

        #region HouseSales列表的信息

        private string oneHouseListType;

        public string OneHouseListType
        {
            get { return oneHouseListType; }
            set
            {
                oneHouseListType = value;
                NotifyChanged("OneHouseListType");
            }
        }

        private string oneHouseListRent;

        public string OneHouseListRent
        {
            get { return oneHouseListRent; }
            set
            {
                oneHouseListRent = value;
                NotifyChanged("OneHouseListRent");
            }
        }

        private string oneHouseListState;

        public string OneHouseListState
        {
            get { return oneHouseListState; }
            set
            {
                oneHouseListState = value;
                NotifyChanged("OneHouseListState");
            }
        }


        private string twoHouseListType;

        public string TwoHouseListType
        {
            get { return twoHouseListType; }
            set
            {
                twoHouseListType = value;
                NotifyChanged("TwoHouseListType");
            }
        }

        private string twoHouseListRent;

        public string TwoHouseListRent
        {
            get { return twoHouseListRent; }
            set
            {
                twoHouseListRent = value;
                NotifyChanged("TwoHouseListRent");
            }
        }

        private string twoHouseListState;

        public string TwoHouseListState
        {
            get { return twoHouseListState; }
            set
            {
                twoHouseListState = value;
                NotifyChanged("TwoHouseListState");
            }
        }


        private string threeHouseListType;

        public string ThreeHouseListType
        {
            get { return threeHouseListType; }
            set
            {
                threeHouseListType = value;
                NotifyChanged("ThreeHouseListType");
            }
        }

        private string threeHouseListRent;

        public string ThreeHouseListRent
        {
            get { return threeHouseListRent; }
            set
            {
                threeHouseListRent = value;
                NotifyChanged("ThreeHouseListRent");
            }
        }

        private string threeHouseListState;

        public string ThreeHouseListState
        {
            get { return threeHouseListState; }
            set
            {
                threeHouseListState = value;
                NotifyChanged("ThreeHouseListState");
            }
        }

        private string oneHouseListAddresss;

        public string OneHouseListAddresss
        {
            get { return oneHouseListAddresss; }
            set
            {
                oneHouseListAddresss = value;
                NotifyChanged("OneHouseListAddresss");
            }
        }

        private string twoHouseListAddresss;

        public string TwoHouseListAddresss
        {
            get { return twoHouseListAddresss; }
            set
            {
                twoHouseListAddresss = value;
                NotifyChanged("TwoHouseListAddresss");
            }
        }
        private string threeHouseListAddresss;

        public string ThreeHouseListAddresss
        {
            get { return threeHouseListAddresss; }
            set
            {
                threeHouseListAddresss = value;
                NotifyChanged("ThreeHouseListAddresss");
            }
        }
        #endregion

        #region 数据表
        private IChartValues valuesToLine =  new ChartValues<IObservableChartPoint>();

        public IChartValues ValuesToLine
        {
            get { return valuesToLine; }
            set
            {
                valuesToLine = value;
                NotifyChanged("ValuesToLine");
            }
        }
        #endregion

        #region 主页好友列表

        private string friendsListUserName;

        public string FriendsListUserName
        {
            get { return friendsListUserName; }
            set
            {
                friendsListUserName = value;
                NotifyChanged("FriendsListUserName");
            }
        }

        private string friendsListOnlineTime;
        public string FriendsListOnlineTime
        {
            get { return friendsListOnlineTime; }
            set
            {
                friendsListOnlineTime = value;
                NotifyChanged("FriendsListOnlineTime");
            }
        }

        private string friendsListSend;
        public string FriendsListSend
        {
            get { return friendsListSend; }
            set
            {
                friendsListSend = value;
                NotifyChanged("FriendsListSend");
            }
        }

        #endregion

        #region 房子详情页

        private string detHouseAddress;
        public string DetHouseAddress
        {
            get { return detHouseAddress; }
            set
            {
                detHouseAddress = value;
                NotifyChanged("DetHouseAddress");
            }
        }

        private string detHouseType;
        public string DetHouseType
        {
            get { return detHouseType; }
            set
            {
                detHouseType = value;
                NotifyChanged("DetHouseType");
            }
        }

        private string detHouseRent;
        public string DetHouseRent
        {
            get { return detHouseRent; }
            set
            {
                detHouseRent = value;
                NotifyChanged("DetHouseRent");
            }
        }

        private string detHouseMaster;
        public string DetHouseMaster
        {
            get { return detHouseMaster; }
            set
            {
                detHouseMaster = value;
                NotifyChanged("DetHouseMaster");
            }
        }

        private string detHouseState;
        public string DetHouseState
        {
            get { return detHouseState; }
            set
            {
                detHouseState = value;
                NotifyChanged("DetHouseState");
            }
        }

        private string detHouseTenant;
        public string DetHouseTenant
        {
            get { return detHouseTenant; }
            set
            {
                detHouseTenant = value;
                NotifyChanged("DetHouseTenant");
            }
        }

        private string detHouseAge;
        public string DetHouseAge
        {
            get { return detHouseAge; }
            set
            {
                detHouseAge = value;
                NotifyChanged("DetHouseAge");
            }
        }


        private string hireText;
        public string HireText
        {
            get { return hireText; }
            set
            {
                hireText = value;
                NotifyChanged("HireText");
            }
        }

        private string marketNum;
        public string MarketNum
        {
            get { return marketNum; }
            set
            {
                marketNum = value;
                NotifyChanged("MarketNum");
            }
        }
        #endregion

    }
}
