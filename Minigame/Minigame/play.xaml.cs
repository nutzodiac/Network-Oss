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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Minigame
{
    /// <summary>
    /// Interaction logic for play.xaml
    /// </summary>
    public partial class play : Page
    {
        public play()
        {
           
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(DispatchTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timer.Start();


            DispatcherTimer timerbot = new DispatcherTimer();
            timerbot.Tick += new EventHandler(DispatchTickBot);
            timerbot.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timerbot.Start();

        }

        Boolean click = false;

         int statusbot = 1;
        private void DispatchTickBot(object sender, EventArgs e)
        {
            if (statusbot == 1) {
                bot.Source = new BitmapImage(new Uri(@"\res\bot2.png", UriKind.Relative));
                statusbot = 2;
            
            }
            else if (statusbot == 2)
            {
                bot.Source = new BitmapImage(new Uri(@"\res\bot3.png", UriKind.Relative));
                statusbot = 3;

            }
            else if (statusbot == 3)
            {
                bot.Source = new BitmapImage(new Uri(@"\res\bot4.png", UriKind.Relative));
               statusbot = 4;

            }
            else if (statusbot == 4)
            {
                bot.Source = new BitmapImage(new Uri(@"\res\bot1.png", UriKind.Relative));
                statusbot = 1;

            }
            //ส่วนระยะทำให้เลือดลด
            Double d = Math.Sqrt(Math.Pow(Canvas.GetTop(bot) - Canvas.GetTop(player), 2) + Math.Pow(Canvas.GetLeft(bot) - Canvas.GetLeft(player), 2));
            //debugtext.Content = d;
            if (d < 65)
            {
                progressbarbot.Value = progressbarbot.Value - 15;
            }
           
            
            //BOT FUNCTION

            Random rnd = new Random();
            if(rnd.Next (10)>=8 && Canvas .GetLeft(bot)<= 650)
            {
            
            Canvas .SetLeft (bot,Canvas .GetLeft(bot) +30);
            }else if(Canvas .GetLeft (bot) >= Canvas .GetLeft (player)) {
            
            Canvas .SetLeft (bot,Canvas .GetLeft(bot) -100);
            }
        
        }
    
                  
      int status = 1;

        private void DispatchTick(object sender, EventArgs e)
        {

            //ยืนนิ่งๆไม่ตี
            if (status == 1) {
                player.Source = new BitmapImage(new Uri(@"\res\2.png", UriKind.Relative));
                status = 2;
            
            }
            else if (status == 2)
            {
                player.Source = new BitmapImage(new Uri(@"\res\3.png", UriKind.Relative));
                status = 3;

            }
            else if (status == 3)
            {
                player.Source = new BitmapImage(new Uri(@"\res\4.png", UriKind.Relative));
                status = 4;

            }
            else if (status == 4)
            {
                player.Source = new BitmapImage(new Uri(@"\res\1.png", UriKind.Relative));
                status = 1;

            }

            Double d = Math.Sqrt(Math.Pow(Canvas.GetTop(bot) - Canvas.GetTop(player), 2) + Math.Pow(Canvas.GetLeft(bot) - Canvas.GetLeft(player), 2));
           // debugtext.Content = d;
            if (d < 65)
            {
                progressbarplayer.Value = progressbarplayer.Value - 15;
            }
           
            
            //BOT FUNCTION

            Random rnd = new Random();
            if(rnd.Next (10)>=8 && Canvas .GetLeft(player)<= 650 && Canvas .GetLeft (bot)>=Canvas.GetLeft (player ))
            {
            
            Canvas .SetLeft (player,Canvas .GetLeft(player) +100);
            }else if(Canvas .GetLeft (player) >= Canvas .GetLeft (bot) && (Canvas .GetLeft (player )>=0)) {
            
            Canvas .SetLeft (player,Canvas .GetLeft(player) -30);
            }
            
        }
     
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            click = true;
        }


 


        }


    }

