using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;
using Login = ResumeBuilder.SignUpForm.Login;

namespace ResumeBuilder
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        public string ReadFile()
        {
            string templateType;
            try
            {
                templateType = File.ReadAllText("window.txt");
                return templateType;
            }
            catch
            {
                return null;
            }
        }
        private void FindWindow()
        {

            if (ReadFile() == "ResumeTemplate")
            {
                Hide();
                ResumeTemplate resumeTemplate = new ResumeTemplate();
                resumeTemplate.Show();
            }
            else if (ReadFile() == "WindowStep1")
            {
                Hide();
                WindowStep1 windowStep1 = new WindowStep1();
                windowStep1.Show();
            }
            else if (ReadFile() == "WindowStep2")
            {
                Hide();
                WindowStep2 windowStep2 = new WindowStep2();
                windowStep2.Show();
            }
            else if (ReadFile() == "WindowStep3")
            {
                Hide();
                WindowStep3 windowStep3 = new WindowStep3();
                windowStep3.Show();
            }
            else if (ReadFile() == "FileConvert")
            {
                Hide();
                FileConvert fileConvert = new FileConvert();
                fileConvert.Show();
            }
            else
            {
                Hide();
                MainWindow mainWindow = new MainWindow();
                mainWindow.ShowDialog();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                XmlSerializer xmlWriter = new XmlSerializer(typeof(Login));
                FileStream reader = File.Open("login.xml", FileMode.Open);
                Login getLogin = (Login)xmlWriter.Deserialize(reader);
                reader.Close();
                string _email;
                string _password;
                _password = password.Password;
                _email = email.Text;
                if (_email == getLogin._Email && _password == getLogin._Password)
                {
                    try
                    {
                        FindWindow();
                    }
                    catch
                    {
                        Hide();
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.ShowDialog();
                    }
                }
                else
                {
                    invalid.Text = "Invalid email or password";
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        private void password_GotFocus(object sender, RoutedEventArgs e)
        {
            invalid.Text = string.Empty;
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            SignUpForm signUp = new SignUpForm();
            signUp.ShowDialog();
        }

        private void email_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
