namespace Ucu.Poo.RoleplayGame;

public abstract class Character : ICharacter
{
    private int health = 100;
    private List<IItem> items = new List<IItem>();

    public Character(string name)
    {
        this.Name = name;
    }

    public string Name { get; set; }

    public virtual int AttackValue
    {
        get
        {
            int value = 0;
            foreach (IItem item in this.items)
            {
                if (item is IAttackItem attackItem)
                {
                    value += attackItem.AttackValue;
                }
            }
            return value;
        }
    }

    public virtual int DefenseValue
    {
        get
        {
            int value = 0;
            foreach (IItem item in this.items)
            {
                if (item is IDefenseItem defenseItem)
                {
                    value += defenseItem.DefenseValue;
                }
            }
            return value;
        }
    }

    public int Health
    {
        get => this.health;
        protected set => this.health = value < 0 ? 0 : value;
    }

    public virtual void ReceiveAttack(int power)
    {
        if (this.DefenseValue < power)
        {
            this.Health -= power - this.DefenseValue;
        }
    }

    public virtual void Cure()
    {
        this.Health = 100;
    }

    public void AddItem(IItem item)
    {
        this.items.Add(item);
    }

    public void RemoveItem(IItem item)
    {
        this.items.Remove(item);
    }
}

