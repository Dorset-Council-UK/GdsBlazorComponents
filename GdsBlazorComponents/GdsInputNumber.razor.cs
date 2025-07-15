using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace GdsBlazorComponents;

public partial class GdsInputNumber
{
    [CascadingParameter]
    private string? CascadedId { get; set; }

    [Parameter]
    public int? WholeNumber { get; set; }

    [Parameter]
    public EventCallback<int?> WholeNumberChanged { get; set; }

    [Parameter]
    public float? FloatNumber { get; set; }

    [Parameter]
    public EventCallback<float?> FloatNumberChanged { get; set; }

    [Parameter]
    public string? Id { get; set; }

    [Parameter]
    public bool Show { get; set; } = true;

    private string? _inputmode;
    private string? _describedBy;

    protected override void OnInitialized()
    {
        Id ??= CascadedId;

        if (WholeNumberChanged.HasDelegate)
        {
            _inputmode = "numeric";
        }

        _describedBy = $"{Id}-hint {Id}-error";
    }

    private async Task AfterSetValue()
    {
        if (int.TryParse(Value, CultureInfo.InvariantCulture, out var wholeNumber))
        {
            WholeNumber = wholeNumber;
        }
        else
        {
            WholeNumber = null;
        }

        if (float.TryParse(Value, CultureInfo.InvariantCulture, out var floatNumber))
        {
            FloatNumber = floatNumber;
        }
        else
        {
            FloatNumber = null;
        }

        await WholeNumberChanged.InvokeAsync(WholeNumber);
        await FloatNumberChanged.InvokeAsync(FloatNumber);
    }
}
