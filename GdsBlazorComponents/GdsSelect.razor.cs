using Microsoft.AspNetCore.Components;

namespace GdsBlazorComponents;

public partial class GdsSelect<T> : IDisposable
{
    [CascadingParameter]
    private FieldContext? CascadedFieldContext { get; set; }

    /// <summary>
    ///     <para>Optionally override the 'id' attribute of the select control.</para>
    ///     <para>If not set, a default id will be generated and stored in <see cref="FieldContext" /> 'InputId', if available.</para>
    /// </summary>
    [Parameter]
    public string? Id { get; set; }

    [Parameter]
    public string? AdditionalCssClasses { get; set; }

    private string? _class;
    private string? _resolvedId;

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        _class = new CssClassBuilder("govuk-select")
            .Add(CssClass)
            .Add(AdditionalCssClasses)
            .Build();

        // Calculate the form control id
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
