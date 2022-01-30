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

        [HttpGet()]
        public IActionResult GetAllCodes()
        {
            var result = caenService.GetCodesByFilter();
            if (result.Count == 0)
            {
                return NotFound();
            }
            return Ok(result);
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

        [HttpGet("{sectionId}")]
        public IActionResult GetCodesBySection(string sectionId)
        {
            var result = caenService.GetCodesByFilter(sectionId);
            if (result.Count == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{sectionId}/{divisionId}")]
        public IActionResult GetCodesByDivision(string sectionId, string divisionId)
        {
            var result = caenService.GetCodesByFilter(sectionId, divisionId);
            if (result.Count == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{sectionId}/{divisionId}/{groupId}")]
        public IActionResult GetCodesByGroup(string sectionId, string divisionId, string groupId)
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
