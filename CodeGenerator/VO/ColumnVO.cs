using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGenerator.VO
{
	public class ColumnVO : BaseVO
	{
		public long ColumnId { get; set; }
		public string Name { get; set; }
		public string UserTypeName { get; set; }
		private string _CShareTypeName;
		public string ClrTypeName {
			get {
				if ( string.IsNullOrEmpty( _CShareTypeName ) ) {
					_CShareTypeName = TemplateUtils.ConvertSqlTypeToCLR( UserTypeName );
				}
				return _CShareTypeName;
			}
		}
		public int MaxLength { get; set; }
		public int Precision { get; set; }
		public int Scale { get; set; }
        public bool IsIdentity { get; set; }
	}
}
