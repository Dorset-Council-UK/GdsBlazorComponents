# Error Message

Render a GOV.UK Design System styled error message that associates with a form control.

## Example image

![Error message](ErrorMessage.png)

## How it works

- Renders `<p class="govuk-error-message">`.
- The `Id` attribute is optional, letting you choose the error message id.
- If `Id` is not set, and used within `GdsFormGroup`, a default error message id is generated.

## Notes

You never manually set the error message text. It is automatically populated from the Blazor validation system when there are validation errors for the associated field.

## Simple example with explicit `id`

```csharp
<GdsErrorMessage Id="event-name-error" />
<InputText id="event-name" class="govuk-input" @bind-Value="Model.EventName" aria-describedby="event-name-error" />
```

## Simple example

```csharp
<GdsFormGroup>
    <GdsLabel Text="What is the name of the event?" />
    <GdsHint>The name you'll use on promotional material</GdsHint>
    <GdsErrorMessage />
    <GdsInputText @bind-Value=Model.EventName class="govuk-input govuk-input--width-50" />
</GdsFormGroup>
```