using System.Collections.Generic;

namespace SVN.RiotApi.ApiTransferObjects
{
    public class PerkDto
    {
        public long perkStyle { get; set; }
        public List<long> perkIds { get; set; }
        public long perkSubStyle { get; set; }
    }
}