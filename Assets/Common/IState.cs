namespace Assets.Common
{
    public interface IState
    {
        void Enter();
        void Proceed();
        void Exit();
    }
}
