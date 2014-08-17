using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeGenerator.DAO;

namespace CodeGenerator.BO
{
	class DatabaseBO : BaseBO
	{
		private IDatabaseProvider _Provider;
		//private static DatabaseBO _Instance;
		private DatabaseBO( string dbServer ) : base( dbServer, "master", "Database" ) {
			_Provider = (IDatabaseProvider)this.CreateProvider();
		}

		public static DatabaseBO GetInstance( string dbServer ) {
			//if ( _Instance == null )
			//	_Instance = new DatabaseBO( dbServer );

			//return _Instance;
			return new DatabaseBO( dbServer );
		}
	}
}
