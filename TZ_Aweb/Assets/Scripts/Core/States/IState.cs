namespace Core.States
{
    public interface IState : IExitableState
    {
        void Enter();
    }

    public interface IExitableState
    {
        void Exit();
    }

    public interface IPayloadedState<in TPayload> : IExitableState
    {
        public void Enter(TPayload payload);
    }
}