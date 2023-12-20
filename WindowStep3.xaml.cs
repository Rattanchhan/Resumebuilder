using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using static ResumeBuilder.WindowStep2;
using System.Xml.Serialization;

namespace ResumeBuilder
{
    /// <summary>
    /// Interaction logic for WindowStep3.xaml
    /// </summary>
    public partial class WindowStep3 : Window
    {
        public Experience experience = new Experience();
        public class Experience : INotifyPropertyChanged
        {
            public string employee;
            public string Employee
            {
                get
                {
                    return employee;
                }
                set
                {
                    employee = value;
                    InitializeProperty("employee");
                }
            }
            public string jobTitle;
            public string JobTitle
            {
                get
                {
                    return jobTitle;
                }
                set
                {
                    jobTitle = value;
                    InitializeProperty("jobTitle");
                }
            }
            public void InitializeProperty(string name)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
            public string city;
            public string City
            {
                get
                {
                    return city;
                }
                set
                {
                    city = value;
                    InitializeProperty("city");
                }
            }
            public string state;
            public string State
            {
                get
                {
                    return state;
                }
                set
                {
                    state = value;
                    InitializeProperty("state");
                }
            }
            public string startDateMonth;
            public string StartDateMonth
            {
                get
                {
                    return startDateMonth;
                }
                set
                {
                    startDateMonth = value;
                    InitializeProperty("startDateMonth");
                }
            }
            public string startDateYear;
            public string StartDateYear
            {
                get
                {
                    return startDateYear;
                }
                set
                {
                    startDateYear = value;
                    InitializeProperty("startDateYear");
                }
            }
            public string endDateMonth;
            public string EndDateMonth
            {
                get
                {
                    return endDateMonth;
                }
                set
                {
                    endDateMonth = value;
                    InitializeProperty("endDateMonth");
                }
            }
            public string endDateYear;
            public string EndDateYear
            {
                get
                {
                    return endDateYear;
                }
                set
                {
                    endDateYear = value;
                    InitializeProperty("endDateYear");
                }
            }
            public string jobDescription;
            public string JobDescription
            {
                get
                {
                    return jobDescription;
                }
                set
                {
                    jobDescription = value;
                    InitializeProperty("jobDescription");
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
        }
        public WindowStep3()
        {
            InitializeComponent();
        }

        public PersonalInformation getPersonalInformation;
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            WindowStep2 windowStep2 = new WindowStep2();
            windowStep2.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                XmlSerializer xmlWriter = new XmlSerializer(typeof(Experience));
                using (FileStream writer = File.Open("experience.xml", FileMode.Create))
                {
                    xmlWriter.Serialize(writer, experience);
                    writer.Close();
                    Close();
                    FileConvert fileConvert = new FileConvert();
                    fileConvert.Show();
                }
            }
            catch (Exception)
            {
            }
        }
        private void OpenFile()
        {
            try
            {
                XmlSerializer xmlWriter = new XmlSerializer(typeof(Experience));
                FileStream reader = File.Open("experience.xml", FileMode.Open);
                experience = (Experience)xmlWriter.Deserialize(reader);
                reader.Close();
            }
            catch
            {
                experience = new Experience();
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OpenFile();
            DataContext = experience;
            File.WriteAllText("window.txt", "WindowStep3");
        }
    }
}
