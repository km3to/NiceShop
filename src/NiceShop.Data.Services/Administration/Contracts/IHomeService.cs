using NiceShop.Web.Models.Administration.ViewModels;

namespace NiceShop.Data.Services.Administration.Contracts
{
    public interface IHomeService
    {
        IndexViewModel GetIndexModel();

        IndexViewModel GetIndexModelForShop(string id);

        IndexViewModel GetIndexModelForCategory(string id);
    }
}