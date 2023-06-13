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

namespace StartCS_DataBase.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel()
        {
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
    }
}
