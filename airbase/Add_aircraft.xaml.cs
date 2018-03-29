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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace airbase
{
    /// <summary>
    /// Interaction logic for Add_aircraft.xaml
    /// </summary>
    public partial class Add_aircraft : Window
    {
        public Add_aircraft()
        {
            InitializeComponent();
        }
        String mycon = "Data Source = DESKTOP-K5L0TDA\\SQLEXPRESS; Initial Catalog=Mohit; Integrated Security=true";
           
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Menu men = new Menu();
            men.Show();
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(mycon);
                 con.Open();
                int id = Convert.ToInt32(textBox.Text);
                int acno= Convert.ToInt32(textBox1.Text);
                int cpa= Convert.ToInt32(textBox2.Text);
                string mfon = textBox3.Text;
                string mfd = textBox4.Text;
                string scmd = "insert into aircraft values( " + id + "," + acno + "," + cpa + ",'" + mfd + "','" +mfon+ "'"+");";
                 MessageBox.Show(scmd);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = scmd;
                cmd.Connection = con;
                SqlDataReader dr = cmd.ExecuteReader();

                MessageBox.Show("Successfull feed");
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
