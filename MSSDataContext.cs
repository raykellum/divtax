using System;
using SnapObjects.Data;
using SnapObjects.Data.SqlServer;

namespace TaxabilityWebAPI
{
    public class MSSDataContext : SqlServerDataContext
    {
        public MSSDataContext(string connectionString)
                :this(new SqlServerDataContextOptions<MSSDataContext>(connectionString))
        {  
            
        }

        public MSSDataContext(IDataContextOptions<MSSDataContext> options)
            : base(options)
        {

        }

        public MSSDataContext(IDataContextOptions options)
            : base(options)
        {

        }
    }
}
