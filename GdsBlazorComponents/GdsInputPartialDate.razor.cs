using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;

namespace GdsBlazorComponents;

public partial class GdsInputPartialDate : IDisposable
{
    [CascadingParameter]
    private EditContext EditContext { get; set; } = default!;

    [Parameter, EditorRequired]
    public Expression<Func<object>> For { get; set; } = default!;

    [Parameter]
    public bool IsDateOfBirth { get; set; } = false;

    [Parameter]
    public string? Id { get; set; }

    [Parameter]
    public bool Show { get; set; } = true;

    [Parameter]
    public bool ShowDay { get; set; }

    [Parameter]
    public bool ShowMonth { get; set; }

    [Parameter]
    public bool ShowYear { get; set; }

    [Parameter]
    public RenderFragment? Heading { get; set; }

    [Parameter]
    public RenderFragment? Hint { get; set; }

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

    private GdsDate? _gdsDate;
    private FieldIdentifier _fieldIdentifier;
    private FieldIdentifier _dayFieldIdentifier;
    private FieldIdentifier _monthFieldIdentifier;
    private FieldIdentifier _yearFieldIdentifier;

    public GdsInputPartialDate()
    {
        _validationStateChangedHandler = (sender, args) => OnValidationStateChanged();
    }

    protected override void OnInitialized()
    {
        _fieldIdentifier = FieldIdentifier.Create(For);
        _gdsDate = For.Compile().Invoke() as GdsDate;

        if (_gdsDate != null)
        {
            if (ShowDay) _dayFieldIdentifier = new FieldIdentifier(_gdsDate, nameof(_gdsDate.DayText));
            if (ShowMonth) _monthFieldIdentifier = new FieldIdentifier(_gdsDate, nameof(_gdsDate.MonthText));
            if (ShowYear) _yearFieldIdentifier = new FieldIdentifier(_gdsDate, nameof(_gdsDate.YearText));
        }

        Id ??= _fieldIdentifier.FieldName;

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
        var isFieldValid = EditContext.IsValid(_fieldIdentifier);
        var isDayValid = ShowDay && EditContext.IsValid(_dayFieldIdentifier);
        var isMonthValid = ShowMonth && EditContext.IsValid(_monthFieldIdentifier);
        var isYearValid = ShowYear && EditContext.IsValid(_yearFieldIdentifier);

        _errorMessage = PriorityErrorMessage(isFieldValid, isDayValid, isMonthValid, isYearValid);
        var hasError = _errorMessage != null;

        _formGroupCssClass = hasError ? $"{InputDateCssClasses.Group} {InputDateCssClasses.GroupError}" : InputDateCssClasses.Group;
        _describedBy = DescribedBy(hasError);
        _dayCssClass = CssClass(isDayValid, isFieldValid, InputDateCssClasses.Day);
        _monthCssClass = CssClass(isMonthValid, isFieldValid, InputDateCssClasses.Month);
        _yearCssClass = CssClass(isYearValid, isFieldValid, InputDateCssClasses.Year);
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
            return EditContext.GetValidationMessages(_fieldIdentifier).FirstOrDefault();
        }

        if (ShowDay && !isDayValid)
        {
            return EditContext.GetValidationMessages(_dayFieldIdentifier).FirstOrDefault();
        }

        if (ShowMonth && !isMonthValid)
        {
            return EditContext.GetValidationMessages(_monthFieldIdentifier).FirstOrDefault();
        }

        if (ShowYear && !isYearValid)
        {
            return EditContext.GetValidationMessages(_yearFieldIdentifier).FirstOrDefault();
        }

        // All components are valid
        return null;
    }
}
