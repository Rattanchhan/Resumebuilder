using Microsoft.Win32;
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
using System.Xml.Serialization;

namespace ResumeBuilder
{
    /// <summary>
    /// Interaction logic for WindowStep2.xaml
    /// </summary>
    public partial class WindowStep2 : Window
    {
        public class PersonalInformation : INotifyPropertyChanged
        {
            public string firstName = string.Empty;
            public string FirstName
            {
                get
                {
                    return firstName;
                }
                set
                {
                    firstName = value;
                    InitializeProperty("firstName");
                }
            }
            public string lastName = string.Empty;
            public string LastName
            {
                get
                {
                    return lastName;
                }
                set
                {
                    lastName = value;
                    InitializeProperty("lastName");
                }
            }
            public string adddress = string.Empty;
            public string Address
            {
                get
                {
                    return adddress;
                }
                set
                {
                    adddress = value;
                    InitializeProperty("address");
                }
            }
            public void InitializeProperty(string name)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
            public string city = string.Empty;
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
            public string province = string.Empty;
            public string Province
            {
                get
                {
                    return province;
                }
                set
                {
                    province = value;
                    InitializeProperty("province");
                }
            }
            public string zipCode = string.Empty;
            public string ZipCode
            {
                get
                {
                    return zipCode;
                }
                set
                {
                    zipCode = value;
                    InitializeProperty("zipCode");
                }
            }
            public string emailAddress = string.Empty;
            public string EmailAddress
            {
                get
                {
                    return emailAddress;
                }
                set
                {
                    emailAddress = value;
                    InitializeProperty("emailAddress");
                }
            }
            public string phoneNumber = string.Empty;
            public string PhoneNumber
            {
                get
                {
                    return phoneNumber;
                }
                set
                {
                    phoneNumber = value;
                    InitializeProperty("phoneNumber");
                }
            }
            public string image = string.Empty;

            public event PropertyChangedEventHandler PropertyChanged;

            public string Image
            {
                get
                {
                    return image;
                }
                set
                {
                    image = value;
                    InitializeProperty("image");
                }
            }

        }
        public PersonalInformation personalInformation = new PersonalInformation();
        public WindowStep2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == true)
            {
                string selectedFileName = dlg.FileName;
                personalInformation.Image = selectedFileName;
                FillImage(personalInformation.Image);
            }
        }

        public void FillImage(string fileName)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(fileName);
            bitmap.EndInit();
            CoverImage.Source = bitmap;
        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            WindowStep1 windowStep1 = new WindowStep1();
            windowStep1.Show();
        }

        private void OpenFile()
        {
            try
            {
                XmlSerializer xmlWriter = new XmlSerializer(typeof(PersonalInformation));
                FileStream reader = File.Open("personalInformation.xml", FileMode.Open);
                personalInformation = (PersonalInformation)xmlWriter.Deserialize(reader);
                reader.Close();
                FillImage(personalInformation.Image);
            }
            catch
            {
                personalInformation = new PersonalInformation();
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                XmlSerializer xmlWriter = new XmlSerializer(typeof(PersonalInformation));
                using (FileStream writer = File.Open("personalInformation.xml", FileMode.Create))
                {
                    xmlWriter.Serialize(writer, personalInformation);
                    writer.Close();
                }
            }
            catch (Exception)
            {
            }
            Close();
            WindowStep3 windowStep3 = new WindowStep3();
            windowStep3.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OpenFile();
            DataContext = personalInformation;
            File.WriteAllText("window.txt", "WindowStep2");
        }
    }
}
