// Copyright (c) Florin Bobis. All Rights Reserved.

using CAEN.Library.Models;

namespace CAEN.Library.Services
{
    public interface ICaenService
    {
        /// <summary>
        /// Aduce codurile caen in functie
        /// de parametrii oferiti
        /// </summary>
        /// <param name="sectionId"></param>
        /// <param name="divisionId"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        List<CaenCode> GetCodesByFilter(string sectionId, string divisionId, string groupId);
        /// <summary>
        /// Cauta coduri caen corespunzatoare
        /// criteriului de cautare
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        List<CaenCode> SearchCode(string query);
    }
}
