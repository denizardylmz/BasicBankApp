using D.BankApp.Web.Datas.Entities;
using D.BankApp.Web.Models;

namespace D.BankApp.Web.Repositories;

public interface IUserMapper
{
    public List<UserListModel> MapToListOfUserList(List<ApplicationUser> user);
    public UserListModel MapToUserList(ApplicationUser user);
    public UserDetailModel MapToUserDetailModel(ApplicationUser user);
    public ApplicationUser MapCreateModelToApplicationUser(UserCreateModel model);
}