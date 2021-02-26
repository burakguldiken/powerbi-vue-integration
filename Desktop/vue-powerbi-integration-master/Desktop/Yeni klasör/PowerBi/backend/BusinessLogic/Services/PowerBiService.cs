using BusinessLogic.Constant;
using BusinessLogic.IServices;
using Core.CustomEntity.Request;
using Core.CustomEntity.Response;
using Core.Model;
using Core.Result;
using Microsoft.Extensions.Configuration;
using Microsoft.PowerBI.Api.V2;
using Microsoft.PowerBI.Api.V2.Models;
using Microsoft.Rest;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace BusinessLogic.Services
{
    public class PowerBiService : IPowerBiService
    {
        IConfiguration _configuration;
        public PowerBiService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDataResult<GetReportInfoResponse> GetReportInfo(PowerBiReportRequest request)
        {
            var accessToken = GetReportAccessToken(request);

            if(accessToken == null)
            {
                return new ErrorDataResult<GetReportInfoResponse>(new GetReportInfoResponse(), Messages.Unauthorized);
            }

            GetReportInfoResponse response = new GetReportInfoResponse()
            {
                AccessToken = accessToken.EmbedToken.Token,
                EmbedUrl = accessToken.EmbedUrl,
                ReportId = request.ReportId
            };

            return new SuccessDataResult<GetReportInfoResponse>(response);

        }

        public PowerBIEmbedConfig GetReportAccessToken(PowerBiReportRequest request)
        {
            try
            {
                var result = new PowerBIEmbedConfig { Username = request.Username };
                var accessToken = GetPowerBIAccessToken(request.Username, request.Password);
                var tokenCredentials = new TokenCredentials(accessToken, "Bearer");

                using (var client = new PowerBIClient(new Uri("https://api.powerbi.com/"), tokenCredentials))
                {
                    var workspaceId = request.WorkspaceId;
                    var reportId = request.ReportId;
                    var report = client.Reports.GetReportInGroupAsync(workspaceId, reportId).Result;
                    var generateTokenRequestParameters = new GenerateTokenRequest(accessLevel: "view");
                    var tokenResponse = client.Reports.GenerateTokenAsync(workspaceId, reportId, generateTokenRequestParameters).Result;

                    result.EmbedToken = tokenResponse;
                    result.EmbedUrl = report.EmbedUrl;

                    return result;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string GetPowerBIAccessToken(string Username, string Password)
        {
            using (var client = new HttpClient())
            {
                var form = new Dictionary<string, string>();
                form["grant_type"] = "password";
                form["resource"] = _configuration.GetValue<string>("PowerBI:ResourceUrl");
                form["username"] = Username;
                form["password"] = Password;
                form["client_id"] = _configuration.GetValue<string>("PowerBI:ApplicationId");
                form["client_secret"] = _configuration.GetValue<string>("PowerBI:ApplicationSecret");
                form["scope"] = "openid";

                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");

                using (var formContent = new FormUrlEncodedContent(form))
                using (var response = client.PostAsync(_configuration.GetValue<string>("PowerBI:AuthorityUrl"), formContent).Result)
                {
                    var body = response.Content.ReadAsStringAsync().Result;
                    var jsonBody = JObject.Parse(body);

                    var errorToken = jsonBody.SelectToken("error");

                    if (errorToken != null)
                    {
                        throw new Exception(errorToken.Value<string>());
                    }

                    return jsonBody.SelectToken("access_token").Value<string>();
                }
            }
        }
    }
}
