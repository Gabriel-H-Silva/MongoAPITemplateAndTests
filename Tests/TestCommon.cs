using Business;
using Business.Interface;
using Controllers;
using Models.CrudModel;
using Mongo.Services;
using Repository.Generic;
using Repository.Interface;

namespace Tests
{
    public abstract class TestCommon
    {
        public static IGenericRepository<CrudModel> GetRepository()
        {
            string connectionURI = "mongodb+srv://GabrielAdmin:Gaheri876@ambienteteste.8l0sd9b.mongodb.net/?authSource=admin&appName=AmbienteTeste";
            string databaseName = "TasksManager";

            MongoDBService dbService = new MongoDBService(connectionURI, databaseName);

            return new GenericRepository<CrudModel>(dbService);            
        }

        public static ICrudBusiness GetBusiness()
        {
            return new CrudBusiness(GetRepository());

        }

        public static CrudController GetCrudController()
        {
            return new CrudController(GetBusiness());

        }
    }
}
