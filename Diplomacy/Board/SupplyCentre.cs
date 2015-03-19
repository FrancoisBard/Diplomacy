namespace Diplomacy.Board
{
    class SupplyCentre
    {
        public Province Province { get; set; }

        public Force? Owner { get; set; }

        public SupplyCentre(Province province, Force? owner = null)
        {
            Province = province;
            Owner = owner;

            Province.SupplyCentre = this;
        }
    }
}