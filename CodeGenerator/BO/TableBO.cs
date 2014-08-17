using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeGenerator.DAO;
using CodeGenerator.VO;

namespace CodeGenerator.BO
{
	public class TableBO : BaseBO
	{
		private ITableProvider _Provider;
		//private static TableBO _Instance;
		private TableBO( string dbServer, string dbName ) : base(dbServer, dbName, "Table") {
			_Provider = (ITableProvider)base.CreateProvider();
		}

		public static TableBO GetInstance( string dbServer, string dbName ) {
			//if ( _Instance == null )
			//	_Instance = new TableBO( dbServer, dbName );

			//return _Instance;
			return new TableBO( dbServer, dbName );
		}

		public List<TableVO> GetTables() {
			return _Provider.GetTables();
		}
	}
}
