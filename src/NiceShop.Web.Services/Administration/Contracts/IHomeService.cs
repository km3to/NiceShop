using NiceShop.ViewModels.Administration.ViewModels;

namespace NiceShop.Web.Services.Administration.Contracts
{
    public interface IHomeService
    {
        IndexViewModel GetIndexModel();

        IndexViewModel GetIndexModelForShop(string id);

        IndexViewModel GetIndexModelForCategory(string id);
    }
}