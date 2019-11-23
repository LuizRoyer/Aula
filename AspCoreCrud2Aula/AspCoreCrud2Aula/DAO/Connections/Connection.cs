using IBM.Data.DB2.Core;

namespace AspCoreCrud2Aula.DAO.Connections
{
    public class Connection
    {
        const string connDB2 = @"Server=apolo15.karsten.com.br:50000;Database=DB2TST;UID=db2atst;PWD=password";

        public static DB2Connection ConnDb2()
        {
            return new DB2Connection(connDB2);
        }
    }
}
