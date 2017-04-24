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
using System.Net;
using System.Net.Mail;

namespace KinoPraktika
{
    /// <summary>
    /// Логика взаимодействия для Registrate.xaml
    /// </summary>
    public partial class Registrate : Window
    {
        public Registrate()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
                



            
            SmtpClient Smtp = new SmtpClient("stmp.gmail.com",25);
            Smtp.Credentials = new NetworkCredential("zernetcorp@gmail.com", "Zerus123");
            Smtp.EnableSsl = false;
            //Формирование письма
            MailMessage message = new MailMessage();
            message.From = new MailAddress("zernetcorp@gmil.com");
            message.To.Add(new MailAddress("zaxarabro@gmail.com"));
            message.Subject = "Заголовок";
            message.Body = "Сообщение";
          
            try
            {
                Smtp.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }
    }
}
