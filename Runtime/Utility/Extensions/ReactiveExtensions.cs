using System;
using System.Diagnostics;
using PS.UiFramework.Unsubscribe;
using R3;

namespace PS.UiFramework.Extensions
{
    /// <summary>
    /// Provides extension methods for working with observables and managing subscriptions with unsubscribe links.
    /// </summary>
    public static class ReactiveExtensions
    {
        /// <summary>
        /// Adds the disposable to an unsubscribe link. If the link is null, disposes of the object.
        /// </summary>
        /// <typeparam name="T">The type of the disposable object.</typeparam>
        /// <param name="disposable">The disposable object to add.</param>
        /// <param name="unsubscribeLink">The unsubscribe link to associate with the disposable.</param>
        /// <returns>The original disposable object.</returns>
        public static T AddTo<T>(this T disposable, UnsubscribeLink unsubscribeLink) where T : IDisposable
        {
            if (unsubscribeLink != null) 
                return disposable.AddTo(unsubscribeLink.LinkObject);
            
            disposable?.Dispose();
            return disposable;
        }

        /// <summary>
        /// Subscribes to an observable and adds the subscription to an unsubscribe link.
        /// </summary>
        /// <typeparam name="T">The type of the items produced by the observable.</typeparam>
        /// <param name="source">The observable to subscribe to.</param>
        /// <param name="unsubscribeLink">The unsubscribe link to associate with the subscription.</param>
        /// <returns>An IDisposable representing the subscription.</returns>
        [DebuggerStepThrough]
        public static IDisposable SubscribeWithLink<T>(this Observable<T> source, UnsubscribeLink unsubscribeLink)
        {
            return source.Subscribe().AddTo(unsubscribeLink);
        }

        /// <summary>
        /// Subscribes to an observable with a callback for each item and adds the subscription to an unsubscribe link.
        /// </summary>
        /// <typeparam name="T">The type of the items produced by the observable.</typeparam>
        /// <param name="source">The observable to subscribe to.</param>
        /// <param name="onNext">The action to execute for each item produced by the observable.</param>
        /// <param name="unsubscribeLink">The unsubscribe link to associate with the subscription.</param>
        /// <returns>An IDisposable representing the subscription.</returns>
        [DebuggerStepThrough]
        public static IDisposable SubscribeWithLink<T>(this Observable<T> source, Action<T> onNext,
            UnsubscribeLink unsubscribeLink)
        {
            return source.Subscribe(onNext).AddTo(unsubscribeLink);
        }

        /// <summary>
        /// Subscribes to an observable with callbacks for items and completion and adds the subscription to an unsubscribe link.
        /// </summary>
        /// <typeparam name="T">The type of the items produced by the observable.</typeparam>
        /// <param name="source">The observable to subscribe to.</param>
        /// <param name="onNext">The action to execute for each item produced by the observable.</param>
        /// <param name="onCompleted">The action to execute when the observable completes.</param>
        /// <param name="unsubscribeLink">The unsubscribe link to associate with the subscription.</param>
        /// <returns>An IDisposable representing the subscription.</returns>
        [DebuggerStepThrough]
        public static IDisposable SubscribeWithLink<T>(
            this Observable<T> source,
            Action<T> onNext,
            Action<Result> onCompleted,
            UnsubscribeLink unsubscribeLink)
        {
            return source.Subscribe(onNext, onCompleted).AddTo(unsubscribeLink);
        }

