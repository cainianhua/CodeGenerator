using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CodeGenerator.VO;

namespace CodeGenerator
{
	public class TemplateUtils
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sqlTypeName"></param>
		/// <returns></returns>
		public static string ConvertSqlTypeToSqlDataType( string sqlTypeName ) {
			SqlDbType type;
			if ( !Enum.TryParse<SqlDbType>( sqlTypeName, true, out type ) ) {
				type = SqlDbType.NVarChar;
			}
			return type.ToString();
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sqlTypeName"></param>
		/// <returns></returns>
		public static string ConvertSqlTypeToCSharp( string sqlTypeName ) {
			SqlDbType type;
			if ( !Enum.TryParse<SqlDbType>( sqlTypeName, true, out type ) ) {
				type = SqlDbType.NVarChar;
			}

			string result = "string";
			switch ( type ) {
				case SqlDbType.BigInt:
					result = "long";
					break;
				case SqlDbType.Int:
					result = "int";
					break;
				case SqlDbType.SmallInt:
				case SqlDbType.TinyInt:
					result = "short";
					break;
				case SqlDbType.Bit:
					result = "bool";
					break;
				case SqlDbType.DateTime:
				case SqlDbType.SmallDateTime:
					result = "DateTime";
					break;
				case SqlDbType.Char:
				case SqlDbType.NChar:
				case SqlDbType.NVarChar:
				case SqlDbType.VarChar:
				case SqlDbType.Text:
				case SqlDbType.NText:
				default:
					result = "string";
					break;
			}
			return result;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sqlTypeName"></param>
		/// <returns></returns>
		public static string ConvertSqlTypeToCLR( string sqlTypeName ) {
			SqlDbType type;
			if ( !Enum.TryParse<SqlDbType>( sqlTypeName, true, out type ) ) {
				type = SqlDbType.NVarChar;
			}
			
			string result = "String";
			switch ( type ) {
				case SqlDbType.BigInt:
					result = "Int64";
					break;
				case SqlDbType.Int:
					result = "Int32";
					break;
				case SqlDbType.SmallInt:
					result = "Int16";
					break;
				case SqlDbType.TinyInt:
					result = "Byte";
					break;
				case SqlDbType.Bit:
					result = "Boolean";
					break;
				case SqlDbType.DateTime:
				case SqlDbType.SmallDateTime:
					result = "DateTime";
					break;
				case SqlDbType.Char:
				case SqlDbType.NChar:
				case SqlDbType.NVarChar:
				case SqlDbType.VarChar:
				case SqlDbType.Text:
				case SqlDbType.NText:
				default:
					result = "String";
					break;
			}
			return result;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="lst"></param>
		/// <returns></returns>
		public static string GetSQLWhereAnd( ColumnVO item ) {
            return string.Format( "[{0}] = @{0}", item.Name );
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public static string GetSQLWhereAnds( List<ColumnVO> lst ) {
            StringBuilder builder = new StringBuilder( lst.Count + 1 );
            builder.Append( "1 = 1" );
            foreach ( ColumnVO item in lst ) {
                builder.AppendFormat( " AND [{0}] = @{0}", item.Name );
            }

            return builder.ToString();
        }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="lst"></param>
		/// <returns></returns>
		public static string GetMethodParameters( List<ColumnVO> lst ) {
			StringBuilder builder = new StringBuilder( lst.Count );
			foreach ( ColumnVO item in lst ) {
				builder.AppendFormat( "{0} {1}, ", ConvertSqlTypeToCSharp(item.UserTypeName), item.Name.Substring( 0, 1 ).ToLower() + item.Name.Substring( 1 ) );
			}
            return builder.ToString().TrimEnd( ',', ' ' );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string GetMethodParameter( ColumnVO item ) {
            return string.Format( "{0} {1}", ConvertSqlTypeToCSharp( item.UserTypeName ), item.Name.Substring( 0, 1 ).ToLower() + item.Name.Substring( 1 ) );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public static string GetMethodCallParameters( List<ColumnVO> lst ) {
            StringBuilder builder = new StringBuilder( lst.Count );
            foreach ( ColumnVO item in lst ) {
                builder.AppendFormat( "{0}, ", item.Name.Substring( 0, 1 ).ToLower() + item.Name.Substring( 1 ) );
            }
            return builder.ToString().TrimEnd( ',', ' ' );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string GetMethodCallParameter( ColumnVO item ) {
            return string.Format( "{0}", item.Name.Substring( 0, 1 ).ToLower() + item.Name.Substring( 1 ) );
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="lst"></param>
		/// <returns></returns>
		public static string GetSQLParameters( List<ColumnVO> lst ) {
			StringBuilder builder = new StringBuilder( lst.Count );
			foreach ( ColumnVO item in lst ) {
				builder.AppendFormat( "                SqlHelper.MakeInParameter( AT + FIELD_{0}, SqlDbType.{1}, {2}, {3} ),\r\n", item.Name.ToUpper(), ConvertSqlTypeToSqlDataType( item.UserTypeName ), GetParameterSize( item ), item.Name.Substring( 0, 1 ).ToLower() + item.Name.Substring( 1 ) );
			}
			return builder.ToString().TrimEnd( ',', '\r', '\n' );
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public static string GetSQLParameter( ColumnVO item ) {
			return string.Format( "                SqlHelper.MakeInParameter( AT + FIELD_{0}, SqlDbType.{1}, {2}, {3} )", item.Name.ToUpper(), ConvertSqlTypeToSqlDataType( item.UserTypeName ), GetParameterSize( item ), item.Name.Substring( 0, 1 ).ToLower() + item.Name.Substring( 1 ) );
        }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="lst"></param>
		/// <returns></returns>
		public static string GetSaveSQLParameters( List<ColumnVO> lst ) {
			StringBuilder builder = new StringBuilder( lst.Count );
			foreach ( ColumnVO item in lst ) {
				builder.AppendFormat( "                SqlHelper.MakeInParameter( AT + FIELD_{0}, SqlDbType.{1}, {2}, item.{3} ),\r\n", item.Name.ToUpper(), ConvertSqlTypeToSqlDataType( item.UserTypeName ), GetParameterSize(item), item.Name );
			}
			builder.Append( "                SqlHelper.MakeInParameter( AT + FIELD_ACTION_DATE, SqlDbType.DateTime, 8, item.ActionDate == DateTime.MinValue ? DateTime.Now : item.ActionDate ),\r\n" );
			builder.Append( "                SqlHelper.MakeInParameter( AT + FIELD_ACTION_BY, SqlDbType.NVarChar, 50, item.ActionBy ?? String.Empty ),\r\n" );
			if ( lst[0].IsIdentity ) {
				builder.AppendFormat( "                SqlHelper.MakeParameter( AT + FIELD_RETURN_VALUE, SqlDbType.Int, 4, ParameterDirection.Output, -1 )" );
			}
			return builder.ToString().TrimEnd( ',', '\r', '\n' );
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string GetProcTypeString( ColumnVO c ) {
            switch ( c.UserTypeName ) {
                case "nvarchar":
                case "nchar":
                    return ( c.UserTypeName + "(" + ( ( c.MaxLength == -1 ) ? "max" : ( ( c.MaxLength / 2 ) ).ToString() ) + ")" );
                case "varchar":
                case "char":
                    return ( c.UserTypeName + "(" + ( ( c.MaxLength == -1 ) ? "max" : c.MaxLength.ToString() ) + ")" );
            }
            return c.UserTypeName;
        }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		public static int GetParameterSize( ColumnVO c ) {
			switch ( c.UserTypeName ) {
				case "nvarchar":
				case "nchar":
					return c.MaxLength == -1 ? -1 : c.MaxLength / 2;
				case "varchar":
				case "char":
					return c.MaxLength == -1 ? -1 : c.MaxLength;
			}
			return c.MaxLength;
		}
	}
}
