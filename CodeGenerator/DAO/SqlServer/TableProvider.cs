using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeGenerator.VO;

namespace CodeGenerator.DAO.SqlServer
{
	class TableProvider : ProviderBase, ITableProvider
	{
		private const string SQL_GET_TABLES = @"
SELECT [object_id] as TableId, name, create_date, modify_date
FROM sys.objects 
WHERE type in ('U')
";

		private const string FIELD_TABLE_ID = "TableId";
		private const string FIELD_NAME = "name";


		public List<TableVO> GetTables( string dbName ) {
			List<TableVO> tables = new List<TableVO>();
			IDataReader reader = null;
			try {
				reader = SqlHelper.ExecuteReader( dbConnectionString, CommandType.Text, SQL_GET_TABLES );
				while (reader.Read()) {
					tables.Add( LoadTable( reader ) );
				}
			}
			finally {
				if (reader != null && !reader.IsClosed)
					reader.Close();
			}

			return tables;
		}

		private TableVO LoadTable( IDataReader reader ) {
			TableVO t = new TableVO();
			t.TableId = ReadInt( reader, FIELD_TABLE_ID );
			t.Name = ReadString( reader, FIELD_NAME );
			t.CreatedDate = ReadDate( reader, FIELD_CREATED_DATE );
			t.ModifiedDate = ReadDate( reader, FIELD_MODIFIED_DATE );

			return new TableVO();
		}
	}
}
