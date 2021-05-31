namespace museet
{
    ///<summary>
    ///Represents the boss of the museum (can be extended with attacks unique to bosses, etc.)
    ///</summary>
    class Boss : Entity
    {
        public Boss(int hP, int mP, string name, bool isAlive)
        {
            HP = hP;
            MP = mP;
            Name = name;
            this.IsAlive = isAlive;
        }
    }
}
