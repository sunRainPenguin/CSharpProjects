using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using testDb;

namespace testDb
{
    class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database(DbConstants.DecentPVDbName);
            Database.StartDbService();


            // 插入目录节点
            string input = "";
            string[] inputs = new string[3];
            while ((input = Console.ReadLine()) != "zz")
            {

                inputs = input.Split();
                CategoryNode nodeT = new CategoryNode();
                nodeT.NodeName = inputs[0];
                if (inputs.Length == 2)
                {
                    nodeT.About = inputs[1];
                }
                else
                {
                    nodeT.ParentFieldName = inputs[1];
                    nodeT.About = inputs[2];
                }
                db.Insert(DbConstants.CategoryNodesColName, nodeT.ToBsonDocument());
            }

            // 插入文档
            inputs = new string[2];
            while ((input = Console.ReadLine()) != "zz")
            {
                inputs = input.Split();
                ObjectId obid = new ObjectId(inputs[1]);
                Document document = new Document(DateTime.Now.ToString("yyyy-MM-dd")+DateTime.Now.ToLongTimeString().ToString(), inputs[0], obid);
                db.Insert(DbConstants.DocumentColName, document.ToBsonDocument());
            }

        }
    }
}
