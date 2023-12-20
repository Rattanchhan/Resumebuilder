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
    /// Interaction logic for ResumeTemplate.xaml
    /// </summary>
    public partial class ResumeTemplate : Window
    {
        public string typeOfTemplate;
        public ResumeTemplate()
        {
            InitializeComponent();
        }
        private void RemoveAllButton()
        {
            grid1.Children.Remove(button1);
            grid2.Children.Remove(button2);
            grid3.Children.Remove(button3);
            grid4.Children.Remove(button4);
            grid5.Children.Remove(button5);
            grid6.Children.Remove(button6);
        }
        private void RemoveLastFiveButton(Button button1, Button button2, Button button3, Button button4, Button button5,
            Grid grid1, Grid grid2, Grid grid3, Grid grid4, Grid grid5)
        {
            grid1.Children.Remove(button1);
            grid2.Children.Remove(button2);
            grid3.Children.Remove(button3);
            grid4.Children.Remove(button4);
            grid5.Children.Remove(button5);
        }
        public void GetButton(Button button)
        {
            Thickness thickness = new Thickness(0);
            Color get = Color.FromRgb(26, 145, 240);
            button.Foreground = Brushes.White;
            button.BorderThickness = thickness;
            button.Background = new SolidColorBrush(get);
            button.Content = "Use This Template";
            button.Width = 150;
            button.Height = 42;
            button.FontSize = 14;
            button.HorizontalAlignment = HorizontalAlignment.Center;
        }
        private void Image_MouseMove_1(object sender, MouseEventArgs e)
        {
            try
            {
                GetButton(button1);
                grid1.Children.Add(button1);
                RemoveLastFiveButton(button2, button3, button4, button5, button6, grid2, grid3, grid4, grid5, grid6);
            }
            catch
            {
                RemoveLastFiveButton(button2, button3, button4, button5, button6, grid2, grid3, grid4, grid5, grid6);
            }

        }
        private void Image_MouseMove_4(object sender, MouseEventArgs e)
        {
            try
            {
                GetButton(button2);
                grid2.Children.Add(button2);
                RemoveLastFiveButton(button1, button3, button4, button5, button6, grid1, grid3, grid4, grid5, grid6);
            }
            catch
            {
                RemoveLastFiveButton(button1, button3, button4, button5, button6, grid1, grid3, grid4, grid5, grid6);
            }

        }
        private void Image_MouseMove_5(object sender, MouseEventArgs e)
        {
            try
            {
                GetButton(button3);
                grid3.Children.Add(button3);
                RemoveLastFiveButton(button1, button2, button4, button5, button6, grid1, grid2, grid4, grid5, grid6);
            }
            catch
            {
                RemoveLastFiveButton(button1, button2, button4, button5, button6, grid1, grid2, grid4, grid5, grid6);
            }
        }
        private void ListBox_MouseLeave(object sender, MouseEventArgs e)
        {
            RemoveAllButton();
        }
        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                GetButton(button4);
                grid4.Children.Add(button4);
                RemoveLastFiveButton(button1, button2, button3, button5, button6, grid1, grid2, grid3, grid5, grid6);
            }
            catch
            {
                RemoveLastFiveButton(button1, button2, button3, button5, button6, grid1, grid2, grid3, grid5, grid6);
            }
        }
        private void Image_MouseMove_2(object sender, MouseEventArgs e)
        {
            try
            {
                GetButton(button5);
                grid5.Children.Add(button5);
                RemoveLastFiveButton(button1, button2, button3, button4, button6, grid1, grid2, grid3, grid4, grid6);
            }
            catch
            {
                RemoveLastFiveButton(button1, button2, button3, button4, button6, grid1, grid2, grid3, grid4, grid6);
            }
        }
        private void Image_MouseMove_3(object sender, MouseEventArgs e)
        {
            try
            {
                GetButton(button6);
                grid6.Children.Add(button6);
                RemoveLastFiveButton(button1, button2, button3, button4, button5, grid1, grid2, grid3, grid4, grid5);
            }
            catch
            {
                RemoveLastFiveButton(button1, button2, button3, button4, button5, grid1, grid2, grid3, grid4, grid5);
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RemoveAllButton();

            File.Delete("personalInformation.xml");
            File.Delete("experience.xml");
            File.Delete("typeOfTemplate");

            File.WriteAllText("window.txt", "ResumeTemplate");
        }

        public void writeFile(string str)
        {
            File.WriteAllText("typeOfTemplate.txt", str);
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            typeOfTemplate = "template1";
            writeFile(typeOfTemplate);
            WindowStep1 windowStep1 = new WindowStep1();
            windowStep1.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            typeOfTemplate = "template2";
            writeFile(typeOfTemplate);
            WindowStep1 windowStep1 = new WindowStep1();
            windowStep1.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            typeOfTemplate = "template3";
            writeFile(typeOfTemplate);
            WindowStep1 windowStep1 = new WindowStep1();
            windowStep1.Show();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            typeOfTemplate = "template4";
            writeFile(typeOfTemplate);
            WindowStep1 windowStep1 = new WindowStep1();
            windowStep1.Show();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            typeOfTemplate = "template5";
            writeFile(typeOfTemplate);
            WindowStep1 windowStep1 = new WindowStep1();
            windowStep1.Show();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            typeOfTemplate = "template6";
            writeFile(typeOfTemplate);
            WindowStep1 windowStep1 = new WindowStep1();
            windowStep1.Show();
        }
    }
}
