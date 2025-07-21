// Base class demonstrating abstraction and polymorphism
    public abstract class Character
    {
        protected string name;
        protected int health;
        protected bool isAlive;

        public Character(string name, int health)
        {
            this.name = name;
            this.health = health;
            this.isAlive = true;
        }

        public string Name { get { return name; } }
        public int Health { get { return health; } }
        public bool IsAlive { get { return isAlive; } }

        // Abstract method for polymorphism
        public abstract string GetDescription();
        
        // Virtual method that can be overridden
        public virtual void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                health = 0;
                isAlive = false;
            }
        }

        // Protected method demonstrating encapsulation
        protected void SetHealth(int newHealth)
        {
            health = newHealth;
        }
    }