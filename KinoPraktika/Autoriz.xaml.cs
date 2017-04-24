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
using System.Data.SqlClient;
using Microsoft.Win32;
using System.Data;


namespace KinoPraktika
{
    /// <summary>
    /// Логика взаимодействия для Autoriz.xaml
    /// </summary>
    public partial class Autoriz : Window
    {
        string connectionString, sql1, sql2;
        SqlDataAdapter adapter;
        SqlConnection connection = null;



        public Autoriz()
        {
            InitializeComponent();
            ConnectClass ConStr = new ConnectClass();
            ConStr.Connection_Options(textBox_Copy.Text, textBox3.Text, textBox1_Copy.Text, textBox2.Text);
            connectionString = ConStr.ConnectString;
        }

        private void Reg_But_Click(object sender, RoutedEventArgs e)
        {
            new Registrate().Show();
    
        }

        private void ConBD_But_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ConnectClass ConStr = new ConnectClass();
            ConStr.Connection_Options(textBox_Copy.Text, textBox3.Text, textBox1_Copy.Text, textBox2.Text);
            connectionString = ConStr.ConnectString;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
       
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            sql1 = "SELECT * FROM sotr where Login_S='"+textBox.Text+"'";
            sql2 = "Select * From sotr where Login_S='"+ textBox.Text + "'and Pass_S='"+textBox1.Text+"'";
            DataTable Logtable = new DataTable();
            DataTable Passtable = new DataTable();


            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql1, connection);
                adapter = new SqlDataAdapter(command);

                connection.Open();
                adapter.Fill(Logtable);
               

                if (Logtable.Rows.Count == 0) 
                {
                    MessageBox.Show("Пользователя не существует");
                }

                else
                {
                   
                    SqlCommand command2 = new SqlCommand(sql2, connection);
                    adapter = new SqlDataAdapter(command2);
         
                    adapter.Fill(Passtable);

                    if (Passtable.Rows.Count == 0)
                    {
                        MessageBox.Show("Неверный пароль");
                    }
                    else
                    {
                     new MainWindow().Show();
                     
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }



        }
    }
}
