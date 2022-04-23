namespace Kolpi.ApplicationCore.Entities
{
    public class Reputation : EditBase<int>
    {
        public int TotalScore { get; set; }
        public int OutstandingBadges  { get; set; }
        public byte[] OutstandingBadgesIcon  { get; set; }
        public int ExcellentBadges  { get; set; }
        public byte[] ExcellentBadgesIcon  { get; set; }
        public int VeryGoodBadges  { get; set; }
        public byte[] VeryGoodBadgesIcon  { get; set; }
        public int GoodBadges { get; set; }
        public byte[] GoodBadgesIcon { get; set; }

    }
}
