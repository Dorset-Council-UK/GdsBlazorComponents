using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace GdsBlazorComponents;

public partial class GdsInputText : IDisposable
{
    [CascadingParameter]
    private FieldContext? CascadedFieldContext { get; set; }

    /// <summary>
    ///     <para>Optionally override the 'id' attribute of the input control.</para>
    ///     <para>If not set, a default id will be generated and stored in <see cref="FieldContext" /> 'InputId', if available.</para>
    /// </summary>
    [Parameter]
    public string? Id { get; set; }

    private string? _resolvedId;

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        // Calculate the input id
        if (!string.IsNullOrWhiteSpace(Id))
        {
            // if id is set, use it
            _resolvedId = Id.Trim();
        }
        else if (string.IsNullOrWhiteSpace(CascadedFieldContext?.InputId))
        {
            // generate a default input id
            _resolvedId = FieldIdentifier.FieldName;
        }
        else
        {
            // use the existing input id
            _resolvedId = CascadedFieldContext?.InputId;
        }

        // update the field context
        if (CascadedFieldContext is not null)
        {
            CascadedFieldContext.InputId = _resolvedId;
            CascadedFieldContext.RegisterField(FieldIdentifier);
            CascadedFieldContext.NotifyIfChanged();
        }
    }

    public void Dispose()
    {
        CascadedFieldContext?.UnregisterField(FieldIdentifier);
        GC.SuppressFinalize(this);
    }
}
