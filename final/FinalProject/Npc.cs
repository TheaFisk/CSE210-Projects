

    // NPC class inheriting from Character
    public class NPC : Character
    {
        private string dialogue;
        private bool canBefriend;

        public NPC(string name, int health, string dialogue, bool canBefriend = false) : base(name, health)
        {
            this.dialogue = dialogue;
            this.canBefriend = canBefriend;
        }

        public bool CanBefriend { get { return canBefriend; } }

        public override string GetDescription()
        {
            return $"{name} - {dialogue}";
        }

        public string Speak()
        {
            return dialogue;
        }
    }