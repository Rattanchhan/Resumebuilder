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
using System.Xml.Serialization;

namespace ResumeBuilder
{
    /// <summary>
    /// Interaction logic for SignUpForm.xaml
    /// </summary>
    public partial class SignUpForm : Window
    {
        public SignUpForm()
        {
            InitializeComponent();
        }
        public class Login
        {
            public string _Email { get; set; } = string.Empty;
            public string _Password { get; set; } = string.Empty;
            public string _ConfirmPassword { get; set; } = string.Empty;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Email.Text != null)
            {
                if (password.Password == ConfirmPassword.Password)
                {
                    Login login = new Login()
                    {
                        _Email = Email.Text,
                        _Password = password.Password,
                        _ConfirmPassword = ConfirmPassword.Password
                    };
                    try
                    {
                        XmlSerializer xmlWriter = new XmlSerializer(typeof(Login));
                        using (FileStream writer = File.Open("login.xml", FileMode.Create))
                        {
                            xmlWriter.Serialize(writer, login);
                            writer.Close();
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\tFile can't open");
                    }

                }
                Close();
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
            }
        }
    }
}
