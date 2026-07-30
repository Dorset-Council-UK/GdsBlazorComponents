# Input radio

Render a GOV.UK Design System styled radio form control.

## Example image

![Radios example](Radios.png)

## How it works

- Renders `<input type="checkbox">` styled according to GOV.UK Design System.
- Wraps Blazor's `InputRadio` component.
- `Id` optional parameter to set the `id` attribute of the component. If no `Id` is provided, Blazor's `InputRadio` bound field name will be used, otherwise `GdsRadios` `Name` parameter will be used.
- `ConditionalId` optional parameter to set the `data-aria-controls` attribute of the component. Also use the `GdsRadioConditional` component.

Must be placed within `GdsRadioItem` otherwise it won't render correctly.

To fully support error handling and accessibility place the `GdsInputRadio` component within a `GdsFormGroup`, `GdsFieldsetGroup`, `GdsRadios` and `GdsRadioItem`.

Other radio components:
- GdsRadios
- GdsRadioConditional
- GdsRadioDivider
- GdsRadioHint
- GdsRadioItem
- GdsRadioLabel

## Notes

This page explains the current version of the component, which is `GdsInputRadio`.

`GdsRadio` is deprecated in v3.5.0! It will be removed in future versions.

If you still use the `GdsRadio` component see [GdsRadio](Radio.md).

## Examples

For more examples of how to use the `GdsInputRadio` component, see the [GdsRadios](Radios.md).

## Radios from Enum, and conditional email

```razor
<GdsFormGroup>
    <GdsFieldsetGroup>
        <GdsFieldsetLegend>
            <GdsFieldsetHeading Level="2">How would you prefer to be contacted?</GdsFieldsetHeading>
        </GdsFieldsetLegend>

        <GdsHint>Select one option</GdsHint>
        <GdsErrorMessage />

        <GdsRadios @bind-Value="model.ContactPreference">
            @foreach (ContactPreferences contactPreference in Enum.GetValues<ContactPreferences>())
            {
                    if (contactPreference == ContactPreferencesEnum.Email)
                    {
                        <GdsRadioItem>
                            <GdsInputRadio Value="@contactPreference" ConditionalId="conditional-email" />
                            <GdsRadioLabel Text="@contactPreference.ToString()" />
                        </GdsRadioItem>
                        <GdsRadioConditional Id="conditional-email">
                            <GdsFormGroup>
                                <GdsLabel Text="Email address" />
                                <GdsErrorMessage />
                                <GdsInputText @bind-Value="@model.EmailAddress" type="email" spellcheck="false" autocomplete="email" class="govuk-input govuk-!-width-one-third" />
                            </GdsFormGroup>
                        </GdsRadioConditional>
                    }
                    else
                    {
                        <GdsRadioItem>
                            <GdsInputRadio Value="@contactPreference" />
                            <GdsRadioLabel Text="@contactPreference.ToString()" />
                        </GdsRadioItem>
                    }
            }
        </GdsRadios>
    </GdsFieldsetGroup>
</GdsFormGroup>

@code {
    private CheckboxesModel model = new();
    private EditContext? editContext;

    public enum ContactPreferences
    {
        Unknown,
        Email,
        Phone,
        Text,
    }

    protected override void OnInitialized()
    {
        if (editContext is null)
        {
            editContext = new(model);
            editContext.SetFieldCssClassProvider(new GdsFieldCssClassProvider());
        }
    }

    public class CheckboxesModel
    {
        [Required]
        [Range(typeof(ContactPreferences), nameof(ContactPreferences.Email), nameof(ContactPreferences.Text), ErrorMessage = "Select how you prefer to be contacted")]
        [GdsFieldErrorClass(GdsFieldTypes.Radio)]
        public ContactPreferences? ContactPreference { get; set; } = ContactPreferences.Unknown;

        [Required(ErrorMessage = "Enter your email address")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        [GdsFieldErrorClass(GdsFieldTypes.Input)]
        public string? EmailAddress { get; set; }
    }
}
```
