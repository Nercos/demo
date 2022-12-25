using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Windows.Threading;
using Microsoft.SqlServer.Server;

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    /// 

    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();
            /*StudentsGrid.ItemsSource = App.tblUser.Demo.ToList();*/
           

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DeportamentsView(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-O6LLO1H\MSSQL; Initial Catalog=Demo; Integrated Security=True");
            connection.Open();
            string cmd = "SELECT * FROM tblUser"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();
            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("tblUser"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            StudentsGrid.ItemsSource = dt.DefaultView; // Сам вывод 
            connection.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
    }
}
