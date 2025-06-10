using System;

public class ReactableVariable<T> : IReactableVariable<T> where T : IEquatable<T>
{
    public event Action<T, T> Changed;

    private T _value;

    public ReactableVariable() => _value = default(T);
    public ReactableVariable(T value) => _value = value;

    public T Value
    {
        get => _value;
        set
        {
            T oldValue = _value;

            _value = value;

            if (_value.Equals(oldValue) == false)
                Changed?.Invoke(oldValue, value);
        }
    }
}
