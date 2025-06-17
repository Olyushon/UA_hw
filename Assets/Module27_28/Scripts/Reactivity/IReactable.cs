using System;

public interface IReactable<T>
{
    event Action<T, T> Changed;

    T Value { get; }
}