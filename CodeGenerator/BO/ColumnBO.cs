using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeGenerator.DAO;
using CodeGenerator.VO;

namespace CodeGenerator.BO
{
	public class ColumnBO : BaseBO
	{
		private IColumnProvider _Provider;
		//private static ColumnBO _Instance;
		
		private ColumnBO( string dbServer, string dbName ) : base( dbServer, dbName, "Column" ) {
			_Provider = (IColumnProvider)this.CreateProvider();
		}
		///
		public static ColumnBO GetInstance( string dbServer, string dbName ) {
			//if ( _Instance == null )
			//	_Instance = new ColumnBO( dbServer, dbName );

			//return _Instance;
			return new ColumnBO( dbServer, dbName );
		}

		public List<ColumnVO> GetColumns( string tableName ) {
			if ( string.IsNullOrEmpty( tableName ) ) return new List<ColumnVO>();
			return _Provider.GetAll( tableName );
		}

		public List<ColumnVO> GetPKs( string tableName ) {
			if ( string.IsNullOrEmpty( tableName ) ) return new List<ColumnVO>();
			return _Provider.GetPKs( tableName );
		}

		public List<ColumnVO> GetFKs( string tableName ) {
			if ( string.IsNullOrEmpty( tableName ) ) return new List<ColumnVO>();
			return _Provider.GetFKs( tableName );
		}

		public List<ColumnVO> GetUKs( string tableName ) {
			if ( string.IsNullOrEmpty( tableName ) ) return new List<ColumnVO>();
			return _Provider.GetUKs( tableName );
		}
	}
}
