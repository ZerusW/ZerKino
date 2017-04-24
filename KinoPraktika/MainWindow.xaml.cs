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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using Microsoft.Win32;
using System.Data;


namespace KinoPraktika
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string connectionString, sql;
        DataTable InfoTable;
        SqlDataAdapter adapter;
        SqlConnection connection = null;
        
        public MainWindow()
        {

            InitializeComponent();
            connectionString = "Data Source=ЗАХАР\\ZERNET;Initial Catalog=Praktika_Kino;Integrated Security=True; User ID=SA;Password=12345";
          
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sql = "SELECT * FROM Client";
            InfoTable = new DataTable();
           

            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
              
                connection.Open();
                adapter.Fill(InfoTable);
                InfosGrid.ItemsSource = InfoTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox.Text == "")

            {
                sql = "SELECT * FROM Client";
            }
            else
            {
                sql = "SELECT * FROM Client where I Like'%" + textBox.Text + "%'";
            }

            InfoTable = new DataTable();
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);

                
                adapter.Fill(InfoTable);
                InfosGrid.ItemsSource = InfoTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InfosGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
          
        }

        private void InfosGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void InfosGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            connection.Close();
        }
    }
    }

