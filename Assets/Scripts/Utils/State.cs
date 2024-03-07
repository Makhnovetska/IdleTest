namespace Utils
{
    public abstract class State<T>
    {
        protected T _owner;

        protected State(T owner) => _owner = owner;
        public abstract void OnEnter();
        public abstract void OnExit();
        public abstract void OnUpdate();
    }
}