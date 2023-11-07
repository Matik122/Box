namespace States
{
    public interface IGameState
    {
        void Init(object data);
        void Deinit();
    }
    
    public abstract class GameStateBase<T> : IGameState where T : class
    {
        void IGameState.Init(object data)
        {
            Init(data as T);
        }

        void IGameState.Deinit()
        {
            Deinit();
        }

        protected abstract void Init(T model);
        protected abstract void Deinit();
    }
}