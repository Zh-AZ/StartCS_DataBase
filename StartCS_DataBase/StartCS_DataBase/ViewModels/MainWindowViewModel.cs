using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartCS_DataBase.Infrastructure.Commands.Base;
using StartCS_DataBase.Infrastructure.Commands;
using StartCS_DataBase.ViewModels.Base;
using System.Windows.Markup;
using System.Data.SqlClient;
using System.Windows;
using System.Data;
using System.Windows.Media;

namespace StartCS_DataBase.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        static MainWindow MainWindow;

        public void OnViewInitialized(MainWindow mainWindow) { MainWindow = mainWindow; }

        public MainWindowViewModel()
        {
            //ConnectionBD();
            //WriteToBD();

            //FillDataGrid();
            FillTable();
        }

        //Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = MSSQLLocalDemo; Integrated Security = True; Pooling=False

        SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "(localdb)\\MSSQLLocalDB",
            InitialCatalog = "MSSQLLocalDemo",
            IntegratedSecurity = true,
            UserID = "Admin", Password = "qwerty",
            Pooling = true
        };

        void FillDataGrid()
        {
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
            
            //MainWindow.gridView.DataContext = dataTable.DefaultView;
        }

        void ConnectionBD()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
                {
                    sqlConnection.Open();
                    string sqlServer = @"SELECT 
                        Clients.clients,
                        Managers.managers,
                        TempTable.id as 'ID_Client'
                        FROM Clients, Managers, TempTable
                        WHERE Clients.id = TempTable.id or Managers.id = TempTable.id";
                    
                    SqlCommand sqlCommand = new SqlCommand(sqlServer, sqlConnection);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read()) 
                    {
                        /*Do something*/
                        Console.WriteLine($"{sqlDataReader[0]} | " +
                                          $"{sqlDataReader[1]} | " +
                                          $"{sqlDataReader[2]} | "); 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        void WriteToBD()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
                {
                    sqlConnection.Open();

                    string[] sqlWriteToBD =
                    {
                        "INSERT INTO Clients ([id],[clients], [values]) values (04, 'Client_04', 'Val_04')",
                        "INSERT INTO Managers ([id],[managers], [description]) values (03, 'Manager_03', 'Des_03')",
                    };

                    SqlCommand sqlCommand;
                    foreach (string sqlDataReader in sqlWriteToBD)
                    {
                        sqlCommand = new SqlCommand(sqlDataReader, sqlConnection);
                        sqlCommand.ExecuteNonQuery();

                        //Изменение значения
                        //sqlDataReader = @"UPDATE TempTable SET title = N'Новое поле' WHERE id = 19";
                        //sqlCommand = new SqlCommand(sqlDataReader, sqlConnection);
                        //sqlCommand.ExecuteNonQuery();

                        //Удаление указанных данных
                        //sqlDataReader = @"DELETE FROM TempTable WHERE id > 15";
                        //sqlCommand = new SqlCommand(sqlDataReader, sqlConnection);
                        //sqlCommand.ExecuteNonQuery();

                        //Удаление таблицы
                        //sqlDataReader = @"DROP TABLE TempTable";
                        //sqlCommand = new SqlCommand(sqlDataReader, sqlConnection);
                        //sqlCommand.ExecuteNonQuery();
                        //break;
                    }
                }
            }
            catch (Exception ex )
            {
                MessageBox.Show($"{ex.Message}");
            }
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

            MainWindow.gridAllView.DataContext = dataTable.DefaultView;
       }
    }
}
