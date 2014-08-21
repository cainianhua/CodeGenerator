using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using log4net;

namespace CodeGenerator
{
	public class Connector
	{
		private static Connector _Instance;
		private ILog log = LogManager.GetLogger( typeof( Connector ) );

		private Connector() { }
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static Connector GetInstance() {
			if ( _Instance == null )
				_Instance = new Connector();

			return _Instance;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="server"></param>
		/// <returns></returns>
		public DataSet GetDatabases( string server ) {
			DataSet ds = null;
			try {
				ds = SqlHelper.ExecuteDataset( string.Format( @"Initial Catalog=master;Data Source={0};Integrated Security=True;Connect Timeout=5;", server ), CommandType.Text, "SELECT database_id as id, name FROM sys.databases ORDER BY name" ); 
			}
			catch(Exception ex) {
				if ( log.IsErrorEnabled )
					log.ErrorFormat( "执行出错，错误是：{0}" + ex.Message );
			}
			return ds;
		}
	}
}
