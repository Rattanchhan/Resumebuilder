﻿using System;
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
using Experience = ResumeBuilder.WindowStep3.Experience;
using PersonalInformation = ResumeBuilder.WindowStep2.PersonalInformation;
using System.Xml.Serialization;

namespace ResumeBuilder
{
    /// <summary>
    /// Interaction logic for Template1.xaml
    /// </summary>
    public partial class Template1 : Window
    {
        public PersonalInformation personalInformation = new PersonalInformation();
        public Experience experience = new Experience();
        public Template1()
        {
            InitializeComponent();
        }

        private void _PersonalInFormation()
        {
            FirstName.Content = personalInformation.FirstName;
            LastName.Content = personalInformation.LastName;
            JobTitle.Content = experience.JobTitle;
            JobTitle1.Content = experience.JobTitle;
            StartDateMonth.Content = experience.StartDateMonth;
            StartDateYear.Content = experience.StartDateYear;
            EndDateMonth.Content = experience.EndDateMonth;
            EndDateYear.Content = experience.EndDateYear;
            PhoneNumber.Content = personalInformation.PhoneNumber;
            Email.Content = personalInformation.EmailAddress;
            Address.Content = personalInformation.Address;
            if (experience.JobDescription.Count() < 330)
            {
                JobDescription.Text = experience.JobDescription;
                JobDescription1.Text = experience.JobDescription;
                _text.Text = experience.JobDescription;
            }
            else
            {
                char[] chars = new char[330];
                string str = experience.JobDescription;
                str.CopyTo(0, chars, 0, 330);
                str = new string(chars, 0, 330);
                JobDescription.Text = str;
                JobDescription1.Text = str;
                _text.Text = str;
            }
        }
        private void PrintPDF()
        {
            try
            {
                PrintDialog pDialog = new PrintDialog();
                if (pDialog.ShowDialog() == true)
                {
                    pDialog.PrintVisual(PrintPage, "PDF");
                    MessageBox.Show("Your resume saved...");
                    Close();
                    FileConvert fileConvert = new FileConvert();
                    fileConvert.Show();
                }
                else
                {
                    Close();
                    FileConvert fileConvert = new FileConvert();
                    fileConvert.Show();
                }

            }
            catch
            {
                this.IsEnabled = true;
            }
        }
        public void OpenExperienceFile()
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
            }
        }
        public void OpenPersonalInformationFile()
        {
            try
            {
                XmlSerializer xmlWriter = new XmlSerializer(typeof(PersonalInformation));
                FileStream reader = File.Open("personalInformation.xml", FileMode.Open);
                personalInformation = (PersonalInformation)xmlWriter.Deserialize(reader);
                reader.Close();
            }
            catch
            {
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenExperienceFile();
                OpenPersonalInformationFile();
                string FileName = personalInformation.Image;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(FileName);
                bitmap.EndInit();
                CoverImage1.Source = bitmap;
                _PersonalInFormation();
                PrintPDF();
            }
            catch
            {

            }

        }
    }
}
