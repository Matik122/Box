using System;
using Support;
using UniRx;

namespace States
{
    public class LobbyState : GameStateBase<LobbyState.Model>
    {
        //Leave for continious DI
        public class Model
        {
        
        }
    
        private readonly CompositeDisposable _rootDisposable = new();
    
        private const string StateSceneName = "Lobby";

        //Leave for continious DI
        public LobbyState()
        {
        
        }
    
        protected override void Init(Model model)
        {
            SceneExtensions.LoadScene(StateSceneName)
                .SafeSubscribe(_ => OnSceneLoaded())
                .AddTo(_rootDisposable);
        }

        private void OnSceneLoaded()
        {
            InitControllers()
                .AddTo(_rootDisposable);
        }
    
        private IDisposable InitControllers()
        {
            var subscriptions = new CompositeDisposable();
        
            var lobbyRoot = SceneExtensions.LoadSceneRoot<LobbyRoot>();

            lobbyRoot
                .Init(new Unit())
                .AddTo(subscriptions);

            return subscriptions;
        }

        protected override void Deinit()
        {
            _rootDisposable.Clear();
        }
    }

}