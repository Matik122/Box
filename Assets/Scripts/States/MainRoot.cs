using System;
using Services;
using Support;
using UniRx;
using UnityEngine;

namespace States
{
    public class MainRoot : MonoBehaviour
    {
        [SerializeField] private WindowsService _windowsService;
        
        private GameMachine _gameMachine;
    
        private readonly CompositeDisposable _rootDisposable = new();
    
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            StartRoot();
        }

        private void StartRoot()
        {
            Observable.ReturnUnit()
                .ContinueWith(_ => InitStates())
                .SafeSubscribe(_ => LoadStage())
                .AddTo(_rootDisposable);
        }

        private IObservable<Unit> InitStates()
        {
            _gameMachine = new GameMachine();
        
            _gameMachine
                .Init()
                .AddTo(_rootDisposable);
        
            _gameMachine.AddState(new LobbyState(_gameMachine));
            _gameMachine.AddState(new GameState(_gameMachine));

            return Observable.ReturnUnit();
        }
    
        private void LoadStage()
        {
            _gameMachine.ChangeState<LobbyState>();
        }
    
        private void OnDestroy()
        {
            _rootDisposable.Clear();
        }
    }
}