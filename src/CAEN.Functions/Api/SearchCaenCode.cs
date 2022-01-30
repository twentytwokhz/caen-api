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
    public class SearchCaenCode
    {
        private readonly ICaenService caenService;

        public SearchCaenCode(ICaenService caenService)
        {
            this.caenService = caenService;
        }

        [Function("search/{searchQuery}")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req,
            string searchQuery)
        {
            HttpResponseData response = req.CreateResponse();
            response.Headers.Add("Content-Type", "application/json; charset=utf-8");

            var result = caenService.SearchCode(searchQuery);
            if (result.Count == 0)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                return response;
            }

            response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync<List<Section>>(result);

            return response;
        }
    }
}
