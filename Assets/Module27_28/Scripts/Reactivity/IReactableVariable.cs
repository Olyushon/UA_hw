using System;

public interface IReactableVariable<T>
{
    event Action<T, T> Changed;

    T Value { get; }
}
