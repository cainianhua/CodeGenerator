using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Models
{
    class GenerateModel
    {
        public List<TemplateModel> Tables { get; set; }
        public string DbName { get; set; }
    }
}
