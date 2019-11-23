using IBM.Data.DB2;

namespace Aula13_08_DBConnection.DAO.Connections
{
    public class Connection
    {
       public const string connectionDb2 = @"Server=apolo15.karsten.com.br:50000;Database=DB2TST;UID=db2atst;PWD=password";
        public static DB2Connection DB2Connection()
        {
            return new DB2Connection(connectionDb2);
        }
    }
}
