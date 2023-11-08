using System;
using Services;
using Support;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Windows
{
    public class PlayConfirmWindow : WindowBase<PlayConfirmWindow.Model>
    {
        public class Model
        {
            public readonly Action OnPlayClick;
            public readonly WindowsService WindowsService;
            
            public Model(Action onPlayClick, WindowsService windowsService)
            {
                OnPlayClick = onPlayClick;
                WindowsService = windowsService;
            }
        }

        [SerializeField] private Button _playButton;
        [SerializeField] private Button _quitButton;
        
        protected override void OnOpen()
        {
            _playButton
                .OnClickAsObservable()
                .SafeSubscribe(_ =>
                {
                    ActiveModel.OnPlayClick?.Invoke();
                    ActiveModel.WindowsService.Close();
                })
                .AddTo(Disposables);

            _quitButton
                .OnClickAsObservable()
                .SafeSubscribe(_ => ActiveModel.WindowsService.CurrentWindow.Value.Close())
                .AddTo(Disposables);
        }
    }
}