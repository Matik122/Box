using System;
using States;
using Support;
using UniRx;
using UnityEngine;

namespace Services
{
    public abstract class WindowBase<T> : WindowBase
    {
        [SerializeField] private SafeArea _safeArea;

        public sealed override Type ModelType => typeof(T);
        protected T ActiveModel { get; private set; }

        protected readonly CompositeDisposable Disposables = new();
        private readonly CompositeDisposable _animationDisposable = new();

        private void OnDestroy()
        {
            _animationDisposable.Clear();
        }

        public sealed override void Open(object model)
        {
            ActiveModel = (T)model;

            _safeArea.Fit();

            OnOpen();
        }

        public sealed override void Close()
        {
            Disposables.Clear();

            ActiveModel = default;
        }

        protected abstract void OnOpen();
        protected abstract IObservable<Unit> ObserveWindowAnimation(bool appear);
        
    }
    
    public abstract class WindowBase : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;

        public abstract Type ModelType { get; }
        public IReadOnlyReactiveProperty<bool> IsAnimationActive => _isAnimationActive;

        protected readonly ReactiveProperty<bool> _isAnimationActive = new();

        public void SetOrder(int order)
        {
            _canvas.sortingOrder = order;
        }

        public abstract void Open(object model);
        public abstract void Close();

    }
    
}