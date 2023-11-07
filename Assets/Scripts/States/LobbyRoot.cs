using Core;
using DefaultNamespace;
using Support;
using UniRx;
using UnityEngine;

namespace States
{
    public class LobbyRoot : DisposableBehaviour<Unit>
    {
        [SerializeField] private UnityEngine.UI.Button _playButton;
        [SerializeField] private ScrollingBackground _scrollingBackground;
    
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

            _scrollingBackground
                .Init(new Unit())
                .AddTo(Disposables);
        }
    }
}