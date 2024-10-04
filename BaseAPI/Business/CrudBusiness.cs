using Business.Interface;
using DataModels.CrudDM;
using Model.Generic;
using Models.CrudModel;
using Repository.Interface;

namespace Business
{
    public class CrudBusiness : ICrudBusiness
    {
        private IGenericRepository<CrudModel> _repository;
        private Information information = new Information();

        public CrudBusiness(IGenericRepository<CrudModel> crudRepository)
        {
            _repository = crudRepository;
        }

        public async Task<ResultDM> Get(ResultDM result)
        {
            try
            {
                List<CrudModel> crud = await _repository.Get();

                if (crud.Count > 0)
                {
                    result.Res = crud;
                    result.Information = information.ResultInformation("CRUD", (int)EnumResultDM.EventCode.CodeGet, (int)EnumResultDM.StatusCode.StatusSuccess);

                }
                else
                {
                    result.Information = information.ResultInformation("Não foi encontrado nenhum CRUD no banco", (int)EnumResultDM.EventCode.CodeCustom, (int)EnumResultDM.StatusCode.StatusWarning);
                }
            }
            catch (Exception e)
            {
                result.Information = information.ResultInformation("CRUD", (int)EnumResultDM.EventCode.CodeSave, (int)EnumResultDM.StatusCode.StatusError);
                result.Res = e.Message;
            }


            return result;
        }

        public async Task<ResultDM> GetById(ResultDM result)
        {
            string id = (string)result.Req;

            try
            {

                CrudModel crud = await _repository.GetById(id);
                if (crud != null)
                {
                    result.Res = crud;
                }
                else
                {
                    result.Information = information.ResultInformation("Registro não encontrado", (int)EnumResultDM.EventCode.CodeCustom, (int)EnumResultDM.StatusCode.StatusWarning);
                }
            }
            catch (Exception e)
            {
                result.Information = information.ResultInformation("CRUD", (int)EnumResultDM.EventCode.CodeSave, (int)EnumResultDM.StatusCode.StatusError);
                result.Res = e.Message;
            }

            return result;
        }

        public async Task<ResultDM> RemoveById(ResultDM result)
        {
            string id = (string)result.Req;

            try
            {
                CrudModel crud = await _repository.GetById(id);
                if (crud != null)
                {
                    await _repository.RemoveById(id);
                    result.Res = "Removido";

                    result.Information = information.ResultInformation("CRUD", (int)EnumResultDM.EventCode.CodeRemove, (int)EnumResultDM.StatusCode.StatusSuccess);
                }
                else
                {
                    result.Information = information.ResultInformation("Registro não encontrado", (int)EnumResultDM.EventCode.CodeCustom, (int)EnumResultDM.StatusCode.StatusWarning);
                }

            }
            catch (Exception e)
            {
                result.Information = information.ResultInformation("CRUD", (int)EnumResultDM.EventCode.CodeSave, (int)EnumResultDM.StatusCode.StatusError);
                result.Res = e.Message;
            }

            return result;
        }

        public async Task<ResultDM> SendToSave(ResultDM result)
        {

            CrudDM crudIM = (CrudDM)result.Req;

            try
            {
                CrudModel crudOM = new CrudModel();

                if (!string.IsNullOrEmpty(crudIM.Id)) crudOM.Id = crudIM.Id;
                if (!string.IsNullOrEmpty(crudIM.Name)) crudOM.Name = crudIM.Name;


                result.Res = await _repository.Save(crudOM);
                result.Information = information.ResultInformation("CRUD", (int)EnumResultDM.EventCode.CodeSave, (int)EnumResultDM.StatusCode.StatusSuccess);

            }
            catch (Exception e)
            {
                result.Information = information.ResultInformation("CRUD", (int)EnumResultDM.EventCode.CodeSave, (int)EnumResultDM.StatusCode.StatusError);
                result.Res = e.Message;
            }

            return result;
        }
    }
}
