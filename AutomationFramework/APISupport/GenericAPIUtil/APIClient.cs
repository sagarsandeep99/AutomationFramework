using RestSharp;

namespace Automation_Framework.APISupport.GenericAPIUtil
{
    public class APIClient : IAPIClient, IDisposable
    {

        readonly RestClient client;
        public APIClient(string baseUrl)
        {
            var options = new RestClientOptions(baseUrl);
            client = new RestClient(options);
        }

        public async Task<RestResponse> CreateUser<T>(T payload) where T : class
        {
            var request = new RestRequest(EndPoints.CREATE_USER, Method.Post);
            request.AddBody(payload);
            return await client.ExecuteAsync<T>(request);
        }

        public async Task<RestResponse> DeleteUser(string id)
        {
            var request = new RestRequest(EndPoints.DELETE_USER, Method.Delete);
            request.AddUrlSegment(id, id);
            return await client.ExecuteAsync(request);
        }

        public void Dispose()
        {
            client?.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<RestResponse> GetlistofUsers(int PageNumber)
        {
            var request = new RestRequest(EndPoints.GET_LIST_OF_USERS, Method.Get);
            request.AddQueryParameter("page", PageNumber);
            return await client.ExecuteAsync(request);
        }

        public async Task<RestResponse> GetUser(string id)
        {
            var request = new RestRequest(EndPoints.GET_SINGLE_USER, Method.Get);
            request.AddUrlSegment(id, id);
            return await client.ExecuteAsync(request);
        }

        public async Task<RestResponse> UpdateUser<T>(T Payload, string id) where T : class
        {
            var request = new RestRequest(EndPoints.UPDATE_USER, Method.Put);
            request.AddUrlSegment(id, id);
            request.AddBody(Payload);
            return await client.ExecuteAsync<T>(request);
        }


    }
}
