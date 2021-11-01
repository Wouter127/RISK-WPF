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
using System.Windows.Shapes;

namespace RISK.View
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        private MediaPlayer mediaplayer = new MediaPlayer();
        public SplashScreen()
        {
            InitializeComponent();
            mediaplayer.Open(new Uri(string.Format("{0}\\Miguel Johnson - Good Day To Die.mp3", AppDomain.CurrentDomain.BaseDirectory)));

            mediaplayer.Play();
        }
    }
}
