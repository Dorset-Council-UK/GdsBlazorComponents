using Microsoft.AspNetCore.Components.Forms;
using System.Text;

namespace GdsBlazorComponents;

public record FieldContext(Action OnChange)
{
    private bool _isNotifying;
    public bool IsDirty { get; private set; }

    public string? InputId
    {
        get;
        set
        {
            string? trimmed = value?.Trim();
            if (field == trimmed) return;
            field = trimmed;
            IsDirty = true;
        }
    }

    public string? HintId
    {
        get;
        set
        {
            string? trimmed = value?.Trim();
            if (field == trimmed) return;
            field = trimmed;
            IsDirty = true;
        }
    }

    public string? ErrorId
    {
        get;
        set
        {
            string? trimmed = value?.Trim();
            if (field == trimmed) return;
            field = trimmed;
            IsDirty = true;
        }
    }

    public string? DescribedBy
    {
        get
        {
            if (HintId is null && ErrorId is null)
            {
                return null;
            }
            return $"{HintId} {ErrorId}".Trim();
        }
    }

    /// <summary>
    ///     <para>Optional parent field context.</para>
    ///     <para>If set, the parent will be notified when fields are registered or unregistered, allowing child components to notify the parent of changes in the field context.</para>
    ///     <para>This is useful for propagating changes in nested components.</para>
    /// </summary>
    public FieldContext? Parent { get; init; }

    public HashSet<FieldIdentifier> FieldIdentifiers { get; } = [];

    public void RegisterField(FieldIdentifier fieldIdentifier)
    {
        if (FieldIdentifiers.Add(fieldIdentifier))
        {
            IsDirty = true;
        }

        Parent?.RegisterField(fieldIdentifier);
    }

    public void UnregisterField(FieldIdentifier fieldIdentifier)
    {
        if (FieldIdentifiers.Remove(fieldIdentifier))
        {
            IsDirty = true;
        }

        Parent?.UnregisterField(fieldIdentifier);
    }

    /// <summary>
    /// Notifies the parent component `if` the field context has changed. Propagting the changed state to the child components.
    /// </summary>
    /// <remarks>Any use of InputId, HintId, ErrorId, DescribedBy, or FieldIdentifiers will be updated in other components.</remarks>
    public void NotifyIfChanged()
    {
        if (!IsDirty || _isNotifying) return;

        try
        {
            _isNotifying = true;
            OnChange.Invoke();
        }
        finally
        {
            _isNotifying = false;
            IsDirty = false;
        }
    }

    protected virtual bool PrintMembers(StringBuilder builder)
    {
        builder.Append($"{nameof(IsDirty)} = {IsDirty}");
        builder.Append($", {nameof(InputId)} = {InputId}");
        builder.Append($", {nameof(HintId)} = {HintId}");
        builder.Append($", {nameof(ErrorId)} = {ErrorId}");
        builder.Append($", {nameof(DescribedBy)} = {DescribedBy}");
        builder.Append($", {nameof(FieldIdentifiers)} = [ ");
        builder.AppendJoin(", ", FieldIdentifiers.Select(f => f.FieldName));
        builder.Append(" ]");
        builder.Append($", Parent = {Parent is not null}");
        return true;
    }
}
