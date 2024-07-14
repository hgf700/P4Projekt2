
//using Refit;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace P4Projekt2.API.User
//{
//    public interface IUserApi
//    {
//        [Get("/users/{email}")]
//        Task<UserInfo> GetUserInfo(string email, [Header("Authorization")] string authorization);

//        [Post("/users")]
//        Task<ApiResponse<DtoUserInfo>> CreateUser(
//            DtoUserInfo userInfo,
//            [Header("Authorization")] string authorization
//        );
//    }
//}
