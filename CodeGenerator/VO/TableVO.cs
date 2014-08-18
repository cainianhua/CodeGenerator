using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CodeGenerator.BO;
using System.Data.Entity.ModelConfiguration.Design.PluralizationServices;
using System.Globalization;

namespace CodeGenerator.VO
{
	public class TableVO : BaseVO
	{
		public int TableId { get; set; }
		public string Name { get; set; }
		private string _NameSingular;
		public string NameS {
			get {
				if ( string.IsNullOrEmpty( _NameSingular ) ) {
                    //_NameSingular = Name;
                    //if ( _NameSingular.EndsWith( "ies" ) ) _NameSingular = Regex.Replace( _NameSingular, @"^(.+)ies$", "$1y" );
                    //if ( _NameSingular.EndsWith( "es" ) ) _NameSingular = Regex.Replace( _NameSingular, @"^(.+)es$", "$1" );
                    //if ( _NameSingular.EndsWith( "s" ) ) _NameSingular = Regex.Replace( _NameSingular, @"^(.+)s$", "$1" );
                    _NameSingular = PluralizationService.CreateService( new CultureInfo( "en" ) ).Singularize( Name );
				}
				return _NameSingular;
			}
		}
		public List<ColumnVO> Columns { get; set; }
		public List<ColumnVO> PKs { get; set; }
		public List<ColumnVO> FKs { get; set; }
		public List<ColumnVO> UKs { get; set; }
	}
}
