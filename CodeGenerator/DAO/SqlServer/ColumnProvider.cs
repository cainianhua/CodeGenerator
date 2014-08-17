using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CodeGenerator.VO;

namespace CodeGenerator.DAO.SqlServer
{
	class ColumnProvider : ProviderBase, IColumnProvider
	{
		#region [ SQLs ]
		/// <summary>
		/// 获取所有字段语句
		/// </summary>
		private const string SQL_GET_COLUMES = @"
SELECT c.column_id, c.name, c.user_type_id, t.name as user_type_name, c.max_length, c.[precision], c.scale 
FROM sys.columns c 
LEFT JOIN sys.objects o ON c.[object_id] = o.[object_id]
LEFT JOIN sys.types t ON t.user_type_id = c.user_type_id
WHERE o.name = @Name
";
		/// <summary>
		/// 获取所有主键字段
		/// </summary>
		private const string SQL_GET_COLUMES_PK = @"
SELECT c.column_id, c.name, c.user_type_id, t.name as user_type_name, c.max_length, c.[precision], c.scale 
FROM sys.columns c 
JOIN sys.types t ON t.user_type_id = c.user_type_id
JOIN sys.index_columns ic on c.[object_id] = ic.[object_id] and c.column_id = ic.column_id
JOIN sys.indexes i on i.[object_id] = ic.[object_id] AND i.index_id = ic.index_id
JOIN sys.objects o on c.[object_id] = o.[object_id]
WHERE o.name = @Name AND i.is_primary_key = 1 and i.is_unique = 1
";
		/// <summary>
		/// 获取所有外键字段
		/// </summary>
		private const string SQL_GET_COLUMES_FK = @"
SELECT c.column_id, c.name, c.user_type_id, t.name as user_type_name, c.max_length, c.[precision], c.scale 
FROM sys.columns c 
JOIN sys.types t ON t.user_type_id = c.user_type_id
JOIN sys.foreign_key_columns fkc on fkc.parent_object_id = c.[object_id] AND fkc.parent_column_id = c.column_id
JOIN sys.objects o on c.[object_id] = o.[object_id]
WHERE o.name = @Name
";
		/// <summary>
		/// 获取所有唯一键字段
		/// </summary>
		private const string SQL_GET_COLUMES_UK = @"
SELECT c.column_id, c.name, c.user_type_id, t.name as user_type_name, c.max_length, c.[precision], c.scale 
FROM sys.columns c 
JOIN sys.types t ON t.user_type_id = c.user_type_id
JOIN sys.index_columns ic on c.[object_id] = ic.[object_id] and c.column_id = ic.column_id
JOIN sys.indexes i on i.[object_id] = ic.[object_id] AND i.index_id = ic.index_id
JOIN sys.objects o on c.[object_id] = o.[object_id]
WHERE o.name = @Name AND i.is_primary_key = 0 and i.is_unique = 1
";
		#endregion

		#region [ Fields ]
		private const string FIELD_COLUMN_ID = "column_id";
		private const string FIELD_NAME = "name";
		private const string FIELD_USER_TYPE_ID = "user_type_id";
		private const string FIELD_USER_TYPE_NAME = "user_type_name";
		private const string FIELD_MAX_LENGTH = "max_length";
		private const string FIELD_PRECISION = "precision";
		private const string FIELD_SCALE = "scale";
		#endregion

		public ColumnProvider() { }

		public ColumnProvider( string dbServer, string dbName ) : this() {
			this.DbServer = dbServer;
			this.DbName = dbName;
		}

		public List<ColumnVO> GetAll(string tableName ) {
			return GetSQLResults( SQL_GET_COLUMES, tableName );
		}

		public List<ColumnVO> GetPKs( string tableName ) {
			return GetSQLResults( SQL_GET_COLUMES_PK, tableName );
		}

		public List<ColumnVO> GetFKs( string tableName ) {
			return GetSQLResults( SQL_GET_COLUMES_FK, tableName );
		}

		public List<ColumnVO> GetUKs( string tableName ) {
			return GetSQLResults( SQL_GET_COLUMES_UK, tableName );
		}

		private List<ColumnVO> GetSQLResults( string sql, string tableName ) {
			List<ColumnVO> columns = new List<ColumnVO>( 0 );
			IDataReader reader = null;

			try {
				reader = SqlHelper.ExecuteReader( DbConnectionString, CommandType.Text, sql, SqlHelper.MakeInParameter( AT + FIELD_NAME, SqlDbType.NVarChar, 255, tableName ) );
				while (reader.Read()) {
					columns.Add( LoadColumn( reader ) );
				}
			}
			finally {
				if (reader != null && !reader.IsClosed)
					reader.Close();
			}

			return columns;
		}

		private ColumnVO LoadColumn( IDataReader reader ) {
			ColumnVO c = new ColumnVO();
			c.ColumnId = ReadInt( reader, FIELD_COLUMN_ID );
			c.Name = ReadString( reader, FIELD_NAME );
			c.UserTypeName = ReadString( reader, FIELD_USER_TYPE_NAME );
			c.MaxLength = ReadInt( reader, FIELD_MAX_LENGTH );
			c.Precision = ReadInt( reader, FIELD_PRECISION );
			c.Scale = ReadInt( reader, FIELD_SCALE );
			//c.CreatedDate = ReadDate( reader, FIELD_CREATED_DATE );
			//c.ModifiedDate = ReadDate( reader, FIELD_MODIFIED_DATE );

			return c;
		}
	}
}