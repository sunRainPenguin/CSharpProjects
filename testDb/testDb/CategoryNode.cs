using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testDb
{
    // 对应一个collection类，每个对象为collection中的每个文档
    class CategoryNode
    {
        public string ParentFieldName { get; set; }
        public string NodeName { get; set; }
        public string About { get; set; }
    }
}
