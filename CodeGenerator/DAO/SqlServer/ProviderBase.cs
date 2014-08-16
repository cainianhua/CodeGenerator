﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.DAO
{
	internal class ProviderBase
	{
		// Fields
		protected const string AT = "@";
		protected const string FIELD_CREATED_BY = "CreatedBy";
		protected const string FIELD_CREATED_DATE = "CreatedDate";
		protected const string FIELD_MODIFIED_BY = "ModifiedBy";
		protected const string FIELD_MODIFIED_DATE = "ModifiedDate";
		protected const string FIELD_PAGE_INDEX = "PageIndex";
		protected const string FIELD_PAGE_SIZE = "PageSize";
		protected const string FIELD_RETURN_VALUE = "ReturnValue";
		protected const string FIELD_TOTAL = "Total";
		protected static readonly string DatabaseConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
		protected const int TWENTY_FOUR_HOURS = 0x5a0;

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
