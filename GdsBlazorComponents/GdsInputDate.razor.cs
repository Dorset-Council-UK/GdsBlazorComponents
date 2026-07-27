using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;

namespace GdsBlazorComponents;

/// <summary>
/// Represents a Blazor component for inputting dates, allowing users to enter day, month, and year.
/// </summary>
public partial class GdsInputDate : IDisposable
{
    [Parameter]
    public string? AdditionalCssClasses { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    [CascadingParameter]
    private EditContext? CascadedEditContext { get; set; }

    [CascadingParameter]
    private FieldContext? CascadedFieldContext { get; set; }

    [Parameter, EditorRequired]
    public Expression<Func<GdsDate>>? For { get; set; }

    [Parameter]
    public bool IsDateOfBirth { get; set; } = false;

    /// <summary>
    ///     <para>Optionally override the 'id' attribute of the date input.</para>
    ///     <para>If not set, a default id will be generated and stored in <see cref="FieldContext" /> 'InputId', if available.</para>
    /// </summary>
    [Parameter]
    public string? Id { get; set; }

    [Parameter]
    public bool Show { get; set; } = true;

    [Parameter]
    public RenderFragment? Heading { get; set; }

    [Parameter]
    public GdsSize LegendSize { get; set; } = GdsSize.Large;

    [Parameter]
    public RenderFragment? Hint { get; set; }

    private string? _resolvedId;

    private string? _dayId;
    private string? _dayName;
    private string? _dayAutocomplete;

    private string? _monthId;
    private string? _monthName;
    private string? _monthAutocomplete;

    private string? _yearId;
    private string? _yearName;
    private string? _yearAutocomplete;

    private GdsDate? _gdsDate;
    private FieldIdentifier _fieldIdentifier;

    protected override void OnInitialized()
    {
        if (CascadedFieldContext is null)
        {
            throw new InvalidOperationException($"{nameof(GdsInputDate)} must be used inside a {nameof(GdsFormGroup)}.");
        }

        if (For is null)
        {
            throw new InvalidOperationException($"{GetType()} requires a value for the {nameof(For)} parameter.");
        }

        // resolve the field for the input date
        _fieldIdentifier = FieldIdentifier.Create(For);
        _gdsDate = For.Compile().Invoke() ?? new();

        // register the field for the parent GDS form group
        CascadedFieldContext?.RegisterField(_fieldIdentifier);
    }

    protected override void OnParametersSet()
    {
        _dayAutocomplete = IsDateOfBirth ? "bday-day" : null;
        _monthAutocomplete = IsDateOfBirth ? "bday-month" : null;
        _yearAutocomplete = IsDateOfBirth ? "bday-year" : null;

        // Calculate the input id
        if (!string.IsNullOrWhiteSpace(Id))
        {
            // if id is set, use it
            _resolvedId = Id.Trim();
        }
        else if (string.IsNullOrWhiteSpace(CascadedFieldContext?.InputId))
        {
            // generate a default input id
            _resolvedId = _fieldIdentifier.FieldName;
        }
        else
        {
            _resolvedId = CascadedFieldContext?.InputId;
        }

        _dayId = $"{_resolvedId}-{nameof(GdsDate.DayText)}";
        _monthId = $"{_resolvedId}-{nameof(GdsDate.MonthText)}";
        _yearId = $"{_resolvedId}-{nameof(GdsDate.YearText)}";

        _dayName = $"{_fieldIdentifier.FieldName}.{nameof(GdsDate.DayText)}";
        _monthName = $"{_fieldIdentifier.FieldName}.{nameof(GdsDate.MonthText)}";
        _yearName = $"{_fieldIdentifier.FieldName}.{nameof(GdsDate.YearText)}";

        if (CascadedFieldContext is not null)
        {
            CascadedFieldContext.InputId = _resolvedId;
            CascadedFieldContext.RegisterField(_fieldIdentifier);
            CascadedFieldContext.NotifyIfChanged();
        }
    }

    public void Dispose()
    {
        CascadedFieldContext?.UnregisterField(_fieldIdentifier);
        GC.SuppressFinalize(this);
    }
}
