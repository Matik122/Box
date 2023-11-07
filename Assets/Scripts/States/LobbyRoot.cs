using Core;
using Lobby;
using Support;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace States
{
    public class LobbyRoot : DisposableBehaviour<Unit>
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Transform _playButtonTransform;
        [SerializeField] private RawImage _visualBackground;
        [SerializeField] private float _endValue;
        [SerializeField] private float _duration;
        [SerializeField] private float _uvMovingByX;

        private const string SceneName = "GameStart";
    
        protected override void OnInit()
        {
            base.OnInit();

            _playButton
                .OnClickAsObservable().SafeSubscribe(_ =>
                {
                    SceneExtensions.LoadScene(SceneName)
                        .EmptySubscribe()
                        .AddTo(Disposables);
                }).AddTo(Disposables);
            
            new ScrollingBackground(_visualBackground, _uvMovingByX)
                .Init()
                .AddTo(Disposables);
            
            new StartButtonLoop(_playButtonTransform, _endValue, _duration)
                .Init()
                .AddTo(Disposables);
        }
    }
}