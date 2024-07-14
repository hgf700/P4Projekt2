using Refit;
using P4Projekt2.API.User;

namespace P4Projekt2.API.Authorization
{
    public interface IAuth
    {
        [Headers("Content-Type: application/x-www-form-urlencoded")]
        [Post("/connect/token")]
        Task<ApiResponse<AuthTokenResponse>> Execute(
            [Body(BodySerializationMethod.UrlEncoded)] AuthTokenRequest config
        );

        [Post("/connect/token/user/register")]
        Task<ApiResponse<string>> CreateNewIdentity([Body] IdentityUserInfo config);
    }
}
