﻿namespace Assets.Source.Contexts.GameContext.Model.Political.Diplomacy
{
    public interface ITreaty
    {
        IPoliticalEntity[] Signatories { get; set; }
    }
}