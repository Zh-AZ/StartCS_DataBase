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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StartCS_DataBase
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewModel.OnViewInitialized(this);


            //FillDataGrid();
            //FillTable();
        }

        void FillTable()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "(localdb)\\MSSQLLocalDB",
                InitialCatalog = "MSSQLLocalDemo",
                IntegratedSecurity = true,
                UserID = "Admin",
                Password = "qwerty",
                Pooling = true
            };

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

            string sqlScript = @"SELECT 
                        Clients.clients as 'Клиенты',
                        Managers.managers as 'Менеджеры',
                        TempTable.id as 'ID'
                        FROM Clients, Managers, TempTable
                        WHERE Clients.id = TempTable.id or Managers.id = TempTable.id";

            sqlDataAdapter.SelectCommand = new SqlCommand(sqlScript, sqlConnection);
            sqlDataAdapter.Fill(dataTable);

            gridAllView.DataContext = dataTable.DefaultView;
        }

        void FillDataGrid()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "(localdb)\\MSSQLLocalDB",
                InitialCatalog = "MSSQLLocalDemo",
                IntegratedSecurity = false,
                //UserID = "Admin",
                //Password = "qwerty",
                //Pooling = true
            };

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

            string sqlScript = @"SELECT 
                        Clients.clients as 'Клиенты',
                        Managers.managers as 'Менеджеры',
                        TempTable.id as 'ID'
                        FROM Clients, Managers, TempTable
                        WHERE Clients.id = TempTable.id or Managers.id = TempTable.id";

            sqlDataAdapter.SelectCommand = new SqlCommand(sqlScript, sqlConnection);
            sqlDataAdapter.InsertCommand.Parameters.Add("@clients", SqlDbType.NVarChar, 20, "clients");
            sqlDataAdapter.InsertCommand.Parameters.Add("@managers", SqlDbType.NVarChar, 20, "managers");
            sqlDataAdapter.InsertCommand.Parameters.Add("@id", SqlDbType.Int, 4,"ID_Client");
            sqlDataAdapter.Fill(dataTable);
            
            //gridView.DataContext = dataTable.DefaultView;
        }
    }
}
