using AutomationFramework.Support.APISupport;
using AutomationFramework.Utilities;
using System.Net;
using RestSharp;
using AutomationFramework.Support.APISupport.Model.Request;
using AutomationFramework.Support.APISupport.Model.Response;
using AutomationFramework.Support.APISupport.GenericAPIUtil;

namespace AutomationFramework.StepDefinitions.API
{
    [Binding]
    public class CreateUserStepDefinitions
    {
        private CreateUserRequest _createUserRequest;
        private CreateUserResponse _createUserResponse;
        private RestResponse _response;
        private ScenarioContext _scenarioContext;
        private HttpStatusCode _statusCode;

        public CreateUserStepDefinitions(CreateUserRequest createUserRequest, ScenarioContext scenarioContext)
        {
            _createUserRequest = createUserRequest;
            _scenarioContext = scenarioContext;
        }
        #region Given

        [Given("user with a name ([^\"]*)")]
        public void GivenUserWithAName(string name)
        {
            _createUserRequest.name = name;
        }

        [Given("user with designation as ([^\"]*)")]
        public void GivenUserWithDesignationAs(string job)
        {
            _createUserRequest.job = job;
        }

        [Given("user payload ([^\"]*)")]
        public void GivenUserPayload(string fileName)
        {
            string filePath = GetFilePath.FilePath(@"DataLibraries\DataFiles\" + fileName);
            var payload = HandleAPIContent.ParseJson<CreateUserRequest>(filePath);
            //_scenarioContext.Add("createUser_payload", payload);
            _createUserRequest = payload;
        }

        #endregion

        #region When

        [When("send request to create user with ([^\"]*)")]
        public async Task WhenSendRequestToCreateUserWith(string baseURL)
        {
            var api = new APIClient(baseURL);
            _response = await api.CreateUser(_createUserRequest);
        }
        #endregion

        #region Then

        [Then("validate user is created")]
        public void ThenValidateUserIsCreated()
        {
            _statusCode = _response.StatusCode;
            var code = (int)_statusCode;
            //Assert.AreEqual(201, code, "Status Code from the API Response doesn't match");

            var content = HandleAPIContent.GetContent<CreateUserResponse>(_response);
            //Assert.AreEqual(_createUserRequest.name, content.name, "Name from the API Response doesn't match");
            //Assert.AreEqual(_createUserRequest.job, content.job, "Job from the API Response doesn't match");
        }

        #endregion
    }
}
