using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeGenerator.VO;

namespace CodeGenerator.DAO
{
	interface ITableProvider
	{
		List<TableVO> GetTables( string dbName );
	}
}
