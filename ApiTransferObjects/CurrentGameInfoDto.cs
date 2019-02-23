using System.Collections.Generic;

namespace SVN.RiotApi.ApiTransferObjects
{
    public class CurrentGameInfoDto
    {
        public long gameId { get; set; }
        public long gameStartTime { get; set; }
        public string platformId { get; set; }
        public string gameMode { get; set; }
        public long mapId { get; set; }
        public string gameType { get; set; }
        public List<BannedChampionDto> bannedChampions { get; set; }
        public ObserverDto observers { get; set; }
        public List<CurrentGameParticipantDto> participants { get; set; }
        public long gameLength { get; set; }
        public long gameQueueConfigId { get; set; }
    }
}