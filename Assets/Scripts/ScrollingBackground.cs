using System;
using Core;
using Support;
using UniRx;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ScrollingBackground : DisposableBehaviour<Unit>
    {
        [SerializeField] private RawImage _background;
        [SerializeField] private float _x, _y;
        
        protected override void OnInit()
        {
            base.OnInit();

            Observable
                .EveryUpdate()
                .SafeSubscribe(_ => MoveBackGround())
                .AddTo(Disposables);
        }

        private void MoveBackGround()
        {
            _background.uvRect = 
                new Rect(_background.uvRect.position + new Vector2(_x,_y) * Time.deltaTime,_background.uvRect.size);
        }
    }
}