using System.Collections.Generic;

namespace SVN.RiotApi.ApiTransferObjects
{
    public class CurrentGameParticipantDto
    {
        public long profileIconId { get; set; }
        public long championId { get; set; }
        public string summonerName { get; set; }
        public List<GameCustomizationObjectDto> gameCustomizationObjects { get; set; }
        public bool bot { get; set; }
        public PerkDto perks { get; set; }
        public long spell2Id { get; set; }
        public long teamId { get; set; }
        public long spell1Id { get; set; }
        public string summonerId { get; set; }
    }
}