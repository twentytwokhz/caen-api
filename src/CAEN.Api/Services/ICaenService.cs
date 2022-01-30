// Copyright (c) Florin Bobis. All Rights Reserved.

using System.Collections.Generic;
using CAEN.Api.Models;

namespace CAEN.Api.Services
{
    public interface ICaenService
    {
        List<CaenCode> GetCodesByFilter(string sectionId = null, string divisionId = null, string groupId = null);
        List<Section> SearchCode(string query);
    }
}
