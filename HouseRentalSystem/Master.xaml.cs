using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HouseRentalSystem.Data;
using LiveCharts;
using LiveCharts.Defaults;

namespace HouseRentalSystem
{
    /// <summary>
    /// Master.xaml 的交互逻辑
    /// </summary>
    /// 

    public partial class Master : Window
    {
        Service service = new Service();

        int RentalButtonFalg = 0;

        public Master(string UserName)
        {
            //DataTemp.HearPath = service.URIPath(UserName);
            DataTemp.HearPath = "/UserImg/39c4d2177f3e670988fe0f297ec79f3df9dc5528.png";           
            InitializeComponent();
            Load();
            DataTemp.Username = UserName;
            AllLoad(UserName);
            this.Width = SystemParameters.WorkArea.Width * 0.72;
            this.Height = SystemParameters.WorkArea.Height * 0.72;
        }

        public void Words(string UserName)
        {
            if(TitleText == null)
            {
                TitleText = new TextBlock();
            }
            StringToDisplay callDuration = new StringToDisplay();
            TitleText.DataContext = callDuration;
            callDuration.Text = $"你好,{UserName}";
        }

        public void UserHearLoad()
        {
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.CacheOption = BitmapCacheOption.OnLoad;
            bi.UriSource = new Uri(DataTemp.HearPath, UriKind.RelativeOrAbsolute);
            bi.EndInit();
            HomeTopImg.Source = bi;
        }

        public void Load()
        {

            MasterMainForm.Opacity = 0;
            Storyboard LoadAnimation = new Storyboard();

            DoubleAnimation LoadOp = new DoubleAnimation();

            LoadOp.From = 100;
            LoadOp.To = 0;
            LoadOp.Duration = new TimeSpan(0, 0, 0, 5);
            Storyboard.SetTarget(LoadOp, LoadBt);
            Storyboard.SetTargetProperty(LoadOp, new PropertyPath("Opacity"));

            LoadAnimation.Children.Add(LoadOp);

            LoadAnimation.Completed += MainLoadForm;
            LoadAnimation.Begin();
        }
        private void MainLoadForm(object sender, EventArgs eventArgs)
        {
            Storyboard ST = new Storyboard();

            DoubleAnimation DaMainForm = new DoubleAnimation();
            DaMainForm.To = 1;
            DaMainForm.Duration = new TimeSpan(0, 0, 0, 0, 400);

            Storyboard.SetTarget(DaMainForm, MasterMainForm);
            Storyboard.SetTargetProperty(DaMainForm, new PropertyPath("Opacity"));

            ST.Children.Add(DaMainForm);
            ST.Begin();
        }

        #region 加载
        public void AllLoad(string UserName)
        {
            UserHearLoad();
            SalesListLoad();
            Words(UserName);
            HouseListLoad(UserName);
            LoadDataSheet(UserName);
            FriendsListLoad(UserName);
        }
        #endregion

        #region 市场加载

        public void PageChange(int Num,TextBlock TextOb)
        {
            StringToDisplay callDuration = new StringToDisplay();
            TextOb.DataContext = callDuration;
            callDuration.MarketNum = Num.ToString();
            DataTemp.MarketPageNum = Num;
        }

        public void PerPageChange(int Num, TextBlock TextOb)
        {
            StringToDisplay callDuration = new StringToDisplay();
            TextOb.DataContext = callDuration;
            callDuration.MarketNum = Num.ToString();
            DataTemp.PersonalPageNum = Num;
        }

