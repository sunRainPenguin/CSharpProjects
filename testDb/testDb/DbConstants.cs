using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testDb
{
    class DbConstants
    {
        // db service name
        public const string DbServiceName = "MongodbService";

        // db name
        public const string DecentPVDbName = "DecentPV";

        // collections       
        /* categoryNodes collection */
        public const string CategoryNodesColName = "categoryNodes";
        public const string CategoryNodes_ParentFieldName = "ParentFieldName";
        public const string CategoryNodes_NodeName = "NodeName";
        public const string CategoryNodes_About = "About";

        /* projects collection */
        public const string ProjectColName = "projects";

        /* documents collection */
        public const string DocumentColName = "documents";
    }
}
