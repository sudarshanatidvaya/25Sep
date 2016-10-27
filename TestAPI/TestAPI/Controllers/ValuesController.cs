using AuradiesShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestAPI
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        [Route("GetAllNewsFeeds")]
        [AcceptVerbs("GET")]
        public HttpResponseMessage GetAllNewsFeeds()
        {
            //string errorDescription = "UserManagement Api: GetUserAuthenticationType Failed";

            try
            {
                //var val = new UserHandler().GetUserAuthenticationType();
                NewsFeedService service = new NewsFeedService();
                var result = service.GetActiveNewsFeeds();

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                //var errorResult = ResultGenerator.BuildResult(new UserResult() { ErrorCode = -1, ErrorDescription = errorDescription });

                //IoC.Logger.LogError("GetUserAuthenticationType Failed", ex);
                //return Request.CreateResponse(HttpStatusCode.NotAcceptable, errorResult);
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, new List<NewsFeed>());
            }
        }

        [Route("GetAllActiveCommentsById")]
        [AcceptVerbs("GET")]
        public HttpResponseMessage GetAllActiveCommentsById(int newsFeedID)
        {
            //string errorDescription = "UserManagement Api: GetUserAuthenticationType Failed";

            try
            {
                //var val = new UserHandler().GetUserAuthenticationType();
                NewsFeedService service = new NewsFeedService();
                var result = service.GetAllActiveCommentsById(newsFeedID);

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                //var errorResult = ResultGenerator.BuildResult(new UserResult() { ErrorCode = -1, ErrorDescription = errorDescription });

                //IoC.Logger.LogError("GetUserAuthenticationType Failed", ex);
                //return Request.CreateResponse(HttpStatusCode.NotAcceptable, errorResult);
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, new List<NewsFeedComment>());
            }
        }

        [Route("UpdateNewsFeedInactivityById")]
        [AcceptVerbs("POST")]
        public HttpResponseMessage UpdateNewsFeedInactivityById(int newsFeedID)
        {
            //string errorDescription = "UserManagement Api: GetUserAuthenticationType Failed";

            try
            {
                //var val = new UserHandler().GetUserAuthenticationType();
                NewsFeedService service = new NewsFeedService();
                service.UpdateNewsFeedInactivityById(newsFeedID);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                //var errorResult = ResultGenerator.BuildResult(new UserResult() { ErrorCode = -1, ErrorDescription = errorDescription });

                //IoC.Logger.LogError("GetUserAuthenticationType Failed", ex);
                //return Request.CreateResponse(HttpStatusCode.NotAcceptable, errorResult);
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }
        }

        [Route("GetAllActiveContacts")]
        [AcceptVerbs("GET")]
        public HttpResponseMessage GetAllActiveContacts()
        {
            //string errorDescription = "UserManagement Api: GetUserAuthenticationType Failed";
            try
            {
                //var val = new UserHandler().GetUserAuthenticationType();
                ContactService service = new ContactService();
                var result = service.GetAllActiveContacts();

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                //var errorResult = ResultGenerator.BuildResult(new UserResult() { ErrorCode = -1, ErrorDescription = errorDescription });

                //IoC.Logger.LogError("GetUserAuthenticationType Failed", ex);
                //return Request.CreateResponse(HttpStatusCode.NotAcceptable, errorResult);
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, new List<Contact>());
            }
        }

    }
}
