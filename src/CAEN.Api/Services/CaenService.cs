// Copyright (c) Florin Bobis. All Rights Reserved.

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using CAEN.Api.Models;
using Microsoft.Extensions.Logging;

namespace CAEN.Api.Services
{
    public class CaenService : ICaenService
    {
        private readonly JsonDocument caenStore;
        private readonly List<Section> list;
        private const string storePath = "Store\\caen.json";

        public CaenService()
        {
            caenStore = JsonDocument.Parse(File.ReadAllText(storePath));
            list = caenStore.Deserialize<List<Section>>();
        }

        public List<CaenCode> GetAll()
        {
            var result = (from section in list
                          from division in section.Divisions
                          from gr in division.Groups
                          from code in gr.Codes
                          select code).ToList();
            return result;
        }
        public List<CaenCode> GetSectionCodes(string sectionId)
        {
            var result = (from section in list
                          from division in section.Divisions
                          from gr in division.Groups
                          from code in gr.Codes
                          where section.ID.ToLower() == sectionId.ToLower()
                          select code).ToList();
            return result;
        }

        public List<CaenCode> GetDivisionCodes(string sectionId, string divisionId)
        {
            var result = (from section in list
                          from division in section.Divisions
                          from gr in division.Groups
                          from code in gr.Codes
                          where section.ID.ToLower() == sectionId.ToLower()
                                && division.ID.ToLower() == divisionId.ToLower()
                          select code).ToList();
            return result;
        }

        public List<CaenCode> GetGroupCodes(string sectionId, string divisionId, string groupId)
        {
            var result = (from section in list
                          from division in section.Divisions
                          from gr in division.Groups
                          from code in gr.Codes
                          where section.ID.ToLower() == sectionId.ToLower()
                                && division.ID.ToLower() == divisionId.ToLower()
                                && gr.ID.ToLower() == groupId.ToLower()
                          select code).ToList();
            return result;
        }
    }
}
