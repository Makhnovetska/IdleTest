namespace Utils
{
    public class StateMachine<T>
    {
        public State<T> current { get; private set; }
        
        public StateMachine(State<T> initialState)
        {
            current = initialState;
            current.OnEnter();
        }
        
        public void Update()
        {
            current?.OnUpdate();
        }
        
        public void ChangeState(State<T> newState)
        {
            current?.OnExit();
            current = newState;
            current.OnEnter();
        }
    }
}