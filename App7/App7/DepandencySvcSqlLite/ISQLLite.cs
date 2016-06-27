using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App7
{
    public interface ISQLLite
    {
        SQLiteConnection GetConnection();
    }
}