        public void PersonalLoad(int CommodityNum,List<string> Information)
        {
            if (CommodityNum == 0)
            {
                PersonalPage.Visibility = Visibility.Collapsed;
                NomessagePage.Visibility = Visibility.Visible;
            }
            if (CommodityNum >= 1 && CommodityNum <= 4)
            {
                PerCommodityLineTwo.Visibility = Visibility.Collapsed;
                PerCommodityLineThree.Visibility = Visibility.Collapsed;
                PerCommodityLineFour.Visibility = Visibility.Collapsed;
                Check(PerOneRowFourCloum, PerOneRowTwoCloum, PerOneRowThreeCloum, 4 - CommodityNum);
            }
            if (CommodityNum >= 5 && CommodityNum <= 8)
            {
                PerCommodityLineThree.Visibility = Visibility.Collapsed;
                PerCommodityLineFour.Visibility = Visibility.Collapsed;
                Check(PerTwoRowFourCloum, PerTwoRowTwoCloum, PerTwoRowThreeCloum, 8 - CommodityNum);
            }
            if (CommodityNum >= 9 && CommodityNum <= 12)
            {
                PerCommodityLineFour.Visibility = Visibility.Collapsed;
                Check(PerThreeRowFourCloum, PerThreeRowTwoCloum, PerThreeRowThreeCloum, 12 - CommodityNum);
            }
            if (CommodityNum > 12)
            {
                Check(PerFourRowFourCloum, PerFourRowTwoCloum, PerFourRowThreeCloum, 16 - CommodityNum);
            }
            List<Template.HouseSample> ListHouse = new List<Template.HouseSample> { PerOneRowOneCloum,PerOneRowTwoCloum,PerOneRowThreeCloum,PerOneRowFourCloum,
                PerTwoRowOneCloum,PerTwoRowTwoCloum,PerTwoRowThreeCloum,PerTwoRowFourCloum,
            PerThreeRowOneCloum,PerThreeRowTwoCloum,PerThreeRowThreeCloum,PerThreeRowFourCloum,PerFourRowOneCloum,PerFourRowTwoCloum,PerFourRowThreeCloum,PerFourRowFourCloum};
            ContolDataBinding(ListHouse, CommodityNum,Information);
            PerPageChange(1, PageNum);
        }

        public void MarckLoad(int CommodityNum,List<string> Information)
        {
            if (CommodityNum == 0)
            {
                MarketPage.Visibility = Visibility.Collapsed;
                NomessagePage.Visibility = Visibility.Visible;
            }
            if (CommodityNum >= 1 && CommodityNum <= 4)
            {
                CommodityLineTwo.Visibility = Visibility.Collapsed;
                CommodityLineThree.Visibility = Visibility.Collapsed;
                CommodityLineFour.Visibility = Visibility.Collapsed;
                Check(OneRowFourCloum, OneRowTwoCloum, OneRowThreeCloum, 4 - CommodityNum);
            }
            if(CommodityNum >= 5 && CommodityNum <= 8)
            {
                CommodityLineThree.Visibility = Visibility.Collapsed;
                CommodityLineFour.Visibility = Visibility.Collapsed;
                Check(TwoRowFourCloum, TwoRowTwoCloum, TwoRowThreeCloum, 8 - CommodityNum);
            }
            if (CommodityNum >= 9 && CommodityNum <= 12)
            {
                CommodityLineFour.Visibility = Visibility.Collapsed;
                Check(ThreeRowFourCloum, ThreeRowTwoCloum, ThreeRowThreeCloum, 12 - CommodityNum);
            }
            if (CommodityNum > 12)
            {
                Check(FourRowFourCloum, FourRowTwoCloum, FourRowThreeCloum, 16 - CommodityNum);
            }
            List<Template.HouseSample> ListHouse = new List<Template.HouseSample> { OneRowOneCloum,OneRowTwoCloum,OneRowThreeCloum,OneRowFourCloum,
                TwoRowOneCloum,TwoRowTwoCloum,TwoRowThreeCloum,TwoRowFourCloum,
            ThreeRowOneCloum,ThreeRowTwoCloum,ThreeRowThreeCloum,ThreeRowFourCloum,FourRowOneCloum,FourRowTwoCloum,FourRowThreeCloum,FourRowFourCloum};
            ContolDataBinding(ListHouse, CommodityNum,Information);
            PageChange(1, PageNum);
        }

