// Copyright (c) Florin Bobis. All Rights Reserved.

using CAEN.Library.Models;

namespace CAEN.Library.Services
{
    public interface ICaenService
    {
        List<CaenCode> GetCodesByFilter(string sectionId = null, string divisionId = null, string groupId = null);
        List<Section> SearchCode(string query);
    }
}
