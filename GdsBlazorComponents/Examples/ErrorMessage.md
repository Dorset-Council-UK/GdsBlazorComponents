# Error Message

Render a GOV.UK Design System styled error message that associates with a form control.

## Example image

![Error message](ErrorMessage.png)

## How it works

- Renders `<p class="govuk-error-message">`.
- `Id` optional parameter to set the `id` attribute of the component. If no `Id` is provided and used within `GdsFormGroup`, a default error id is generated.

The error id is important for accessiblity and the `aria-describedby` attributes on input controls and fieldsets.
Just by using the error message component it will automatically apply the error id to any GDS form controls which need it.

## Notes

You never manually set the error message text. It is automatically populated from the Blazor validation system when there are validation errors for the associated field.

## Simple example with explicit `id`

```razor
<GdsErrorMessage Id="event-name-error" />
<InputText id="event-name" class="govuk-input" @bind-Value="Model.EventName" aria-describedby="event-name-error" />
```

## Simple example

```razor
<GdsFormGroup>
    <GdsLabel Text="What is the name of the event?" />
    <GdsHint>The name you'll use on promotional material</GdsHint>
    <GdsErrorMessage />
    <GdsInputText @bind-Value=Model.EventName class="govuk-input govuk-input--width-50" />
</GdsFormGroup>
```