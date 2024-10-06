using Controllers;
using Microsoft.AspNetCore.Mvc;
using Models.CrudModel;
using Repository.Interface;
using Repository.Generic;
using Mongo.Services;
using BaseAPI.Infrastructure;
using Microsoft.Extensions.Options;
using Business.Interface;
using Business;
using Model.Generic;

namespace Tests
{
    public class UserCrudTests
    {
        private CrudController _crud;
        public UserCrudTests()
        {
            
            _crud = TestCommon.GetCrudController();
        }

        [Fact]
        public async void UsersGetWithSuccess()
        {

            IActionResult resultado = await _crud.Get();

            bool requestIsOk = (resultado.GetType() == typeof(OkObjectResult));
            Assert.True(requestIsOk);

            if(requestIsOk)
            {
                // TODO: repense nomes de variáveis 
                var resultObj = (OkObjectResult)resultado;
                Assert.Equal(resultObj.StatusCode, 200);

                ResultDM resultValue = (ResultDM)(resultObj.Value ?? new ResultDM());
                List<CrudModel> data = (List<CrudModel>)resultValue.Res;

                Assert.True(data.Count > 0);
            }




        }
    }
}