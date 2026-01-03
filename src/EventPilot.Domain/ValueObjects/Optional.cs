namespace EventPilot.Domain.ValueObjects;

public readonly struct Optional<T>
{
    public bool HasValue { get; }
    public T? Value { get; }

    public Optional(T? value)
    {
        HasValue = true;
        Value = value;
    }

    public static Optional<T> Missing()
        => new Optional<T>();

    public static Optional<T> From(T? value)
        => new Optional<T>(value);
}