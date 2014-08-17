using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeGenerator.VO;

namespace CodeGenerator.DAO
{
	interface IColumnProvider
	{
		List<ColumnVO> GetAll( string tableName );
		List<ColumnVO> GetPKs( string tableName );
		List<ColumnVO> GetFKs( string tableName );
		List<ColumnVO> GetUKs( string tableName );
	}
}
