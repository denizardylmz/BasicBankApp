using D.BankApp.Web.Controllers;
using D.BankApp.Web.Datas.Entities;
using D.BankApp.Web.Models;
using D.BankApp.Web.Repositories;

namespace D.BankApp.Web.Mapping;

public class UserMapper : IUserMapper
{
    public List<UserListModel> MapToListOfUserList(List<ApplicationUser> user)
    {
        return user.Select(x => new UserListModel()
        {
            Id = x.Id,
            Name = x.Name,
            Surname = x.Surname
        }).ToList();
    }

    public UserListModel MapToUserList(ApplicationUser user)
    {
        return new UserListModel()
        {
            Id = user.Id,
            Name = user.Name,
            Surname = user.Surname
        };
    }

    public UserDetailModel MapToUserDetailModel(ApplicationUser user)
    {
        return new UserDetailModel()
        {
            Id = user.Id,
            Name = user.Name,
            Surname = user.Surname,
            Accounts = user.Accounts
        };
    }

    public ApplicationUser MapCreateModelToApplicationUser(UserCreateModel model)
    {
        return new ApplicationUser()
        {
            Id = new Guid(),
            Name = model.Name,
            Surname = model.Surname,
        };
    }
    
}