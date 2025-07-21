

    // Choice class for managing decision points
    public class Choice
    {
        private string description;
        private Action consequence;

        public Choice(string description, Action consequence)
        {
            this.description = description;
            this.consequence = consequence;
        }

        public string Description { get { return description; } }

        public void Execute()
        {
            consequence?.Invoke();
        }
    }