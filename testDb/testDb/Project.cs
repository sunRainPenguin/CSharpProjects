using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testDb
{
    class Project
    {
        // 当前项目ID，等到界面上这块逻辑写完之后，这部分需要修改
        public static string currProjectId = "59cc5e91664b3a1e24fad1b0";

        //private int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectAbout { get; set; }
        public string ProjectCategory { get; set; }

        public Project(string name, string about, string category)
        {
            //ProjectId = id;
            ProjectName = name;
            ProjectAbout = about;
            ProjectCategory = category;
        }
    }
}
