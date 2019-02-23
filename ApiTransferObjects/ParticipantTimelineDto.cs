using System.Collections.Generic;

namespace SVN.RiotApi.ApiTransferObjects
{
    public class ParticipantTimelineDto
    {
        public string lane { get; set; }
        public int participantId { get; set; }
        public Dictionary<string, double> csDiffPerMinDeltas { get; set; }
        public Dictionary<string, double> goldPerMinDeltas { get; set; }
        public Dictionary<string, double> xpDiffPerMinDeltas { get; set; }
        public Dictionary<string, double> creepsPerMinDeltas { get; set; }
        public Dictionary<string, double> xpPerMinDeltas { get; set; }
        public string role { get; set; }
        public Dictionary<string, double> damageTakenDiffPerMinDeltas { get; set; }
        public Dictionary<string, double> damageTakenPerMinDeltas { get; set; }
    }
}