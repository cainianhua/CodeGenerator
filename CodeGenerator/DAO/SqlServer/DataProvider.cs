using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using log4net;

namespace CodeGenerator
{
	internal class DataProvider
	{
		private ILog log = LogManager.GetLogger( typeof(DataProvider) );
		private const string CONNECTION_STRING_FORMAT = @"Data Source={0};Initial Catalog={0};Integrated Security=True;";
		/// <summary>
		/// 
		/// </summary>
		/// <param name="serverName"></param>
		/// <param name="dbName"></param>
		/// <returns></returns>
		public DataSet GetTables( string serverName, string dbName ) {
			DataSet ds = new DataSet();
			try {
				ds = SqlHelper.ExecuteDataset( string.Format( CONNECTION_STRING_FORMAT, serverName, dbName ), CommandType.Text, "SELECT * FROM SYS.OBJECTS WHERE [type] in ('U')" );
			}
			catch ( Exception ex ) {
				if ( log.IsErrorEnabled ) log.ErrorFormat( "获取Tables的方法出错啦，错误是：{0}", ex.Message );
			}
			return ds;
		}
	}
}
