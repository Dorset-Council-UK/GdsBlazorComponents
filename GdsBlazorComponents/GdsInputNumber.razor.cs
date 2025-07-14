using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace GdsBlazorComponents;

public partial class GdsInputNumber
{
    [CascadingParameter]
    private string? CascadedId { get; set; }

    [Parameter, EditorRequired]
    public string Text { get; set; } = "";

    [Parameter]
    public EventCallback<string> TextChanged { get; set; }

    [Parameter]
    public int? WholeNumber { get; set; }

    [Parameter]
    public EventCallback<int?> WholeNumberChanged { get; set; }

    [Parameter]
    public float? FloatNumber { get; set; }

    [Parameter]
    public EventCallback<float?> FloatNumberChanged { get; set; }

    [Parameter]
    public bool IsWholeNumber { get; set; } = true;

    [Parameter]
    public string? Id { get; set; }

    [Parameter]
    public bool Show { get; set; } = true;

    [Parameter]
    public InputNumberWidths Width { get; set; } = InputNumberWidths.None;

    private string? _inputmode;
    private string? _describedBy;
    private string? _cssClass;

    protected override void OnInitialized()
    {
        Id ??= CascadedId;

        if (IsWholeNumber)
        {
            _inputmode = "numeric";
        }

        _describedBy = $"{Id}-hint {Id}-error";

        _cssClass = (Width == InputNumberWidths.None) ? "govuk-input" : $"govuk-input govuk-input--width-{(uint)Width}";
    }

    private async Task AfterSetText()
    {
        if (int.TryParse(Text, CultureInfo.InvariantCulture, out var wholeNumber))
        {
            WholeNumber = wholeNumber;
        }
        else
        {
            WholeNumber = null;
        }

        if (float.TryParse(Text, CultureInfo.InvariantCulture, out var floatNumber))
        {
            FloatNumber = floatNumber;
        }
        else
        {
            FloatNumber = null;
        }

        await TextChanged.InvokeAsync(Text);
        await WholeNumberChanged.InvokeAsync(WholeNumber);
        await FloatNumberChanged.InvokeAsync(FloatNumber);
    }
}
