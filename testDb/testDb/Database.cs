using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.ServiceProcess;

namespace testDb
{
    class Database
    {
        // 数据库服务控制
        private static ServiceController DbServiceController;

        // 数据库
        private IMongoClient _client;
        private IMongoDatabase _database;

        // 启动数据库服务
        public static void StartDbService()
        {
            if (DbServiceController == null)
            {
                DbServiceController = new System.ServiceProcess.ServiceController(DbConstants.DbServiceName);
            }
            ServiceControllerStatus st = DbServiceController.Status;
            if (st == ServiceControllerStatus.Stopped)
            {
                DbServiceController.Start();
            }
        }

        // 关闭数据库服务
        public static void StopDbService()
        {
            if (DbServiceController == null)
            {
                DbServiceController = new System.ServiceProcess.ServiceController(DbConstants.DbServiceName);
            }
            ServiceControllerStatus st = DbServiceController.Status;
            if (st == ServiceControllerStatus.Running)
            {
                DbServiceController.Stop();
            }
        }

        // 设置并连接数据库
        public Database(string dbName)
        {
            if (_client == null)
            {
                _client = new MongoClient("mongodb://localhost:27017");
                _database = _client.GetDatabase(dbName);
            }
        }

        // 插入数据库
        public void Insert(string collectionName, BsonDocument doc)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            collection.InsertOne(doc);
        }

        // 查询数据库中某个collection的所有内容，返回list<bsondocument>
        public List<BsonDocument> Find(string collectionName)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            var documents = collection.Find(new BsonDocument()).ToListAsync().Result;
            return documents;
        }

        // 更新数据库中某个collection
        public void UpdateDocuments<T>(string collectionName, string field, T newValue)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            var update = Builders<BsonDocument>.Update.Set(field, newValue);
            collection.UpdateMany(new BsonDocument(), update);
        }


        // 删除数据库中collection中的记录
        public void DeleteDocuments<T>(string collectionName, string field, T value)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            var filter = Builders<BsonDocument>.Filter.Eq(field, value);
            collection.DeleteMany(filter);
        }
    }
}
