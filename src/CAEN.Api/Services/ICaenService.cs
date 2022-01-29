// Copyright (c) Florin Bobis. All Rights Reserved.

using System.Collections.Generic;
using CAEN.Api.Models;

namespace CAEN.Api.Services
{
    public interface ICaenService
    {
        List<CaenCode> GetAll();
        List<CaenCode> GetSectionCodes(string sectionId);
        List<CaenCode> GetDivisionCodes(string sectionId, string divisionId);
        List<CaenCode> GetGroupCodes(string sectionId, string divisionId, string groupId);
    }
}
