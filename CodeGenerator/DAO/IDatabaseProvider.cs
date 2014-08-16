using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeGenerator.VO;

namespace CodeGenerator.DAO
{
	interface IDatabaseProvider
	{
		List<DatabaseVO> GetDatabases( string server );
	}
}
