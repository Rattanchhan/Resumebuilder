using System;
using System.Collections.Generic;
using System.IO;
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

namespace ResumeBuilder
{
    /// <summary>
    /// Interaction logic for WindowStep1.xaml
    /// </summary>
    public partial class WindowStep1 : Window
    {
        public WindowStep1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowStep2 windowStep2 = new WindowStep2();
            windowStep2.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
            ResumeTemplate pauseTemplate = new ResumeTemplate();
            pauseTemplate.Show();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Close();
            WindowStep2 windowStep2 = new WindowStep2();
            windowStep2.Show();

        }

        private void backButton_MouseMove(object sender, MouseEventArgs e)
        {
            Color get = Color.FromRgb(26, 145, 240);
            backButton.BorderBrush = new SolidColorBrush(get);
            backButton.Foreground = new SolidColorBrush(get);
        }

        private void backButton_MouseLeave(object sender, MouseEventArgs e)
        {
            Color get = Color.FromRgb(0, 0, 0);
            backButton.BorderBrush = new SolidColorBrush(get);
            backButton.Foreground = new SolidColorBrush(get);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("window.txt", "WindowStep1");
        }
    }
}
