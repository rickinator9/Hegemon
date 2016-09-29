using Assets.Source.Contexts.GameContext.Model.Dates;

namespace Assets.Source.Contexts.GameContext.Model.Political.Diplomacy
{
    public interface ITreaty
    {
        IDate Date { get; set; }

        string Name { get; set; }

        IPoliticalEntity[] Signatories { get; }

        ITreatyTerm[] Terms { get; }

        void AddSignatory(IPoliticalEntity signatory);

        void RemoveSignatory(IPoliticalEntity signatory);
    }
}