// Copyright (c) Florin Bobis. All Rights Reserved.

using CAEN.Api.Services;
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
        public IActionResult GetAll()
        {
            return Ok(caenService.GetAll());
        }

        [HttpGet("{sectionId}")]
        public IActionResult GetSectionCodes(string sectionId)
        {
            var result = caenService.GetSectionCodes(sectionId);
            if (result.Count == 0)
            {
               return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{sectionId}/{divisionId}")]
        public IActionResult GetDivisionCodes(string sectionId, string divisionId)
        {
            var result = caenService.GetDivisionCodes(sectionId, divisionId);
            if (result.Count == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{sectionId}/{divisionId}/{groupId}")]
        public IActionResult GetGroupCodes(string sectionId, string divisionId, string groupId)
        {
            var result = caenService.GetGroupCodes(sectionId, divisionId, groupId);
            if (result.Count == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
