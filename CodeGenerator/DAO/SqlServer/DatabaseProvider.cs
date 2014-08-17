using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeGenerator.VO;

namespace CodeGenerator.DAO.SqlServer
{
	class DatabaseProvider : ProviderBase, IDatabaseProvider
	{
		public DatabaseProvider() { }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="dbServer"></param>
		/// <param name="dbName"></param>
		public DatabaseProvider( string dbServer, string dbName ) : this() {
			this.DbServer = dbServer;
			this.DbName = dbName;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="server"></param>
		/// <returns></returns>
		public List<DatabaseVO> GetDatabases( string server ) {
			throw new NotImplementedException();
		}
	}
}