        /// <summary>
        /// Subscribes to an observable with callbacks for items, errors, and completion, and adds the subscription to an unsubscribe link.
        /// </summary>
        /// <typeparam name="T">The type of the items produced by the observable.</typeparam>
        /// <param name="source">The observable to subscribe to.</param>
        /// <param name="onNext">The action to execute for each item produced by the observable.</param>
        /// <param name="onErrorResume">The action to execute if an error occurs.</param>
        /// <param name="onCompleted">The action to execute when the observable completes.</param>
        /// <param name="unsubscribeLink">The unsubscribe link to associate with the subscription.</param>
        /// <returns>An IDisposable representing the subscription.</returns>
        [DebuggerStepThrough]
        public static IDisposable SubscribeWithLink<T>(
            this Observable<T> source,
            Action<T> onNext,
            Action<Exception> onErrorResume,
            Action<Result> onCompleted,
            UnsubscribeLink unsubscribeLink)
        {
            return source.Subscribe(onNext, onErrorResume, onCompleted).AddTo(unsubscribeLink);
        }

        /// <summary>
        /// Subscribes to an observable with a state object and a callback for each item, and adds the subscription to an unsubscribe link.
        /// </summary>
        /// <typeparam name="T">The type of the items produced by the observable.</typeparam>
        /// <typeparam name="TState">The type of the state object.</typeparam>
        /// <param name="source">The observable to subscribe to.</param>
        /// <param name="state">The state object to pass to the callback.</param>
        /// <param name="onNext">The action to execute for each item produced by the observable, with the state object.</param>
        /// <param name="unsubscribeLink">The unsubscribe link to associate with the subscription.</param>
        /// <returns>An IDisposable representing the subscription.</returns>
        [DebuggerStepThrough]
        public static IDisposable SubscribeWithLink<T, TState>(
            this Observable<T> source,
            TState state,
            Action<T, TState> onNext,
            UnsubscribeLink unsubscribeLink)
        {
            return source.Subscribe(state, onNext).AddTo(unsubscribeLink);
        }

        /// <summary>
        /// Subscribes to an observable with a state object and callbacks for items and completion, and adds the subscription to an unsubscribe link.
        /// </summary>
        /// <typeparam name="T">The type of the items produced by the observable.</typeparam>
        /// <typeparam name="TState">The type of the state object.</typeparam>
        /// <param name="source">The observable to subscribe to.</param>
        /// <param name="state">The state object to pass to the callbacks.</param>
        /// <param name="onNext">The action to execute for each item produced by the observable, with the state object.</param>
        /// <param name="onCompleted">The action to execute when the observable completes, with the state object.</param>
        /// <param name="unsubscribeLink">The unsubscribe link to associate with the subscription.</param>
        /// <returns>An IDisposable representing the subscription.</returns>
        [DebuggerStepThrough]
        public static IDisposable SubscribeWithLink<T, TState>(
            this Observable<T> source,
            TState state,
            Action<T, TState> onNext,
            Action<Result, TState> onCompleted,
            UnsubscribeLink unsubscribeLink)
        {
            return source.Subscribe(state, onNext, onCompleted).AddTo(unsubscribeLink);
        }

        /// <summary>
        /// Subscribes to an observable with a state object and callbacks for items, errors, and completion, and adds the subscription to an unsubscribe link.
        /// </summary>
        /// <typeparam name="T">The type of the items produced by the observable.</typeparam>
        /// <typeparam name="TState">The type of the state object.</typeparam>
        /// <param name="source">The observable to subscribe to.</param>
        /// <param name="state">The state object to pass to the callbacks.</param>
        /// <param name="onNext">The action to execute for each item produced by the observable, with the state object.</param>
        /// <param name="onErrorResume">The action to execute if an error occurs, with the state object.</param>
        /// <param name="onCompleted">The action to execute when the observable completes, with the state object.</param>
        /// <param name="unsubscribeLink">The unsubscribe link to associate with the subscription.</param>
        /// <returns>An IDisposable representing the subscription.</returns>
        [DebuggerStepThrough]
        public static IDisposable SubscribeWithLink<T, TState>(
            this Observable<T> source,
            TState state,
            Action<T, TState> onNext,
            Action<Exception, TState> onErrorResume,
            Action<Result, TState> onCompleted,
            UnsubscribeLink unsubscribeLink)
        {
            return source.Subscribe(state, onNext, onErrorResume, onCompleted).AddTo(unsubscribeLink);
        }
    }
}