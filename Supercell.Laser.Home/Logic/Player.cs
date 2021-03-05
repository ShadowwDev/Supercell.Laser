namespace Supercell.Laser.Home.Logic
{
    using Newtonsoft.Json;

    class Player
    {
        [JsonProperty] internal int m_highID;
        [JsonProperty] internal int m_lowID;
        [JsonProperty] internal string m_token;

        [JsonProperty] internal int m_score;
        [JsonProperty] internal int m_diamonds;
        [JsonProperty] internal int m_upgradium;
        [JsonProperty] internal int m_bolts;

        [JsonProperty] internal string m_name = string.Empty;
        [JsonProperty] internal bool m_nameSetByUser;
    }
}
