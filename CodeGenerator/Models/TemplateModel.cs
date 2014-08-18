using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeGenerator.VO;

namespace CodeGenerator.Models
{
    public class TemplateModel
    {
        public string Namespace { get; set; }
        public int TableId { get; set; }
        public string Name { get; set; }
        public string NameS { get; set; }
        public List<ColumnVO> Columns { get; set; }
        public List<ColumnVO> PKs { get; set; }
        public List<ColumnVO> FKs { get; set; }
        public List<ColumnVO> UKs { get; set; }
    }
}
