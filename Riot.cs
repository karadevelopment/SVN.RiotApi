using SVN.RiotApi.ApiEnums;
using SVN.RiotApi.ApiTransferObjects;
using SVN.Web.Request;
using System.Collections.Generic;
using System.Web;

namespace SVN.RiotApi
{
    public static class Riot
    {
        public static string GetProfileIconUrl(int id)
        {
            return string.Format(UrlSettings.Default.ProfileIcon, VersionSettings.Default.DDRAGON_ID, id);
        }

        public static string GetChampionSplashUrl(string name)
        {
            return string.Format(UrlSettings.Default.ChampionSplash, name);
        }

        public static string GetChampionSquareUrl(string name)
        {
            return string.Format(UrlSettings.Default.ChampionSquare, VersionSettings.Default.DDRAGON_ID, name);
        }

        public static string GetSpellUrl(string name)
        {
            return string.Format(UrlSettings.Default.Spell, VersionSettings.Default.DDRAGON_ID, name);
        }

        public static string GetItemUrl(int id)
        {
            return string.Format(UrlSettings.Default.Item, VersionSettings.Default.DDRAGON_ID, id);
        }

        public static string GetMasteryUrl(int id)
        {
            return string.Format(UrlSettings.Default.Mastery, VersionSettings.Default.DDRAGON_ID, id);
        }

        public static string GetRuneUrl(int id)
        {
            return string.Format(UrlSettings.Default.Rune, VersionSettings.Default.DDRAGON_ID, id);
        }

        public static SummonerDto GetSummonerByAccount(string apiKey, ServiceProxy platformId, string accountId)
        {
            var url = string.Format(UrlSettings.Default.SummonerByAccount, apiKey, platformId, accountId);
            RiotDispatcher.Sleep();

            var headers = new Dictionary<string, string>
            {
            };
            return Ajax.Get<SummonerDto>(url, headers);
        }

        public static SummonerDto GetSummonerByName(string apiKey, ServiceProxy platformId, string summonerName)
        {
            summonerName = HttpUtility.UrlPathEncode(summonerName);
            var url = string.Format(UrlSettings.Default.SummonerByName, apiKey, platformId, summonerName);
            RiotDispatcher.Sleep();

            var headers = new Dictionary<string, string>
            {
            };
            return Ajax.Get<SummonerDto>(url, headers);
        }

        public static MatchlistDto GetMatchlist(string apiKey, ServiceProxy platformId, string accountId, Champion champion = Champion.ALL, MathmakingQueue queue = MathmakingQueue.ALL, Season season = Season.ALL, long beginTime = default(long), long endTime =  default(long), int index = default(int))
        {
            var url = string.Format(UrlSettings.Default.Matchlist, apiKey, platformId, accountId);

            if (champion != Champion.ALL) url += $"&champion={(int)champion}";
            if (queue != MathmakingQueue.ALL) url += $"&queue={(int)queue}";
            if (season != Season.ALL) url += $"&season={(int)season}";
            if (endTime != default(long)) url += $"&endTime={endTime}";
            if (beginTime != default(long)) url += $"&beginTime={beginTime}";
            url += $"&endIndex={index + 100 - 1}";
            url += $"&beginIndex={index}";

            RiotDispatcher.Sleep();

            var headers = new Dictionary<string, string>
            {
            };
            return Ajax.Get<MatchlistDto>(url, headers);
        }

        public static MatchDto GetMatch(string apiKey, ServiceProxy platformId, long gameId)
        {
            var url = string.Format(UrlSettings.Default.Match, apiKey, platformId, gameId);
            RiotDispatcher.Sleep();

            var headers = new Dictionary<string, string>
            {
            };
            return Ajax.Get<MatchDto>(url, headers);
        }

        public static CurrentGameInfoDto GetCurrentGame(string apiKey, ServiceProxy platformId, string summonerName)
        {
            var summoner = Riot.GetSummonerByName(apiKey, platformId, summonerName);
            var url = string.Format(UrlSettings.Default.CurrentGame, apiKey, platformId, summoner.id);
            RiotDispatcher.Sleep();

            var headers = new Dictionary<string, string>
            {
            };
            return Ajax.Get<CurrentGameInfoDto>(url, headers);
        }
    }
}