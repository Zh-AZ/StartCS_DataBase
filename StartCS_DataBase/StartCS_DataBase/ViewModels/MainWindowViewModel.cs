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

namespace StartCS_DataBase.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel()
        {
            ConnectionBD();
            WriteToBD();
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
    }
}
