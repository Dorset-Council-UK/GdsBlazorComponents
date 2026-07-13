using Microsoft.AspNetCore.Components.Forms;

namespace GdsBlazorComponents;

public record GdsFormGroupContext(Action OnChange)
{
    public string? Id {
        get;
        set
        {
            string? trimmed = value?.Trim();
            if (field == trimmed)
            {
                return;
            }
            field = trimmed;
            OnChange.Invoke();
        }
    }

    public string? HintId
    {
        get;
        set
        {
            string? trimmed = value?.Trim();
            if (field == trimmed)
            {
                return;
            }
            field = trimmed;
            OnChange.Invoke();
        }
    }

    public string? ErrorId {
        get;
        set
        {
            string? trimmed = value?.Trim();
            if (field == trimmed)
            {
                return;
            }
            field = trimmed;
            OnChange.Invoke();
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

    public FieldIdentifier? FieldIdentifier
    {
        get;
        set
        {
            if (field.Equals(value))
            {
                return;
            }
            field = value;
            OnChange.Invoke();
        }
    }
}