        public void Check(Template.HouseSample Four, Template.HouseSample Two, Template.HouseSample Three,int Num)
        {
            switch (Num)
            {
                case 0:

                    break;
                case 1:
                    Four.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    Four.Visibility = Visibility.Collapsed;
                    Three.Visibility = Visibility.Collapsed;
                    break;
                case 3:
                    Four.Visibility = Visibility.Collapsed;
                    Three.Visibility = Visibility.Collapsed;
                    Two.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        public void ContolDataBinding(List<Template.HouseSample> houseSamples,int CommodityNum,List<string> list)
        {
            for (int i = 0; i < CommodityNum; i++)
            {
                DataBinding(houseSamples[i], i,list);
            }
        }

       public void DataBinding(Template.HouseSample HouseClass,int HouseIndex,List<string> list)
        {
            StringToDisplay callDuration = new StringToDisplay();
            HouseClass.DataContext = callDuration;
            callDuration.OneHouseListType = service.SingleHouser(list[HouseIndex])[0];
            callDuration.OneHouseListAddresss = service.SingleHouser(list[HouseIndex])[1];
            callDuration.OneHouseListRent = service.SingleHouser(list[HouseIndex])[2];
            callDuration.OneHouseListState = service.SingleHouser(list[HouseIndex])[4];
        }

        #endregion

        #region Menu

        #region Menu点击事件
        private void FourMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuToAsIs(FourMenu, FourMenuImg, DataTemp.UserBlueImg);
            MenuToBlue(HomeMenu, HomeMenuImg, DataTemp.HomeMenuAsIsImg);
            MenuToBlue(OneMenu, OneMemuImg, DataTemp.LeaseAsIsImg);
            MenuToBlue(TwoMenu, TwoMenuImg, DataTemp.StatisticsAsIsImg);
            MenuToBlue(ThreeMenu,ThreeMenuImg ,DataTemp.ToMoDaChiAsIsImg);

        }

        private void ThreeMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuToAsIs(ThreeMenu, ThreeMenuImg, DataTemp.ToMoDaChiBlueImg);
            MenuToBlue(HomeMenu, HomeMenuImg, DataTemp.HomeMenuAsIsImg);
            MenuToBlue(OneMenu, OneMemuImg, DataTemp.LeaseAsIsImg);
            MenuToBlue(TwoMenu,TwoMenuImg, DataTemp.StatisticsAsIsImg); 
            MenuToBlue(FourMenu, FourMenuImg, DataTemp.UserAsIsImg);

        }

        private void TwoMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuToAsIs(TwoMenu, TwoMenuImg, DataTemp.StatisticsBlueImg);
            MenuToBlue(HomeMenu, HomeMenuImg, DataTemp.HomeMenuAsIsImg);
            MenuToBlue(OneMenu, OneMemuImg, DataTemp.LeaseAsIsImg);
            MenuToBlue(ThreeMenu, ThreeMenuImg, DataTemp.ToMoDaChiAsIsImg);
            MenuToBlue(FourMenu, FourMenuImg, DataTemp.UserAsIsImg);

        }

