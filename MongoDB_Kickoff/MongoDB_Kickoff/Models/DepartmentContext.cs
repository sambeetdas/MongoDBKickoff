using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MongoDB_Kickoff.Models;

namespace MongoDB_Kickoff.Models
{
    //Mongo DB Context Class
    public class DepartmentContext
    {
        private MongoDatabase database;
        private string servername = "localhost";
        private int port = 27017;
        public DepartmentContext()
        {
            MongoClientSettings setting = new MongoClientSettings();
            setting.Server = new MongoServerAddress(servername, port);
            MongoClient client = new MongoClient(setting);
            var server = client.GetServer();
            this.database = server.GetDatabase("MongoDepartment");
        }
        public MongoCollection<Department> Departments
        {
            get
            {
               return database.GetCollection<Department>("Department");
            }
        }

    }
}