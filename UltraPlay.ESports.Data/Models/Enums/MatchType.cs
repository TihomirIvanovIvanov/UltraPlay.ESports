namespace UltraPlay.ESports.Data.Models.Enums
{
    public enum MatchType
    {
        None,
        PreMatch, // open for betting before the start date of a match
        Live, // open for betting after the start date of a match 
        OutRight, // bet which indicates final winner in event e.g. Premier League or Wimbledon
    }
}
