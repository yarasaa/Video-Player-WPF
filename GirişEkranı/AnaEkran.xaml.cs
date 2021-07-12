using Microsoft.Win32;
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
using System.Windows.Forms;
using System.Windows.Threading;
using Application = System.Windows.Application;

namespace GirişEkranı
{
    /// <summary>
    /// Interaction logic for AnaEkran.xaml
    /// </summary>
    #region Constructor
    public partial class AnaEkran : Window
    {
        
        DispatcherTimer timer;
        public AnaEkran()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(200);
            timer.Tick +=new
                EventHandler (timer_Tick);
        }

        #endregion
        bool isDragging = false;
        private void timer_Tick(object sender, EventArgs e)
        {
            if (!isDragging)
            {
                MediaSlider.Value = Media.Position.TotalSeconds;
            }
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
            

        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

           
          
        }

        

       

        private void btnFileMenu_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Media.Source = new Uri(dlg.FileName);
            }
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            Media.Play();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            Media.Pause();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            Media.Stop();
        }

        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Media.Volume =(double) VolumeSlider.Value;
        }

        private void MediaSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Media.Position = TimeSpan.FromSeconds(MediaSlider.Value);
        }

        private void Media_MediaOpened(object sender, RoutedEventArgs e)
        {
            if (Media.NaturalDuration.HasTimeSpan)
            {

            
            TimeSpan ts = Media.NaturalDuration.TimeSpan;
            MediaSlider.Maximum = ts.TotalSeconds;
            MediaSlider.SmallChange = 1;
            MediaSlider.LargeChange = Math.Min(10, ts.Seconds / 10);
        }
            timer.Start();
        }
        
        

        private void MediaSlider_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            isDragging = true;
        }

        private void MediaSlider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            isDragging = false;
            Media.Position = TimeSpan.FromSeconds(MediaSlider.Value);
        }

        private void Media_Loaded(object sender, RoutedEventArgs e)
        {
            Media.LoadedBehavior = MediaState.Manual;
            Media.ScrubbingEnabled = true;
            Media.Pause();
            Media.Position = TimeSpan.FromTicks(1);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
