using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace FloodOnlineReportingTool.GdsComponents;

public partial class GdsInputDate : IDisposable
{
    [CascadingParameter]
    private EditContext EditContext { get; set; } = default!;

    [Parameter, EditorRequired]
    public GdsDate Date { get; set; } = default!;

    [Parameter]
    public bool IsDateOfBirth { get; set; } = false;

    [Parameter, EditorRequired]
    public string Id { get; set; } = default!;

    [Parameter]
    public bool Show { get; set; } = true;

    [Parameter]
    public RenderFragment? Heading { get; set; }

    [Parameter]
    public RenderFragment? Hint { get; set; }

    private static class InputDateCssClasses
    {
        public const string Group = "govuk-form-group";
        public const string GroupError = "govuk-form-group--error";
        public const string DateError = "govuk-input--error";
        public const string Day = "govuk-input govuk-date-input__input govuk-input--width-2";
        public const string Month = Day;
        public const string Year = "govuk-input govuk-date-input__input govuk-input--width-4";
    }

    private string? _errorMessage;
    private readonly EventHandler<ValidationStateChangedEventArgs>? _validationStateChangedHandler;

    private string _formGroupCssClass = InputDateCssClasses.Group;
    private string? _describedBy;
    private string? _hintId;
    private string? _errorId;

    private string _dayId = "";
    private string _dayCssClass = InputDateCssClasses.Day;
    private string? _dayAutocomplete;

    private string _monthId = "";
    private string _monthCssClass = InputDateCssClasses.Month;
    private string? _monthAutocomplete;

    private string _yearId = "";
    private string _yearCssClass = InputDateCssClasses.Year;
    private string? _yearAutocomplete;

    public GdsInputDate()
    {
        _validationStateChangedHandler = (sender, args) => OnValidationStateChanged();
    }

    protected override void OnInitialized()
    {
        _hintId = $"{Id}-hint";
        _errorId = $"{Id}-error";
        _dayId = $"{Id}-day";
        _monthId = $"{Id}-month";
        _yearId = $"{Id}-year";

        // Subscribe to validation state changes
        EditContext.OnValidationStateChanged += _validationStateChangedHandler;
    }

    protected override void OnParametersSet()
    {
        _dayAutocomplete = IsDateOfBirth ? "bday-day" : null;
        _monthAutocomplete = IsDateOfBirth ? "bday-month" : null;
        _yearAutocomplete = IsDateOfBirth ? "bday-year" : null;
    }

    public void Dispose()
    {
        try
        {
            // Unsubscribe from validation state changes
            EditContext.OnValidationStateChanged -= _validationStateChangedHandler;
        }
        catch (Exception)
        {
        }

        GC.SuppressFinalize(this);
    }

    private void OnValidationStateChanged()
    {
        var isDateValid = EditContext.IsValid(() => Date.DateUtc);
        var isDayValid = EditContext.IsValid(() => Date.DayText);
        var isMonthValid = EditContext.IsValid(() => Date.MonthText);
        var isYearValid = EditContext.IsValid(() => Date.YearText);

        _errorMessage = PriorityErrorMessage(isDateValid, isDayValid, isMonthValid, isYearValid);
        var hasError = _errorMessage != null;

        _formGroupCssClass = hasError ? $"{InputDateCssClasses.Group} {InputDateCssClasses.GroupError}" : InputDateCssClasses.Group;
        _describedBy = DescribedBy(hasError);
        _dayCssClass = CssClass(isDayValid, isDateValid, InputDateCssClasses.Day);
        _monthCssClass = CssClass(isMonthValid, isDateValid, InputDateCssClasses.Month);
        _yearCssClass = CssClass(isYearValid, isDateValid, InputDateCssClasses.Year);
    }

    private string? DescribedBy(bool hasError)
    {
        var hasHint = Hint != null;

        if (hasHint && hasError)
        {
            return $"{_hintId} {_errorId}";
        }

        if (hasError)
        {
            return _errorId;
        }

        return hasHint ? _hintId : null;
    }

    private static string CssClass(bool isFieldValid, bool isDateValid, string fieldCssClass)
    {
        // if the field itself is not valid, let the FieldCssClassProvider handle additional error classes
        if (!isFieldValid)
        {
            return fieldCssClass;
        }

        // if the date field is not valid, append the error class
        if (!isDateValid)
        {
            return $"{fieldCssClass} {InputDateCssClasses.DateError}";
        }

        // The field and date are valid, return the field css class
        return fieldCssClass;
    }

    private string? PriorityErrorMessage(bool isDateValid, bool isDayValid, bool isMonthValid, bool isYearValid)
    {
        if (!isDateValid)
        {
            return EditContext.GetValidationMessages(() => Date.DateUtc).FirstOrDefault();
        }

        if (!isDayValid)
        {
            return EditContext.GetValidationMessages(() => Date.DayText).FirstOrDefault();
        }

        if (!isMonthValid)
        {
            return EditContext.GetValidationMessages(() => Date.MonthText).FirstOrDefault();
        }

        if (!isYearValid)
        {
            return EditContext.GetValidationMessages(() => Date.YearText).FirstOrDefault();
        }

        // All components are valid
        return null;
    }
}
