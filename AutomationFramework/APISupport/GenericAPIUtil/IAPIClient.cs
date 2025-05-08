using RestSharp;

namespace Automation_Framework.APISupport.GenericAPIUtil
{
    public interface IAPIClient
    {
        Task<RestResponse> CreateUser<T>(T payload) where T : class;
        Task<RestResponse> UpdateUser<T>(T Payload, string id) where T : class;
        Task<RestResponse> DeleteUser(string id);
        Task<RestResponse> GetUser(string id);
        Task<RestResponse> GetlistofUsers(int PageNumber);
    }
}
