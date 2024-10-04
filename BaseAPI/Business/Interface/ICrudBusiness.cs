using Model.Generic;

namespace Business.Interface
{
    public interface ICrudBusiness
    {
        Task<ResultDM> Get(ResultDM result);
        Task<ResultDM> GetById(ResultDM result);
        Task<ResultDM> RemoveById(ResultDM result);
        Task<ResultDM> SendToSave(ResultDM result);
    }
}
