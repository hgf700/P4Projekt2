//using Refit;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace P4Projekt2.API.User
//{
//    public interface InterfaceUser
//    {
//        [Get("/users/{email}")]
//        Task<UserInfo> GetUserInfo(string email, [Header("Authorization")] string authorization);

//        [Post("/users")]
//        Task<ApiResponse<UserData>> CreateUser(
//            UserData userdata,
//            [Header("Authorization")] string authorization
//        );
//    }
//}
