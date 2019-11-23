using IBM.Data.DB2.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCrud.DAO.Connections
{
    public class Connection
    {
        const string conn = @"Server=apolo15.karsten.com.br:50000;Database=DB2TST;UID=db2atst;PWD=password";
        public static DB2Connection Conn()
        {
            return new DB2Connection(conn);
        }
    }
}
