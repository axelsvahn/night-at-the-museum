namespace museet
{
    ///<summary>
    ///Represents the museum visitor (can be extended with attacks unique to the hero, etc.)
    ///</summary>
    class Hero : Entity
    {
        public Hero(int hP, int mP, string name, bool isAlive)
        {
            HP = hP;
            MP = mP; 
            Name = name;
            this.IsAlive = isAlive;
        }
    }
}
