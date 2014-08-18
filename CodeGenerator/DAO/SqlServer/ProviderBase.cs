using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace CodeGenerator.DAO
{
	internal class ProviderBase
	{
		// Fields
		protected const string AT = "@";
		protected const string FIELD_CREATED_DATE = "Create_Date";
		protected const string FIELD_MODIFIED_DATE = "Modify_Date";
		//protected static readonly string dbConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
		//Initial Catalog=master;Data Source={0};Integrated Security=True;Connect Timeout=5;
		private static readonly string dbConnectionStringFomatter = "Initial Catalog={1};Data Source={0};Integrated Security=True;";
		protected const int TWENTY_FOUR_HOURS = 0x5a0;

		protected string DbName { get; set; }
		protected string DbServer { get; set; }
		protected string DbConnectionString {
			get {
				return string.Format( dbConnectionStringFomatter, this.DbServer, this.DbName );
			}
		}

		// Methods
		protected bool ReadBool(IDataReader reader, string p) {
			return ((reader[p] != DBNull.Value) && Convert.ToBoolean(reader[p]));
		}

		protected DateTime ReadDate(IDataReader reader, string p) {
			if (reader[p] != DBNull.Value) {
				return Convert.ToDateTime(reader[p]);
			}
			return DateTime.MinValue;
		}

		protected int ReadInt(IDataReader reader, string p) {
			if (reader[p] != DBNull.Value) {
				return Convert.ToInt32(reader[p]);
			}
			return 0;
		}

		protected long ReadLong(IDataReader reader, string p) {
			if (reader[p] != DBNull.Value) {
				return Convert.ToInt64(reader[p]);
			}
			return 0L;
		}

		protected string ReadString(IDataReader reader, string p) {
			if (reader[p] != DBNull.Value) {
				return Convert.ToString(reader[p]);
			}
			return string.Empty;
		}
	}
}
