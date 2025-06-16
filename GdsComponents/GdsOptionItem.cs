namespace FloodOnlineReportingTool.GdsComponents;

public class GdsOptionItem<T>
{
    public string Id { get; init; }
    public string Label { get; init; }

    public T Value { get; set; }

    public string? Hint { get; init; }

    /// <summary>
    /// Not relevant for radio buttons
    /// </summary>
    public bool Selected { get; set; }

    /// <summary>
    /// Not relevant for radio buttons unless you want to show a dividing line
    /// </summary>
    public bool IsExclusive { get; init; }

    /// <remarks>
    ///     <para>Selected is not relevant for radio buttons.</para>
    ///     <para>IsExclusive is not relevant for radio buttons unless you want to show a dividing line.</para>
    /// </remarks>
    public GdsOptionItem(ReadOnlySpan<char> id, ReadOnlySpan<char> label, T value, bool selected = false, bool isExclusive = false, ReadOnlySpan<char> hint = default)
    {
        Id = id.ToString();
        Label = label.ToString();
        Value = value;
        Selected = selected;
        IsExclusive = isExclusive;
        Hint = hint.IsEmpty || hint.IsWhiteSpace() ? null : hint.ToString();
    }
}
