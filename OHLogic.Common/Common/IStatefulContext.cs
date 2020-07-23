namespace Assets.Common
{
    public interface IStatefulContext
    {
        IState CurrentState { get; }

        bool IsInState(IState state);
        void ChangeState(IState callingState, IState newState);
        void RegisterState(IState state);
        T GetState<T>() where T : IState;
    }
}
