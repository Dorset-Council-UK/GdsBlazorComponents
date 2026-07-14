using Microsoft.AspNetCore.Components.Forms;

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

    public HashSet<FieldIdentifier> FieldIdentifiers { get; } = [];

    public void RegisterField(FieldIdentifier fieldIdentifier)
    {
        var added = FieldIdentifiers.Add(fieldIdentifier);
        if (added) IsDirty = true;
    }

    public void UnregisterField(FieldIdentifier fieldIdentifier)
    {
        var removed = FieldIdentifiers.Remove(fieldIdentifier);
        if (removed) IsDirty = true;
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
}
