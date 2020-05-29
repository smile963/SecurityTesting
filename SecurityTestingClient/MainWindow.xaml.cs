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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SecurityTestingClient.ServiceReference1;

namespace SecurityTestingClient
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] show = { 0, 0, 0, 0 };
        int[] hidden = { 0, 0, 0, 0 };
        public MainWindow()
        {
            InitializeComponent();
            Gang.Visibility = Visibility.Collapsed;
            Show_me_The_Truth.Visibility = Visibility.Collapsed;
        }
        

        //Guide

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;

            Main.OpacityMask = this.Resources["ClosedBrush"] as LinearGradientBrush;//控制淡化
            Storyboard std = this.Resources["ClosedStoryboard"] as Storyboard;
            std.Completed += delegate { this.Close(); };

            std.Begin();//启动淡出
        }

        private void Ttn_Click(object sender, RoutedEventArgs e)
        {
            Guide.Visibility = Visibility.Collapsed;
            Show_me_The_Truth.Visibility = Visibility.Visible;

        }

        private void Ttn_MouseEnter(object sender, MouseEventArgs e)
        {
            Show_F(DECIPHER, 0.5, "Y", 0, -20, show[0], hidden[0]);


        }

        private void Ttn_MouseLeave(object sender, MouseEventArgs e)
        {
            Hidden_F(DECIPHER, 0.5, "Y", -20, 0, show[0], hidden[0]);

        }

        private void Btn_MouseEnter(object sender, MouseEventArgs e)
        {
            Show_F(QUIT_One, 0.5, "X", 0, 60, show[0], hidden[0]);
            Gang.Visibility = Visibility.Visible;

        }

        private void Quit_MouseLeave(object sender, MouseEventArgs e)
        {
            Hidden_F(QUIT_One, 0.5, "X", 60, 0, show[0], hidden[0]);
            Gang.Visibility = Visibility.Collapsed;

        }


        //Decipher

        private void BACK_B_Click(object sender, RoutedEventArgs e)
        {
            Gang.Visibility = Visibility.Collapsed;
            Show_me_The_Truth.Visibility = Visibility.Collapsed;
            Guide.Visibility = Visibility.Visible;
        }

        private void QUIT_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;

            Main.OpacityMask = this.Resources["ClosedBrush"] as LinearGradientBrush;//控制淡化
            Storyboard std = this.Resources["ClosedStoryboard"] as Storyboard;
            std.Completed += delegate { this.Close(); };

            std.Begin();//启动淡出
        }

        //客户端代理类
        Service1Client client = new Service1Client();
        /*
         * 传出：将防伪码提交的服务端
         * 传入：产品的相关信息，创建StringBuilder对象接受传回来的对象，然后输出到检测界面
         * 参考界面显示.PNG的文件样式创建个性的界面。
             
             */

        /// <summary>
        /// 
        /// </summary>
        /// <param name="HASH"></param>
        /// <param name="Yahaha"></param>
        private void Ddn_Click(object sender, RoutedEventArgs e)
        {
            string securityCode = Input.Text.ToString();
            //创建StringBuilder对象接收结果
            //输出现在更名为“Output”

            if (GetTextBoxLength(Input.Text) < 46)//判断长度
            {
                Animation();
            }
            StringBuilder sb = new StringBuilder();
            sb = client.Detection(securityCode);
            Output.Content = sb.ToString();

        }

        private void Ddn_MouseEnter(object sender, MouseEventArgs e)
        {
            Show_F(DECIPHER_Two, 0.5, "Y", 0, 20, show[0], hidden[0]);
        }

        private void Ddn_MouseLeave(object sender, MouseEventArgs e)
        {
            Hidden_F(DECIPHER_Two, 0.5, "Y", 20, 0, show[0], hidden[0]);
        }


        //Others

        public void DragWindow(object sender, MouseButtonEventArgs args)
        {
            this.DragMove();
        }

        public void Animation()
        {
            Show_F(The_pole, 0.5, "X", 0, 105, show[1], hidden[1]);

            Show_F(The_flag, 1, "Y", 0, 160, show[2], hidden[2]);

            Show_F(Tips, 1, "Y", 0, 160, show[3], hidden[3]);


        }

        public static int GetTextBoxLength(string textboxTextStr)
        {
            int nLength = 0;
            for (int i = 0; i < textboxTextStr.Length; i++)
            {
                if (textboxTextStr[i] >= 0x3000 && textboxTextStr[i] <= 0x9FFF)
                    nLength += 2;
                else
                    nLength++;
            }
            return nLength;
        }

        public void Show_F(UIElement LA, double time, string dive, int Dive_Number_First, int Dive_Number_End, int Trigger_One, int Trigger_Two)
        {
            for (; Trigger_One < 1; Trigger_One++)
            {

                TranslateTransform tt = new TranslateTransform();
                //创建一个一个对象，对两个值在时间线上进行动画处理（移动距离，移动到的位置）
                DoubleAnimation da = new DoubleAnimation();
                //设定动画时间线
                Duration duration = new Duration(TimeSpan.FromSeconds(time));
                //Quit要进行动画操作的控件名
                LA.RenderTransform = tt;
                if (dive == "X")
                {
                    //开始动画控件的初始位置，一般控件所在的位置是0位置
                    tt.X = Dive_Number_First;
                    //设定移动动画的结束值，控件向下移动60个像素，向上移动则是-60
                    da.To = Dive_Number_End;
                    da.Duration = duration;
                    //开始进行动画处理
                    tt.BeginAnimation(TranslateTransform.XProperty, da);
                }
                else if (dive == "Y")
                {
                    //开始动画控件的初始位置，一般控件所在的位置是0位置
                    tt.Y = Dive_Number_First;
                    //设定移动动画的结束值，控件向下移动60个像素，向上移动则是-60
                    da.To = Dive_Number_End;
                    da.Duration = duration;
                    //开始进行动画处理
                    tt.BeginAnimation(TranslateTransform.YProperty, da);
                }

            }
            Trigger_Two = 0;
        }

        public void Hidden_F(UIElement LA, double time, string dive, int Dive_Number_First, int Dive_Number_End, int Trigger_One, int Trigger_Two)
        {
            for (; Trigger_Two < 1; Trigger_Two++)
            {

                TranslateTransform tt = new TranslateTransform();
                //创建一个一个对象，对两个值在时间线上进行动画处理（移动距离，移动到的位置）
                DoubleAnimation da = new DoubleAnimation();
                //设定动画时间线
                Duration duration = new Duration(TimeSpan.FromSeconds(time));
                //Quit要进行动画操作的控件名
                LA.RenderTransform = tt;
                if (dive == "X")
                {
                    //开始动画控件的初始位置，一般控件所在的位置是0位置
                    tt.X = Dive_Number_First;
                    //设定移动动画的结束值，控件向下移动60个像素，向上移动则是-60
                    da.To = Dive_Number_End;
                    da.Duration = duration;
                    //开始进行动画处理
                    tt.BeginAnimation(TranslateTransform.XProperty, da);
                }
                else if (dive == "Y")
                {
                    //开始动画控件的初始位置，一般控件所在的位置是0位置
                    tt.Y = Dive_Number_First;
                    //设定移动动画的结束值，控件向下移动60个像素，向上移动则是-60
                    da.To = Dive_Number_End;
                    da.Duration = duration;
                    //开始进行动画处理
                    tt.BeginAnimation(TranslateTransform.YProperty, da);
                }

            }
            Trigger_One = 0;
        }


    }
}
