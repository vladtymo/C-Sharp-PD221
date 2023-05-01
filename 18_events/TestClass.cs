namespace _18_events
{
    class TestClass
    {
        List<Action> Actions = new List<Action>();

        public event Action TestEvent
        {
            // subscribe [+=]
            add
            {
                // additional logic
                if (!this.Actions.Contains(value))
                    this.Actions.Add(value);
            }
            // unsubscribe [-=]
            remove
            {
                this.Actions.Remove(value);
            }
        }

        public void Notify()
        {
            foreach (var item in Actions)
            {
                item?.Invoke();
            }
        }
    }
}
