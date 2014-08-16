using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.VO
{
	public class ColumnVO : BaseVO
	{
		public long ColumnId { get; set; }
		public string Name { get; set; }
		public string UserTypeName { get; set; }
		public int MaxLength { get; set; }
		public int Precision { get; set; }
		public int Scale { get; set; }
	}
}
