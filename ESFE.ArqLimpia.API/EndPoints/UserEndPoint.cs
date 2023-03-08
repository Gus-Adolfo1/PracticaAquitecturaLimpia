using ESFE.ArqLimpia.BL.DTOs.UserDTOs;
using ESFE.ArqLimpia.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ESFE.ArqLimpia.API.EndPoints
{
    public static class UserEndPoint
    {
        public static void AddUserEndPoints(this WebApplication app)
        {
            app.MapPost("/user/create", async (IUserBL userBL,[FromBody] CreateUserInputDTO user) => {
                return await userBL.Create(user);
            });
            app.MapPost("/user/edit", async (IUserBL userBL, [FromBody] UpdateUserDTO user) => {
                return await userBL.Update(user);
            });
            app.MapPost("/user/delete", async (IUserBL userBL, [FromBody] DeleteUserDTO user) => {
                return await userBL.Delete(user);
            });
            app.MapPost("/user/getbyid", async (IUserBL userBL, [FromBody] GetByIdUserInputDTO user) => {
                return await userBL.GetById(user);
            });
            app.MapPost("/user/search", async (IUserBL userBL, [FromBody] SearchUserInputDTO user) => {
                return await userBL.Search(user);
            });
        }
    }
}
