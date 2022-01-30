// Copyright (c) Florin Bobis. All Rights Reserved.

using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using CAEN.Library.Models;
using CAEN.Library.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace CAEN.Functions.Api
{
    public class GetCaenCodes
    {
        private readonly ICaenService caenService;

        public GetCaenCodes(ICaenService caenService)
        {
            this.caenService = caenService;
        }

        [Function("caen/{sectionId?}/{divisionId?}/{groupId?}")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req,
            string sectionId, string divisionId, string groupId)
        {
            HttpResponseData response = req.CreateResponse();
            response.Headers.Add("Content-Type", "application/json; charset=utf-8");

            var result = caenService.GetCodesByFilter(sectionId, divisionId, groupId);
            if (result.Count == 0)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                return response;
            }

            response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync<List<CaenCode>>(result);

            return response;
        }
    }
}
