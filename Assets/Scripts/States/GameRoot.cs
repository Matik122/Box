using Core;
using Lobby;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace States
{
    public class GameRoot : DisposableBehaviour<Unit>
    {
        [SerializeField] private RawImage _visualBackground;
        [SerializeField] private float _uvMovingByX;
        
        protected override void OnInit()
        {
            base.OnInit();
            
            new ScrollingBackground(_visualBackground, _uvMovingByX)
                .Init()
                .AddTo(Disposables);
        }
    }
}