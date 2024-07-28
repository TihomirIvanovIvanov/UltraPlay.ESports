namespace UltraPlay.ESports.Data.Models.Enums
{
    public enum MatchType
    {
        None = 0,

        //  open for betting before the start date of a match
        Prematch = 1,

        // open for betting after the start date of a match 
        Live = 2,

        // bet which indicates final winner in event e.g. Premier League or Wimbledon
        Outright = 3,
    }
}
