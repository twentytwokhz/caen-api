// Copyright (c) Florin Bobis. All Rights Reserved.

using CAEN.Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace CAEN.Api.Controllers
{
    [ApiController]
    [Route("api/caen")]
    [Produces("application/json")]
    public class CaenController : ControllerBase
    {
        private readonly ICaenService caenService;

        public CaenController(ICaenService caenService)
        {
            this.caenService = caenService;
        }

        [HttpGet("search/{query}")]
        public IActionResult SearchCodes(string query)
        {
            var result = caenService.SearchCode(query);
            if (result.Count == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{sectionId?}/{divisionId?}/{groupId?}")]
        public IActionResult GetCodesByFilter(string sectionId, string divisionId, string groupId)
        {
            var result = caenService.GetCodesByFilter(sectionId, divisionId, groupId);
            if (result.Count == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