        private void OneMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuToAsIs(OneMenu, OneMemuImg, DataTemp.LeaseMenuBlueImg);
            MenuToBlue(HomeMenu, HomeMenuImg, DataTemp.HomeMenuAsIsImg);
            MenuToBlue(TwoMenu, TwoMenuImg, DataTemp.StatisticsAsIsImg);
            MenuToBlue(ThreeMenu, ThreeMenuImg, DataTemp.ToMoDaChiAsIsImg);
            MenuToBlue(FourMenu, FourMenuImg, DataTemp.UserAsIsImg);
            MenuPageOp(1);
            MarckLoad(service.AllCount(DataTemp.Username)[0], service.DrawAll());
        }

        private void HomeMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuToAsIs(HomeMenu,HomeMenuImg, DataTemp.HomeMenuBlueImg); 
            MenuToBlue(OneMenu,OneMemuImg, DataTemp.LeaseAsIsImg); 
            MenuToBlue(TwoMenu, TwoMenuImg, DataTemp.StatisticsAsIsImg);
            MenuToBlue(ThreeMenu, ThreeMenuImg, DataTemp.ToMoDaChiAsIsImg);
            MenuToBlue(FourMenu, FourMenuImg, DataTemp.UserAsIsImg);
            MenuPageOp(0);
        }

        private void MasterClose_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        #endregion

        #region Menu的动画变化
        public void MenuToBlue(DependencyObject ControlOb,Image image, string Url)
        {
            Storyboard MenuAnime = new Storyboard();

            ColorAnimation MenuColor = new ColorAnimation();
            MenuColor.To = Color.FromRgb(50, 83, 241);
            MenuColor.Duration = new TimeSpan(0, 0, 0, 0, 200);

            Storyboard.SetTarget(MenuColor, ControlOb);
            Storyboard.SetTargetProperty(MenuColor, new PropertyPath("(Border.Background).(SolidColorBrush.Color)"));

            MenuAnime.Children.Add(MenuColor);

            ImgChange(image, Url);
            MenuAnime.Begin();
        }

        public void MenuToAsIs(DependencyObject ControlOb,Image image,string Url)
        {
            Storyboard MenuAnime = new Storyboard();

            ColorAnimation MenuColor = new ColorAnimation();
            MenuColor.To = Colors.White;
            MenuColor.Duration = new TimeSpan(0, 0, 0, 0, 200);

            Storyboard.SetTarget(MenuColor,ControlOb);
            Storyboard.SetTargetProperty(MenuColor, new PropertyPath("(Border.Background).(SolidColorBrush.Color)"));

            MenuAnime.Children.Add(MenuColor);

            ImgChange(image,Url);
            MenuAnime.Begin();
        }
        #endregion

        #region Menu的图片变化

        public void ImgChange(Image image,string Url)
        {
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.CacheOption = BitmapCacheOption.OnLoad;
            bi.UriSource = new Uri(Url, UriKind.RelativeOrAbsolute);
            bi.EndInit();
            image.Source = bi;
        }

        #endregion

        #region Menu 页面变化

        public void ChangePageOP(DependencyObject DobOne,DependencyObject DobTwo,Grid grid,Grid Twogrid)
        {
            Storyboard storyboard = new Storyboard();

            DoubleAnimation OnedbAnimation = new DoubleAnimation();
            DoubleAnimation TwodbAnimation = new DoubleAnimation();

            OnedbAnimation.To = 0;
            TwodbAnimation.To = 1;
            OnedbAnimation.Duration = new TimeSpan(0, 0, 0, 0, 400);
            TwodbAnimation.Duration = new TimeSpan(0, 0, 0, 0, 600);

            Storyboard.SetTarget(OnedbAnimation, DobOne);
            Storyboard.SetTarget(TwodbAnimation, DobTwo);

            Storyboard.SetTargetProperty(OnedbAnimation, new PropertyPath("Opacity"));
            Storyboard.SetTargetProperty(TwodbAnimation, new PropertyPath("Opacity"));

            storyboard.Children.Add(OnedbAnimation);
            storyboard.Children.Add(TwodbAnimation);

            storyboard.Begin();

            grid.Visibility = Visibility.Collapsed;
            Twogrid.Visibility = Visibility.Visible;
        }

        public void MenuPageOp(int Page)
        {
            switch (Page)
            {
                case 0:
                    ChangePageOP(RentalPage, HomePage,RentalPage,HomePage);
                    break;
                case 1:
                    ChangePageOP(HomePage, RentalPage,HomePage,RentalPage);
                    break;
            }
        }

        #endregion

        #endregion

        #region SalesList用户信息

        public void SalesListLoad()
        {
            DataTemp.TenantUser = service.RencentTenants()[1];
            DataTemp.LeaseTerm = service.RencentTenants()[2];
            DataTemp.Rent = service.RencentTenants()[3];

            DataTemp.SecondTenantUser = service.SecondRencentTenant()[1];
            DataTemp.SecondLeaseTerm = service.SecondRencentTenant()[2];
            DataTemp.SecondRent = service.SecondRencentTenant()[3];
            OneUser(DataTemp.TenantUser,DataTemp.LeaseTerm,DataTemp.Rent);
            SecondUser(DataTemp.SecondTenantUser, DataTemp.SecondLeaseTerm, DataTemp.SecondRent);
        }

        public void OneUser(string UserName,string LeaseTeem,string Rent)
        {
            StringToDisplay callDuration = new StringToDisplay();
            OneSalesListUser.DataContext = callDuration;
            callDuration.OneUserName = UserName;
            callDuration.OneLeaseTerm = LeaseTeem + "月";
            callDuration.OneRent = "￥" + Rent;
        }

        public void SecondUser(string UserName, string LeaseTeem, string Rent)
        {
            StringToDisplay callDuration = new StringToDisplay();
            SecondSalesListUser.DataContext = callDuration;
            callDuration.SecondUserName = UserName;
            callDuration.SecondLeaseTerm = LeaseTeem + "月";
            callDuration.SecondRent = "￥" + Rent;
        }

        #endregion

        #region HouseList房主的房子信息

        public void HouseListLoad(string UserName)
        {
            DataTemp.OneHouseType = service.OneHouseListInformation(UserName)[0];
            DataTemp.OneHouseAddress = service.OneHouseListInformation(UserName)[1];
            DataTemp.OneHouseMonthlyRent = service.OneHouseListInformation(UserName)[2];
            DataTemp.OneHouserState = service.OneHouseListInformation(UserName)[4];

            DataTemp.TwoHouseType = service.TwoHouseListInformation(UserName)[0];
            DataTemp.TwoHouseAddress = service.TwoHouseListInformation(UserName)[1];
            DataTemp.TwoHouseMonthlyRent = service.TwoHouseListInformation(UserName)[2];
            DataTemp.TwoHouserState = service.TwoHouseListInformation(UserName)[4];

            DataTemp.ThreeHouseType = service.ThreeHouseListInformation(UserName)[0];
            DataTemp.ThreeHouseAddress = service.ThreeHouseListInformation(UserName)[1];
            DataTemp.ThreeHouseMonthlyRent = service.ThreeHouseListInformation(UserName)[2];
            DataTemp.ThreeHouserState = service.ThreeHouseListInformation(UserName)[4];

            OneHouseList(DataTemp.OneHouseAddress, DataTemp.OneHouseType, DataTemp.OneHouseMonthlyRent, DataTemp.OneHouserState);
            TwoHouseList(DataTemp.TwoHouseAddress, DataTemp.TwoHouseType, DataTemp.TwoHouseMonthlyRent, DataTemp.TwoHouserState);
            ThreeHouseList(DataTemp.ThreeHouseAddress, DataTemp.ThreeHouseType, DataTemp.ThreeHouseMonthlyRent, DataTemp.ThreeHouserState);
        }

        public void OneHouseList(string Address,string Type,string Rent,string State)
        {
            if(Address.Length > 13)
            {
                Address = Address.Substring(0, 11) + "...";
            }
            StringToDisplay callDuration = new StringToDisplay();
            HouseListOne.DataContext = callDuration;
            callDuration.OneHouseListAddresss = Address;
            callDuration.OneHouseListType = Type;
            callDuration.OneHouseListRent = Rent;
            callDuration.OneHouseListState = State;
        }

        public void TwoHouseList(string Address, string Type, string Rent, string State)
        {
            if (Address.Length > 13)
            {
                Address = Address.Substring(0, 11) + "...";
            }
            StringToDisplay callDuration = new StringToDisplay();
            HouseListTwo.DataContext = callDuration;
            callDuration.TwoHouseListAddresss = Address;
            callDuration.TwoHouseListType = Type;
            callDuration.TwoHouseListRent = Rent;
            callDuration.TwoHouseListState = State;
        }

        public void ThreeHouseList(string Address, string Type, string Rent, string State)
        {
            if (Address.Length > 13)
            {
                Address = Address.Substring(0, 11) + "...";
            }
            StringToDisplay callDuration = new StringToDisplay();
            HouseListThree.DataContext = callDuration;
            callDuration.ThreeHouseListAddresss = Address;
            callDuration.ThreeHouseListType = Type;
            callDuration.ThreeHouseListRent = Rent;
            callDuration.ThreeHouseListState = State;
        }
        #endregion

        #region 商品详情页

        #region 页数变化

        private void PreviousPageButton_Click(object sender, RoutedEventArgs e)
        {
            JudgeAll();
        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            
            NextJudgeAll();

        }

        public void JudgeAll()
        {
            if (MarketPage.Visibility == Visibility.Visible)
            {
                int Num = DataTemp.MarketPageNum;
                if (Num > 1)
                {
                    Num--;
                    int PageCommodityNum = Num * 16;
                    MarketJudgePage(Num, PageCommodityNum);
                }
            }
            if (PersonalPage.Visibility == Visibility.Visible)
            {
                int Num = DataTemp.PersonalPageNum;
                if (Num > 1)
                {
                    Num--;
                    int PageCommodityNum = Num * 16;
                    MarketJudgePage(Num, PageCommodityNum);
                }
            }
        }

        public void NextJudgeAll()
        {
            if (MarketPage.Visibility == Visibility.Visible)
            {
                int Num = DataTemp.MarketPageNum;
                Num++;
                int PageCommodityNum = Num * 16;
                MarketJudgePage(Num, PageCommodityNum);
            }
            if (PersonalPage.Visibility == Visibility.Visible)
            {
                int Num = DataTemp.PersonalPageNum;
                Num++;
                int PageCommodityNum = Num * 16;
                PersonalJudgePage(Num, PageCommodityNum);
            }
        }

        public void PersonalJudgePage(int Num,int PageCommodityNum)
        {
            if (service.AllCount(DataTemp.Username)[0] - PageCommodityNum > -16)
            {
                PersonalJudgePage(Num, PageCommodityNum);
            }
        }

        public void MarketJudgePage(int Num,int PageCommodityNum)
        {
            if (service.AllCount(DataTemp.Username)[0] - PageCommodityNum > -16)
            {
                JudgePage(Num, PageCommodityNum);
            }
        }

        public void JudgePage(int Num,int PageCommodityNum)
        {
            MarckLoad(PageCommodityNum - service.AllCount(DataTemp.Username)[0], service.ChoiceDrawAll(Num));
            PageChange(Num, PageNum);
        }

        public void PerJudgePage(int Num,int PageCommodityNum)
        {
            PersonalLoad(PageCommodityNum - service.AllCount(DataTemp.Username)[0], service.ChoiceDrawAll(Num));
            PerPageChange(Num, PageNum);
        }

        #endregion


        private void CommodityLoad_Down(object sender, MouseButtonEventArgs e)
        {
            List<Template.HouseSample> ListHouse = new List<Template.HouseSample> { OneRowOneCloum,OneRowTwoCloum,OneRowThreeCloum,OneRowFourCloum,
                TwoRowOneCloum,TwoRowTwoCloum,TwoRowThreeCloum,TwoRowFourCloum,
            ThreeRowOneCloum,ThreeRowTwoCloum,ThreeRowThreeCloum,ThreeRowFourCloum,FourRowOneCloum,FourRowTwoCloum,FourRowThreeCloum,FourRowFourCloum};

            Template.HouseSample d = sender as Template.HouseSample;
            //string ContolName = d.Name;
            //Template.HouseSample c = new Template.HouseSample();
            //c.Name = ContolName;

            int ListIndex = ListHouse.IndexOf(d);
            CommodityAssignment(DetControl,ListIndex, service.DrawAll());
            CommodityDisplay(MarketPage, DatailsPage,MarketPage,DatailsPage,ControlGroup,BackFunction);
        }

        private void PerCommodityLoda_Down(object sender,MouseButtonEventArgs e)
        {
            List<Template.HouseSample> ListHouse = new List<Template.HouseSample> { PerOneRowOneCloum,PerOneRowTwoCloum,PerOneRowThreeCloum,PerOneRowFourCloum,
                PerTwoRowOneCloum,PerTwoRowTwoCloum,PerTwoRowThreeCloum,PerTwoRowFourCloum,
            PerThreeRowOneCloum,PerThreeRowTwoCloum,PerThreeRowThreeCloum,PerThreeRowFourCloum,PerFourRowOneCloum,PerFourRowTwoCloum,PerFourRowThreeCloum,PerFourRowFourCloum};

            Template.HouseSample d = sender as Template.HouseSample;
            int ListIndex = ListHouse.IndexOf(d);
            CommodityAssignment(DetControl, ListIndex, service.PerDrawAll(DataTemp.Username));
            CommodityDisplay(PersonalPage, DatailsPage, PersonalPage, DatailsPage, ControlGroup, BackFunction);
        }

        public void CommodityAssignment(Template.HouseDetailsPage HouseClass, int CommodityNum, List<string> list)
        {
            StringToDisplay callDuration = new StringToDisplay();
            HouseClass.DataContext = callDuration;
            callDuration.DetHouseType = service.SingleHouser(list[CommodityNum])[0];
            callDuration.DetHouseAddress = service.SingleHouser(list[CommodityNum])[1];
            callDuration.DetHouseRent = service.SingleHouser(list[CommodityNum])[2];
            callDuration.DetHouseMaster = service.SingleHouser(list[CommodityNum])[3];
            callDuration.DetHouseState = service.SingleHouser(list[CommodityNum])[4];
            callDuration.DetHouseTenant = service.SingleHouser(list[CommodityNum])[5];
            callDuration.DetHouseAge = service.SingleHouser(list[CommodityNum])[6];
            callDuration.HireText = service.CheckHireUserName(DataTemp.Username, service.SingleHouser(list[CommodityNum])[3]);
        }

        public void CommodityDisplay(DependencyObject Ob,DependencyObject ObDisPlay,Grid grid,Grid gridDis,StackPanel TopButton,StackPanel TopButtonDis)
        {
            Storyboard storyboard = new Storyboard();

            DoubleAnimation AnimationHide = new DoubleAnimation();
            DoubleAnimation AnimationDis = new DoubleAnimation();

            AnimationHide.To = 0;
            AnimationDis.To = 1;
            AnimationHide.Duration = new TimeSpan(0, 0, 0, 0, 600);
            AnimationDis.Duration = new TimeSpan(0, 0, 0, 0, 600);

            Storyboard.SetTarget(AnimationHide, Ob);
            Storyboard.SetTarget(AnimationDis, ObDisPlay);
            Storyboard.SetTargetProperty(AnimationHide, new PropertyPath("Opacity"));
            Storyboard.SetTargetProperty(AnimationDis, new PropertyPath("Opacity"));

            storyboard.Children.Add(AnimationHide);
            storyboard.Children.Add(AnimationDis);

            storyboard.Begin();

            grid.Visibility = Visibility.Collapsed;
            gridDis.Visibility = Visibility.Visible;

            TopButton.Visibility = Visibility.Collapsed;
            TopButtonDis.Visibility = Visibility.Visible;

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            CommodityDisplay(DatailsPage, MarketPage, DatailsPage, MarketPage, BackFunction, ControlGroup);
        }

        #endregion

        #region 数据统计表

        public void LoadDataSheet(String UserName)
        {
            StatisticalDataLine(service.GetSalesDataPoint(UserName));
        }
        public void StatisticalDataLine(int[] ts)
        {
            StringToDisplay callDuration = new StringToDisplay();
            FirstDataLine.DataContext = callDuration;
            callDuration.ValuesToLine = new ChartValues<ObservablePoint>
            {
                new ObservablePoint(0,ts[0]),new ObservablePoint(1,ts[1]),
                new ObservablePoint(2,ts[2]),new ObservablePoint(3,ts[3]),
                new ObservablePoint(4,ts[4]),new ObservablePoint(5,ts[5]),
                new ObservablePoint(6,ts[6]),new ObservablePoint(7,ts[7]),
                new ObservablePoint(8,ts[8]),new ObservablePoint(9,ts[9]),
                new ObservablePoint(10,ts[10]),new ObservablePoint(11,ts[11]),
                
            };
        }
        #endregion

        #region 好友列表加载 FriendsListLoad
        public void FriendsListLoad(string UserName)
        {
            FirstFriend(UserName);
            SecondFriend(UserName);
        }

        public void FirstFriend(string UserName)
        {
            StringToDisplay callDuration = new StringToDisplay();
            FirstFriendCard.DataContext = callDuration;
            callDuration.FriendsListUserName = service.GetFriens(UserName)[0];
        }

        public void SecondFriend(string UserName)
        {
            StringToDisplay callDuration = new StringToDisplay();
            SecondFriendCard.DataContext = callDuration;
            callDuration.FriendsListUserName = service.GetFriens(UserName)[1];
        }

        #endregion



        #region RentalPage

        #region Button

        private void PersonalButton_MouseLeave(object sender, MouseEventArgs e)
        {
            if(RentalButtonFalg == 0)
            {
                RentalButtonLeave(PersonalButton);
            }
        }

        private void MarketButton_MouseLeave(object sender, MouseEventArgs e)
        {
            if(RentalButtonFalg == 1)
            {
                RentalButtonLeave(MarketButton);
            }
        }
        private void MarketButton_MouseEnter(object sender, MouseEventArgs e)
        {
            if(RentalButtonFalg == 1)
            {
                RentalButtonEnter(MarketButton);
            }
        }

        private void PersonalButton_MouseEnter(object sender, MouseEventArgs e)
        {
            if(RentalButtonFalg == 0)
            {
                RentalButtonEnter(PersonalButton);
            }
        }

        private void PersonalButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(RentalButtonFalg == 0)
            {
                RentalButtonDown(PersonalButton, MarketButton,MarketText, PersonalText);
                MiniPage(MarketPage, PersonalPage, MarketPage, PersonalPage,AddHouse);
                PersonalLoad(service.AllCount(DataTemp.Username)[0],service.PerDrawAll(DataTemp.Username));
                RentalButtonFalg = 1;
            }
        }

        private void MarketButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(RentalButtonFalg == 1)
            {
                RentalButtonDown(MarketButton, PersonalButton, PersonalText, MarketText);
                MiniPage(PersonalPage, MarketPage, PersonalPage, MarketPage,AddHouse);
                RentalButtonFalg = 0;
            }
        }

        public void RentalButtonEnter(DependencyObject Dob)
        {
            Storyboard storyboard = new Storyboard();

            ColorAnimation colorAnimation = new ColorAnimation();

            colorAnimation.To = Color.FromRgb(230,234,235);
            colorAnimation.Duration = new TimeSpan(0, 0, 0, 0, 100);

            Storyboard.SetTarget(colorAnimation, Dob);
            Storyboard.SetTargetProperty(colorAnimation, new PropertyPath("(Border.Background).(SolidColorBrush.Color)"));

            storyboard.Children.Add(colorAnimation);

            storyboard.Begin();
        }

        public void RentalButtonLeave(DependencyObject Dob)
        {
            Storyboard storyboard = new Storyboard();

            ColorAnimation colorAnimation = new ColorAnimation();

            colorAnimation.To = Colors.Transparent;
            colorAnimation.Duration = new TimeSpan(0, 0, 0, 0, 100);

            Storyboard.SetTarget(colorAnimation, Dob);
            Storyboard.SetTargetProperty(colorAnimation, new PropertyPath("(Border.Background).(SolidColorBrush.Color)"));

            storyboard.Children.Add(colorAnimation);

            storyboard.Begin();
        }

        public void RentalButtonDown(DependencyObject DobOne,DependencyObject DobTwo,DependencyObject FontDob,DependencyObject FontTwo)
        {
            Storyboard storyboard = new Storyboard();

            ColorAnimation colorAnimation = new ColorAnimation();
            ColorAnimation ElesAnimetion = new ColorAnimation();

            ColorAnimation FontAnimetion = new ColorAnimation();
            ColorAnimation FontTwoAnimetion = new ColorAnimation();

            FontAnimetion.To = Color.FromRgb(50, 83, 241);
            FontTwoAnimetion.To = Colors.White;
            FontTwoAnimetion.Duration = new TimeSpan(0, 0, 0, 0, 200);
            FontAnimetion.Duration = new TimeSpan(0, 0, 0, 0, 200);

            colorAnimation.To = Colors.Transparent;
            ElesAnimetion.To = Color.FromRgb(50, 83, 241);
            colorAnimation.Duration = new TimeSpan(0, 0, 0, 0, 200);
            ElesAnimetion.Duration = new TimeSpan(0, 0, 0, 0, 200);

            Storyboard.SetTarget(colorAnimation, DobTwo);
            Storyboard.SetTarget(ElesAnimetion, DobOne);

            Storyboard.SetTarget(FontAnimetion, FontDob);
            Storyboard.SetTarget(FontTwoAnimetion, FontTwo);

            Storyboard.SetTargetProperty(FontAnimetion, new PropertyPath("(TextBlock.Foreground).(SolidColorBrush.Color)"));
            Storyboard.SetTargetProperty(FontTwoAnimetion, new PropertyPath("(TextBlock.Foreground).(SolidColorBrush.Color)"));

            Storyboard.SetTargetProperty(colorAnimation, new PropertyPath("(Border.Background).(SolidColorBrush.Color)"));
            Storyboard.SetTargetProperty(ElesAnimetion, new PropertyPath("(Border.Background).(SolidColorBrush.Color)"));

            storyboard.Children.Add(FontAnimetion);
            storyboard.Children.Add(FontTwoAnimetion);

            storyboard.Children.Add(ElesAnimetion);
            storyboard.Children.Add(colorAnimation);

            storyboard.Begin();
        }

        public void MiniPage(DependencyObject dob,DependencyObject Twodob,Grid grid,Grid Twogrid,Grid AddGrid)
        {
            Storyboard storyboard = new Storyboard();

            DoubleAnimation doubleAnimation = new DoubleAnimation();
            DoubleAnimation TwodoubleAnimation = new DoubleAnimation();

            doubleAnimation.To = 0;
            TwodoubleAnimation.To = 1;

            Storyboard.SetTarget(doubleAnimation, dob);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity"));

            Storyboard.SetTarget(TwodoubleAnimation, Twodob);
            Storyboard.SetTargetProperty(TwodoubleAnimation, new PropertyPath("Opacity"));

            storyboard.Children.Add(doubleAnimation);
            storyboard.Children.Add(TwodoubleAnimation);

            storyboard.Begin();

            grid.Visibility = Visibility.Collapsed;
            Twogrid.Visibility = Visibility.Visible;
            AddGrid.Visibility = Visibility.Collapsed;
        }

        #endregion

        #region 搜索框

        private void txtSerch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSerch.Text))
            {
                textSerch.Visibility = Visibility.Collapsed;
            }
            else
            {
                textSerch.Visibility = Visibility.Visible;
            }
        }

        private void textSerch_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtSerch.Focus();
        }





        #endregion

        #endregion


        #region AddHouse 添加房屋
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddHouse.Visibility = Visibility.Visible;

            MarketPage.Visibility = Visibility.Collapsed;
            PersonalPage.Visibility = Visibility.Collapsed;
        }

        


        #endregion
    }
}
