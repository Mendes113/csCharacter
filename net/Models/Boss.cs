namespace net.Models
{
    public class Boss
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int AttackStrength { get; set; }

        public Boss(string name, int hitPoints, int attackStrength)
        {
            Name = name;
            HitPoints = hitPoints;
            AttackStrength = attackStrength;
        }
    }
}
