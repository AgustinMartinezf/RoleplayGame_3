namespace Ucu.Poo.RoleplayGame;

public class Wizard : Hero, IMagicCharacter
{
    private List<IMagicalItem> magicalItems = new List<IMagicalItem>();

    public Wizard(string name) : base(name)
    {
        this.AddItem(new Staff());
    }

    public override int AttackValue
    {
        get
        {
            int value = base.AttackValue;
            foreach (IMagicalItem item in this.magicalItems)
            {
                if (item is IMagicalAttackItem attackItem)
                {
                    value += attackItem.AttackValue;
                }
            }
            return value;
        }
    }

    public override int DefenseValue
    {
        get
        {
            int value = base.DefenseValue;
            foreach (IMagicalItem item in this.magicalItems)
            {
                if (item is IMagicalDefenseItem defenseItem)
                {
                    value += defenseItem.DefenseValue;
                }
            }
            return value;
        }
    }

    public void AddItem(IMagicalItem item)
    {
        this.magicalItems.Add(item);
    }

    public void RemoveItem(IMagicalItem item)
    {
        this.magicalItems.Remove(item);
    }
}