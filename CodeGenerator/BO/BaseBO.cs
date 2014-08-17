using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.BO
{
	public class BaseBO
	{
		private static readonly string type = ConfigurationManager.AppSettings["DataProvider"] ?? "SqlServer";
		//private static readonly string path = "TheKnot.Games.LittleQuiz";
		private static readonly string path = Assembly.GetExecutingAssembly().FullName.Split(',')[0];
		private static string classpath = "{0}.DAO.{1}.{2}Provider";

		protected string TableName { get; set; }
		protected string DbServer { get; set; }
		protected string DbName { get; set; }

		public BaseBO(string dbServer, string dbName, string tableName ) {
			this.DbServer = dbServer;
			this.DbName = dbName;
			this.TableName = tableName;
		}

		protected virtual object CreateProvider() {
			//Assembly.GetExecutingAssembly().GetName().Name
			return Assembly.Load( path ).CreateInstance( 
				String.Format( classpath, path, type, TableName ), 
				false, 
				BindingFlags.CreateInstance, 
				null, 
				new object[] { this.DbServer, this.DbName }, 
				null, 
				null );
		}
	}
}
