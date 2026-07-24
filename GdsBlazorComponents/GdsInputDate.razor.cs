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

    private string _dayId = "";
    private string? _dayName;
    private string _dayCssClass = InputDateCssClasses.Day;
    private string? _dayAutocomplete;

    private string _monthId = "";
    private string? _monthName;
    private string _monthCssClass = InputDateCssClasses.Month;
    private string? _monthAutocomplete;

    private string _yearId = "";
    private string? _yearName;
    private string _yearCssClass = InputDateCssClasses.Year;
    private string? _yearAutocomplete;

    private GdsDate? _gdsDate;
    private FieldIdentifier _fieldIdentifier;
    private FieldIdentifier _dayFieldIdentifier;
    private FieldIdentifier _monthFieldIdentifier;
    private FieldIdentifier _yearFieldIdentifier;

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

        if (_gdsDate != null)
        {
            _dayFieldIdentifier = new FieldIdentifier(_gdsDate, nameof(_gdsDate.DayText));
            _monthFieldIdentifier = new FieldIdentifier(_gdsDate, nameof(_gdsDate.MonthText));
            _yearFieldIdentifier = new FieldIdentifier(_gdsDate, nameof(_gdsDate.YearText));
        }

        // Subscribe to validation state changes
        CascadedEditContext?.OnValidationStateChanged += HandleValidationStateChanged;
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

        _dayId = $"{_resolvedId}-day";
        _dayName = $"{_resolvedId}-{_dayFieldIdentifier.FieldName}";
        _monthId = $"{_resolvedId}-month";
        _monthName = $"{_resolvedId}-{_monthFieldIdentifier.FieldName}";
        _yearId = $"{_resolvedId}-year";
        _yearName = $"{_resolvedId}-{_yearFieldIdentifier.FieldName}";

        if (CascadedFieldContext is not null)
        {
            CascadedFieldContext.InputId = Show ? _resolvedId : null;
            CascadedFieldContext.NotifyIfChanged();
        }
    }

    public void Dispose()
    {
        CascadedEditContext?.OnValidationStateChanged -= HandleValidationStateChanged;
        GC.SuppressFinalize(this);
    }

    private void HandleValidationStateChanged(object? sender, ValidationStateChangedEventArgs e)
    {
        if (CascadedEditContext is null)
        {
            return;
        }

        bool isFieldValid = CascadedEditContext.IsValid(_fieldIdentifier);
        bool isDayValid = CascadedEditContext.IsValid(_dayFieldIdentifier);
        var isMonthValid = CascadedEditContext.IsValid(_monthFieldIdentifier);
        var isYearValid = CascadedEditContext.IsValid(_yearFieldIdentifier);

        //_errorMessage = PriorityErrorMessage(isFieldValid, isDayValid, isMonthValid, isYearValid);
        //var hasError = _errorMessage != null;

        _dayCssClass = CssClass(isDayValid, isFieldValid, InputDateCssClasses.Day);
        _monthCssClass = CssClass(isMonthValid, isFieldValid, InputDateCssClasses.Month);
        _yearCssClass = CssClass(isYearValid, isFieldValid, InputDateCssClasses.Year);

        string test = new CssClassBuilder(InputDateCssClasses.Day)
            .AddIf(!isFieldValid, InputDateCssClasses.DateError)
            .Build();
    }

    private static string CssClass(bool isPropertyValid, bool isFieldValid, string fieldCssClass)
    {
        // if the field itself is not valid, let the FieldCssClassProvider handle additional error classes
        if (!isPropertyValid)
        {
            return fieldCssClass;
        }

        // if the date field is not valid, append the error class
        if (!isFieldValid)
        {
            return $"{fieldCssClass} {InputDateCssClasses.DateError}";
        }

        // The field and date are valid, return the field css class
        return fieldCssClass;
    }

    private string? PriorityErrorMessage(bool isFieldValid, bool isDayValid, bool isMonthValid, bool isYearValid)
    {
        if (!isFieldValid)
        {
            return CascadedEditContext?.GetValidationMessages(_fieldIdentifier).FirstOrDefault();
        }

        if (!isDayValid)
        {
            return CascadedEditContext?.GetValidationMessages(_dayFieldIdentifier).FirstOrDefault();
        }

        if (!isMonthValid)
        {
            return CascadedEditContext?.GetValidationMessages(_monthFieldIdentifier).FirstOrDefault();
        }

        if (!isYearValid)
        {
            return CascadedEditContext?.GetValidationMessages(_yearFieldIdentifier).FirstOrDefault();
        }

        // All components are valid
        return null;
    }
}
