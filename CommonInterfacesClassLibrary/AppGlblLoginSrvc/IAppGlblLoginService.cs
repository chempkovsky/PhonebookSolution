using System.Threading.Tasks;
using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonInterfacesClassLibrary.Interfaces;


namespace CommonInterfacesClassLibrary.AppGlblLoginSrvc {
    public interface IAppGlblLoginService
    {
        Task<IBearerTokenModel> Login(string Email, string Password);
        Task<IRegisterModel> Register(string Email, string Password, string ConfirmPassword);
        Task<bool> Logout();
        Task<IChangePasswordModel> ChangePassword(string OldPassword, string NewPassword, string ConfirmPassword);
        IChangePasswordModel GetChangePasswordModel(string OldPassword, string NewPassword, string ConfirmPassword);
        IRegisterModel GetRegisterModel(string Email, string Password, string ConfirmPassword);
    }
}

