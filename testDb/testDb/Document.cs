using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace testDb
{
    class Document
    {
        public string DocumentUpdateDate { get; set; }
        public string DocumentPath { get; set; }
        public ObjectId ProjectID { get; set; }

        public Document(string date, string path, ObjectId proId)
        {
            DocumentUpdateDate = date;
            DocumentPath = path;
            ProjectID = proId;
        }
    }
}
