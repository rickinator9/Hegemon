using System;

namespace Assets.Source.Contexts.GameContext.Model.Characters
{
    public class Zygote : IZygote
    {
        const float TwinsChance = 1/333;
        const float TripletsChance = 1/10000f;

        public Zygote()
        {
            var random = new Random();
            var genderChance = random.NextDouble();
            Gender = genderChance > 0.5f ? Gender.Male : Gender.Female;

            var multiplesChance = random.NextDouble();
            if (multiplesChance < TwinsChance)
            {
                Fetuses = multiplesChance < TripletsChance ? 3 : 2;
            }
            else
                Fetuses = 1;
        }

        public Gender Gender { get; private set; }
        public int Fetuses { get; private set; }
    }
}