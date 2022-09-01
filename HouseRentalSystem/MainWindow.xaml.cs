using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using HouseRentalSystem.Template;
using System.Windows.Threading;
using HouseRentalSystem.Data;

namespace HouseRentalSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int mini = 0;
        int CodeMini = 60;
        int GenderCheck = 0;
        public int ButtonFalg = 0;
        DataTemp dataTemp = new DataTemp();

        Service Service = new Service();
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer Codetimer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            Load();
            MainTopImgLoad(DataTemp.HearPath);
            Ppbox.Width = SystemParameters.WorkArea.Width * 0.62;
            this.Width = SystemParameters.WorkArea.Width * 0.72;
            this.Height = SystemParameters.WorkArea.Height * 0.72;
        }

        #region 加载事件

        public void MainTopImgLoad(string Url)
        {
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.CacheOption = BitmapCacheOption.OnLoad;
            bi.UriSource = new Uri(Url, UriKind.RelativeOrAbsolute);
            bi.EndInit();
            MainTopImg.Source = bi;
        }

        public void Load()
        {
            MainForm.Opacity = 0;
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

            Storyboard.SetTarget(DaMainForm, MainForm);
            Storyboard.SetTargetProperty(DaMainForm, new PropertyPath("Opacity"));

            ST.Children.Add(DaMainForm);
            ST.Begin();
        }
        #endregion


        #region 按钮事件


        #region 选择性别的按钮
        private void ManButton_Click(object sender, RoutedEventArgs e)
        {
            if (GenderCheck == 1 || GenderCheck == 0)
            {
                DataTemp.Gender = "男";
                GenderButtonChange(WomanButton, ManButton);
                GenderCheck = 2;
            }
        }

        private void WomanButton_Click(object sender, RoutedEventArgs e)
        {
            if (GenderCheck == 2 || GenderCheck == 0)
            {
                DataTemp.Gender = "女";
                GenderButtonChange(ManButton, WomanButton);
                GenderCheck = 1;
            }
        }

        private void ManButton_MouseLeave(object sender, MouseEventArgs e)
        {
            if (GenderCheck == 1 || GenderCheck == 0)
            {
                GenderButtonAnimeBack(ManButton);
            }

        }

        private void ManButton_MouseEnter(object sender, MouseEventArgs e)
        {
            if (GenderCheck == 1 || GenderCheck == 0)
            {
                GenderButtonAnimeTo(ManButton);
            }

        }

        private void WomanButton_MouseEnter(object sender, MouseEventArgs e)
        {
            if (GenderCheck == 2 || GenderCheck == 0)
            {
                GenderButtonAnimeTo(WomanButton);
            }

        }

        private void WomanButton_MouseLeave(object sender, MouseEventArgs e)
        {
            if (GenderCheck == 2 || GenderCheck == 0)
            {
                GenderButtonAnimeBack(WomanButton);
            }
        }

        public void GenderButtonAnimeBack(DependencyObject DeOb)
        {
            Storyboard storyboard = new Storyboard();

            ColorAnimation colorAnimation = new ColorAnimation();

            colorAnimation.To = Color.FromRgb(198, 198, 198);
            colorAnimation.Duration = new TimeSpan(0, 0, 0, 0, 100);

            Storyboard.SetTarget(colorAnimation, DeOb);
            Storyboard.SetTargetProperty(colorAnimation, new PropertyPath("Background.(SolidColorBrush.Color)"));

            storyboard.Children.Add(colorAnimation);
            storyboard.Begin();
        }
        public void GenderButtonAnimeTo(DependencyObject DeOb)
        {
            Storyboard storyboard = new Storyboard();

            ColorAnimation colorAnimation = new ColorAnimation();

            colorAnimation.To = Color.FromRgb(54, 54, 54);
            colorAnimation.Duration = new TimeSpan(0, 0, 0, 0, 100);

            Storyboard.SetTarget(colorAnimation, DeOb);
            Storyboard.SetTargetProperty(colorAnimation, new PropertyPath("Background.(SolidColorBrush.Color)"));

            storyboard.Children.Add(colorAnimation);
            storyboard.Begin();
        }

        public void GenderButtonChange(DependencyObject DeOb, DependencyObject DeObTwo)
        {
            Storyboard BackgroundST = new Storyboard();

            ColorAnimation ColorAnime = new ColorAnimation();
            ColorAnimation BaColorAnime = new ColorAnimation();

            ColorAnime.To = Color.FromRgb(54, 54, 54);
            BaColorAnime.To = Color.FromRgb(198, 198, 198);

            ColorAnime.Duration = new TimeSpan(0, 0, 0, 0, 200);
            BaColorAnime.Duration = new TimeSpan(0, 0, 0, 0, 200);

            Storyboard.SetTarget(BaColorAnime, DeOb);
            Storyboard.SetTarget(ColorAnime, DeObTwo);

            Storyboard.SetTargetProperty(BaColorAnime, new PropertyPath("Background.(SolidColorBrush.Color)"));
            Storyboard.SetTargetProperty(ColorAnime, new PropertyPath("Background.(SolidColorBrush.Color)"));

            BackgroundST.Children.Add(BaColorAnime);
            BackgroundST.Children.Add(ColorAnime);

            BackgroundST.Begin();
        }

        #endregion

        #region 登录注册按钮
        private void Register_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ButtonFalg == 0)
            {
                RegisterButtonChangeGO();
                LoginButtonChangeBack();
                RegisterForm.Visibility = Visibility.Visible;
                ResisterFormOP();

                ButtonFalg = 1;
            }
            else
            {

            }

        }

        private void Register_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ButtonFalg == 0)
            {
                Storyboard enlarge = new Storyboard();

                DoubleAnimation DA = new DoubleAnimation();
                DoubleAnimation DATwo = new DoubleAnimation();

                DA.To = 120;
                DATwo.To = 80;
                DA.Duration = new TimeSpan(0, 0, 0, 0, 200);
                DATwo.Duration = new TimeSpan(0, 0, 0, 0, 200);

                Storyboard.SetTarget(DA, Register);
                Storyboard.SetTarget(DATwo, Register);
                Storyboard.SetTargetProperty(DA, new PropertyPath("Width"));
                Storyboard.SetTargetProperty(DATwo, new PropertyPath("Height"));

                enlarge.Children.Add(DA);
                enlarge.Children.Add(DATwo);
                enlarge.Begin();
            }

        }

        private void Register_MouseLeave(object sender, MouseEventArgs e)
        {
            Storyboard enlarge = new Storyboard();

            DoubleAnimation DA = new DoubleAnimation();
            DoubleAnimation DATwo = new DoubleAnimation();

            DA.To = 115;
            DATwo.To = 75;
            DA.Duration = new TimeSpan(0, 0, 0, 0, 200);
            DATwo.Duration = new TimeSpan(0, 0, 0, 0, 200);

            Storyboard.SetTarget(DA, Register);
            Storyboard.SetTarget(DATwo, Register);
            Storyboard.SetTargetProperty(DA, new PropertyPath("Width"));
            Storyboard.SetTargetProperty(DATwo, new PropertyPath("Height"));

            enlarge.Children.Add(DA);
            enlarge.Children.Add(DATwo);
            enlarge.Begin();

        }



        private void ButtonLogin_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ButtonFalg == 1)
            {
                Storyboard enlarge = new Storyboard();

                DoubleAnimation DA = new DoubleAnimation();
                DoubleAnimation DATwo = new DoubleAnimation();

                DA.To = 120;
                DATwo.To = 80;
                DA.Duration = new TimeSpan(0, 0, 0, 0, 200);
                DATwo.Duration = new TimeSpan(0, 0, 0, 0, 200);

                Storyboard.SetTarget(DA, ButtonLogin);
                Storyboard.SetTarget(DATwo, ButtonLogin);
                Storyboard.SetTargetProperty(DA, new PropertyPath("Width"));
                Storyboard.SetTargetProperty(DATwo, new PropertyPath("Height"));

                enlarge.Children.Add(DA);
                enlarge.Children.Add(DATwo);
                enlarge.Begin();
            }
        }

        private void ButtonLogin_MouseLeave(object sender, MouseEventArgs e)
        {
            Storyboard enlarge = new Storyboard();

            DoubleAnimation DA = new DoubleAnimation();
            DoubleAnimation DATwo = new DoubleAnimation();

            DA.To = 115;
            DATwo.To = 75;
            DA.Duration = new TimeSpan(0, 0, 0, 0, 200);
            DATwo.Duration = new TimeSpan(0, 0, 0, 0, 200);

            Storyboard.SetTarget(DA, ButtonLogin);
            Storyboard.SetTarget(DATwo, ButtonLogin);
            Storyboard.SetTargetProperty(DA, new PropertyPath("Width"));
            Storyboard.SetTargetProperty(DATwo, new PropertyPath("Height"));

            enlarge.Children.Add(DA);
            enlarge.Children.Add(DATwo);
            enlarge.Begin();
        }

        private void ButtonLogin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ButtonFalg == 1)
            {
                LoginButtonChangeGo();
                RegisterButtonChangeBack();
                LoginPass.Visibility = Visibility.Visible;
                LoginFormOP();

                ButtonFalg = 0;
            }
        }


        public void LoginFormOP()
        {
            Storyboard storyboardOp = new Storyboard();

            DoubleAnimation OpdoubleAnimation = new DoubleAnimation();
            DoubleAnimation OpLoginAnimelo = new DoubleAnimation();

            OpLoginAnimelo.To = 1;
            OpLoginAnimelo.Duration = new TimeSpan(0, 0, 0, 1);
            OpdoubleAnimation.To = 0;
            OpdoubleAnimation.Duration = new TimeSpan(0, 0, 0, 0, 200);
            Storyboard.SetTarget(OpLoginAnimelo, LoginPass);
            Storyboard.SetTargetProperty(OpLoginAnimelo, new PropertyPath("Opacity"));
            Storyboard.SetTarget(OpdoubleAnimation, RegisterForm);
            Storyboard.SetTargetProperty(OpdoubleAnimation, new PropertyPath("Opacity"));

            storyboardOp.Children.Add(OpLoginAnimelo);
            storyboardOp.Children.Add(OpdoubleAnimation);
            storyboardOp.Begin();
            RegisterForm.Visibility = Visibility.Collapsed;
        }
        public void ResisterFormOP()
        {
            Storyboard storyboardOp = new Storyboard();

            DoubleAnimation OpdoubleAnimation = new DoubleAnimation();
            DoubleAnimation OpLoginAnimelo = new DoubleAnimation();

            OpLoginAnimelo.To = 0;
            OpLoginAnimelo.Duration = new TimeSpan(0, 0, 0, 0, 200);
            OpdoubleAnimation.To = 1;
            OpdoubleAnimation.Duration = new TimeSpan(0, 0, 0, 1);
            Storyboard.SetTarget(OpLoginAnimelo, LoginPass);
            Storyboard.SetTargetProperty(OpLoginAnimelo, new PropertyPath("Opacity"));
            Storyboard.SetTarget(OpdoubleAnimation, RegisterForm);
            Storyboard.SetTargetProperty(OpdoubleAnimation, new PropertyPath("Opacity"));

            storyboardOp.Children.Add(OpLoginAnimelo);
            storyboardOp.Children.Add(OpdoubleAnimation);
            storyboardOp.Begin();
            LoginPass.Visibility = Visibility.Collapsed;
        }
        public void RegisterButtonChangeGO()
        {
            Storyboard BackgroundST = new Storyboard();

            ColorAnimation ColorAnime = new ColorAnimation();
            ColorAnimation FontColorAnime = new ColorAnimation();
            DoubleAnimation Shadow = new DoubleAnimation();

            Shadow.To = 0;
            ColorAnime.To = Colors.White;
            FontColorAnime.To = Colors.RoyalBlue;

            Shadow.Duration = new TimeSpan(0, 0, 0, 0, 200);
            ColorAnime.Duration = new TimeSpan(0, 0, 0, 0, 200);
            FontColorAnime.Duration = new TimeSpan(0, 0, 0, 0, 200);

            Storyboard.SetTarget(FontColorAnime, RegisterText);
            Storyboard.SetTarget(ColorAnime, Register);
            Storyboard.SetTarget(Shadow, Register);

            Storyboard.SetTargetProperty(FontColorAnime, new PropertyPath("(TextBlock.Foreground).(SolidColorBrush.Color)"));
            Storyboard.SetTargetProperty(ColorAnime, new PropertyPath("(Border.Background).(SolidColorBrush.Color)"));
            Storyboard.SetTargetProperty(Shadow, new PropertyPath("(Border.Effect).Opacity"));

            BackgroundST.Children.Add(FontColorAnime);
            BackgroundST.Children.Add(ColorAnime);
            BackgroundST.Children.Add(Shadow);

            BackgroundST.Begin();
        }

        public void RegisterButtonChangeBack()
        {
            Storyboard BackgroundST = new Storyboard();

            ColorAnimation ColorAnime = new ColorAnimation();
            ColorAnimation FontColorAnime = new ColorAnimation();
            DoubleAnimation Shadow = new DoubleAnimation();

            Shadow.To = 0.4;
            ColorAnime.To = Colors.Blue; 
            FontColorAnime.To = Colors.White;

            Shadow.Duration = new TimeSpan(0, 0, 0, 0, 200);
            ColorAnime.Duration = new TimeSpan(0, 0, 0, 0, 200);
            FontColorAnime.Duration = new TimeSpan(0, 0, 0, 0, 200);

            Storyboard.SetTarget(FontColorAnime, RegisterText);
            Storyboard.SetTarget(ColorAnime, Register);
            Storyboard.SetTarget(Shadow, Register);

            Storyboard.SetTargetProperty(FontColorAnime, new PropertyPath("(TextBlock.Foreground).(SolidColorBrush.Color)"));
            Storyboard.SetTargetProperty(ColorAnime, new PropertyPath("(Border.Background).(SolidColorBrush.Color)"));
            Storyboard.SetTargetProperty(Shadow, new PropertyPath("(Border.Effect).Opacity"));

            BackgroundST.Children.Add(FontColorAnime);
            BackgroundST.Children.Add(ColorAnime);
            BackgroundST.Children.Add(Shadow);

            BackgroundST.Begin();
        }

        public void LoginButtonChangeGo()
        {
            Storyboard BackgroundST = new Storyboard();

            ColorAnimation ColorAnime = new ColorAnimation();
            ColorAnimation FontColorAnime = new ColorAnimation();
            DoubleAnimation Shadow = new DoubleAnimation();

            Shadow.To = 0;
            ColorAnime.To = Colors.White;
            FontColorAnime.To = Colors.RoyalBlue;

            Shadow.Duration = new TimeSpan(0, 0, 0, 0, 200);
            ColorAnime.Duration = new TimeSpan(0, 0, 0, 0, 200);
            FontColorAnime.Duration = new TimeSpan(0, 0, 0, 0, 200);

            Storyboard.SetTarget(FontColorAnime, ButtonLoginText);
            Storyboard.SetTarget(ColorAnime, ButtonLogin);
            Storyboard.SetTarget(Shadow, ButtonLogin);

            Storyboard.SetTargetProperty(FontColorAnime, new PropertyPath("(TextBlock.Foreground).(SolidColorBrush.Color)"));
            Storyboard.SetTargetProperty(ColorAnime, new PropertyPath("(Border.Background).(SolidColorBrush.Color)"));
            Storyboard.SetTargetProperty(Shadow, new PropertyPath("(Border.Effect).Opacity"));

            BackgroundST.Children.Add(FontColorAnime);
            BackgroundST.Children.Add(ColorAnime);
            BackgroundST.Children.Add(Shadow);

            BackgroundST.Begin();
        }
        public void LoginButtonChangeBack()
        {
            Storyboard BackgroundST = new Storyboard();

            ColorAnimation ColorAnime = new ColorAnimation();
            ColorAnimation FontColorAnime = new ColorAnimation();
            DoubleAnimation Shadow = new DoubleAnimation();

            Shadow.To = 0.4;
            ColorAnime.To = Colors.Blue;
            FontColorAnime.To = Colors.White;

            Shadow.Duration = new TimeSpan(0, 0, 0, 0, 200);
            ColorAnime.Duration = new TimeSpan(0, 0, 0, 0, 200);
            FontColorAnime.Duration = new TimeSpan(0, 0, 0, 0, 200);

            Storyboard.SetTarget(FontColorAnime, ButtonLoginText);
            Storyboard.SetTarget(ColorAnime, ButtonLogin);
            Storyboard.SetTarget(Shadow, ButtonLogin);

            Storyboard.SetTargetProperty(FontColorAnime, new PropertyPath("(TextBlock.Foreground).(SolidColorBrush.Color)"));
            Storyboard.SetTargetProperty(ColorAnime, new PropertyPath("(Border.Background).(SolidColorBrush.Color)"));
            Storyboard.SetTargetProperty(Shadow, new PropertyPath("(Border.Effect).Opacity"));

            BackgroundST.Children.Add(FontColorAnime);
            BackgroundST.Children.Add(ColorAnime);
            BackgroundST.Children.Add(Shadow);

            BackgroundST.Begin();
        }
        #endregion

        #region 右上角按钮事件
        private void CloseButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Storyboard Change = new Storyboard();

            ColorAnimation ColorChange = new ColorAnimation();
            ColorChange.To = Colors.LightBlue;
            ColorChange.Duration = new TimeSpan(0, 0, 0, 0,100);

            Storyboard.SetTarget(ColorChange, LineOne);
            Storyboard.SetTargetProperty(ColorChange, new PropertyPath("(Line.Stroke).(SolidColorBrush.Color)"));
            Change.Children.Add(ColorChange);
         
            ColorAnimation ColorChangeElse = new ColorAnimation();
            ColorChangeElse.To = Colors.LightBlue;
            ColorChangeElse.Duration = new TimeSpan(0, 0, 0, 0,100);

            Storyboard.SetTarget(ColorChangeElse, LineTwo);
            Storyboard.SetTargetProperty(ColorChangeElse, new PropertyPath("(Line.Stroke).(SolidColorBrush.Color)"));
            Change.Children.Add(ColorChangeElse);

            Change.Begin();
        }

        private void CloseButton_MouseLeave(object sender, MouseEventArgs e)
        {
            Storyboard BackChange = new Storyboard();

            ColorAnimation ColorChangeBack = new ColorAnimation();
            ColorChangeBack.To = Colors.Black;
            ColorChangeBack.Duration = new TimeSpan(0, 0, 0, 0,100);

            Storyboard.SetTarget(ColorChangeBack, LineOne);
            Storyboard.SetTargetProperty(ColorChangeBack, new PropertyPath("(Line.Stroke).(SolidColorBrush.Color)"));
            BackChange.Children.Add(ColorChangeBack);

            ColorAnimation ColorChangeBackElse = new ColorAnimation();
            ColorChangeBackElse.To = Colors.Black;
            ColorChangeBackElse.Duration = new TimeSpan(0, 0, 0, 0,100);

            Storyboard.SetTarget(ColorChangeBackElse, LineTwo);
            Storyboard.SetTargetProperty(ColorChangeBackElse, new PropertyPath("(Line.Stroke).(SolidColorBrush.Color)"));
            BackChange.Children.Add(ColorChangeBackElse);

            BackChange.Begin();
        }

        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e)
        {            
            Environment.Exit(0);
        }

        private void MiniMize_MouseEnter(object sender, MouseEventArgs e)
        {
            Storyboard Change = new Storyboard();

            ColorAnimation ColorChange = new ColorAnimation();
            ColorChange.To = Colors.LightBlue;
            ColorChange.Duration = new TimeSpan(0, 0, 0, 0, 100);

            Storyboard.SetTarget(ColorChange, LineMini);
            Storyboard.SetTargetProperty(ColorChange, new PropertyPath("(Line.Stroke).(SolidColorBrush.Color)"));
            Change.Children.Add(ColorChange);

            Change.Begin();
        }

        private void MiniMize_MouseLeave(object sender, MouseEventArgs e)
        {
            Storyboard BackChange = new Storyboard();

            ColorAnimation ColorChangeBack = new ColorAnimation();
            ColorChangeBack.To = Colors.Black;
            ColorChangeBack.Duration = new TimeSpan(0, 0, 0, 0, 100);

            Storyboard.SetTarget(ColorChangeBack, LineMini);
            Storyboard.SetTargetProperty(ColorChangeBack, new PropertyPath("(Line.Stroke).(SolidColorBrush.Color)"));
            BackChange.Children.Add(ColorChangeBack);

            BackChange.Begin();
        }

        private void MiniMize_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        #endregion

        #region 用户登录 注册 获取验证码

        public void Codetimer_Tick(object sender, EventArgs e)
        {
            CodeMini--;
            CodeButton.Content = DataTemp.PhoneCheckCode + " (" + CodeMini + "s)";
            if (CodeMini <= 0)
            {
                CodeMini = 60;
                Codetimer.Stop();
                CodeButton.Content = "请重新获取验证码";
                DataTemp.PhoneCheckCode = 0;
            }
            
        }

        private void CodeButton_Click(object sender, RoutedEventArgs e)
        {
            DataTemp.PhoneCheckCode = Service.CheckPhone(PhoneNum.Text);
            if (DataTemp.PhoneCheckCode == 0)
            {
                WarningTips("验证码获取失败");
            }
            else
            {
                Codetimer.Interval = TimeSpan.FromSeconds(1);
                Codetimer.Tick += Codetimer_Tick;
                Codetimer.Start();
                CodeButton.Content = DataTemp.PhoneCheckCode + " (" + CodeMini + "s)";
            }
        }

        private void LoginInButton_Click(object sender, RoutedEventArgs e)
        {
            Service service = new Service();
            int Result = service.SecurityCheck(UserTextBox.Text, PassTextBox.Text);
            switch (Result)
            {
                case 0:
                    Warning warning = new Warning();
                    DataTemp.WarningTips = "请输入正确的用户名或密码";
                    WarningText.Text = DataTemp.WarningTips;
                    OnAnime();
                    break;
                case 1:
                    break;
                    this.Hide();
                    Tenant tenant = new Tenant(UserTextBox.Text);
                    tenant.Show();
                    break;
                case 2:
                    this.Hide();
                    Master master = new Master(UserTextBox.Text);
                    master.Show();
                    break;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonFalg == 1)
            {
                LoginButtonChangeGo();
                RegisterButtonChangeBack();
                LoginFormOP();
                //Eliminate();

                ButtonFalg = 0;
            }
        }

        private void RegisitrationButton_Click(object sender, RoutedEventArgs e)
        {

            if (NewUserName.Text == "请输入新的用户名" || NewUserPassWork.Text == "请输入新的密码" || CheckPasswork.Text == "请输入确认密码" || PhoneNum.Text == "请输入手机号" || PhoneCode.Text == "输入验证码")
            {
                WarningTips("请正确填写信息");
                return;
            }
            if (DataTemp.Gender == "")
            {
                DataTemp.WarningTips = "请选择性别";
                WarningText.Text = DataTemp.WarningTips;
                OnAnime();
                return;
            }
            if (DataTemp.PhoneCheckCode == 0)
            {
                WarningTips("请获取验证码");
            }
            else
            {
                DataTemp.Passage = Service.RegisterSucceeded(NewUserName.Text, NewUserPassWork.Text, CheckPasswork.Text, PhoneNum.Text, Convert.ToInt32(PhoneCode.Text), DataTemp.Gender);
            }
            switch (DataTemp.Passage)
            {
                case 0:
                    WarningTips("注册失败, 请稍后重试");
                    break;
                case 1:
                    Tenant tenant = new Tenant(NewUserName.Text);
                    this.Hide();
                    tenant.Show();
                    break;
                case 4:
                case 2:
                    WarningTips("用户名不可以有特殊字符");
                    break;
                case 5:
                case 3:
                    WarningTips("密码不可以有特殊字符");
                    break;
                case 6:
                    WarningTips("手机号不正确");
                    break;
                case 7:
                    WarningTips("请填写完整信息");
                    break;
                case 8:
                    WarningTips("密码和确认密码不一致");
                    break;
                case 9:
                    WarningTips("验证码错误");
                    break;
                case 10:
                    WarningTips("用户名已存在");
                    break;
                case 11:
                    WarningTips("用户名不得少于2个字符或大于14个字符");
                    break;
            }
        }
        #endregion


        #endregion

        
        #region 警告框
        public void CloseAnime()
        {
            Storyboard storyboard = new Storyboard();

            DoubleAnimation OpDoubleAnime = new DoubleAnimation();

            OpDoubleAnime.From = 1;
            OpDoubleAnime.To = 0;
            OpDoubleAnime.Duration = new TimeSpan(0, 0, 0, 0, 600);

            Storyboard.SetTarget(OpDoubleAnime, Ppbox);
            Storyboard.SetTargetProperty(OpDoubleAnime, new PropertyPath("Opacity"));

            storyboard.Children.Add(OpDoubleAnime);

            storyboard.Begin();
        }
        public void OnAnime()
        {
            Storyboard storyboard = new Storyboard();

            DoubleAnimation OpDoubleAnime = new DoubleAnimation();

            OpDoubleAnime.From = 0;
            OpDoubleAnime.To = 1;
            OpDoubleAnime.Duration = new TimeSpan(0, 0, 0, 0, 200);

            Storyboard.SetTarget(OpDoubleAnime, Ppbox);
            Storyboard.SetTargetProperty(OpDoubleAnime, new PropertyPath("Opacity"));

            storyboard.Children.Add(OpDoubleAnime);

            storyboard.Begin();

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            mini++;
            if (mini == 3)
            {
                timer.Stop();
                mini = 0;
                CloseAnime();
            }
        }

        public void WarningTips(string str)
        {
            Warning warning = new Warning();
            DataTemp.WarningTips = str;
            WarningText.Text = DataTemp.WarningTips;
            OnAnime();
        }
        #endregion



        //清理数据
        public void Eliminate()
        {
            NewUserName.Text = "";
            NewUserPassWork.Text = "";
            PhoneNum.Text = "";
            PhoneCode.Text = "";
        }

        private void UserTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Service service = new Service();
            MainTopImgLoad(service.URIPath(UserTextBox.Text));
        }

        
    }
}
