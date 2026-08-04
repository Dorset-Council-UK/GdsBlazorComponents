# Hint

Render a GOV.UK Design System styled hint that associates with a form control.

You can use plain text, HTML markup, or other Blazor components as the content of the hint.

## How it works

- Renders a `<div class="govuk-hint">` element with any child content you provide.
- `Id` optional parameter to set the `id` attribute of the component. If no `Id` is provided and used within `GdsFormGroup`, a default hint id is generated.
- `Show` optional parameter to control whether the hint is rendered. If `Show` is false, the hint is not rendered.

The hint id is important for accessiblity and the `aria-describedby` attributes on input controls and fieldsets.
Just by using a hint component it will automatically apply the hint id to any GDS form controls which need it.

# Variants

All hint components work the same way, but are used in different contexts, with different CSS classes applied.

The following components are available:
- GdsHint - see [GdsInputText](InputText.md)
- GdsCheckboxHint - see [GdsInputCheckbox](InputCheckbox.md)
- GdsRadioHint - see [GdsInputRadio](InputRadio.md)
- GdsTaskListHint - see [GdsTaskList](TaskList.md)

## Normal use example

```razor
<GdsFormGroup>
    <GdsLabel Text="What is the name of the event?" />
    <GdsHint>The name you'll use on promotional material</GdsHint>
    <GdsErrorMessage />
    <GdsInputText @bind-Value=Model.EventName class="govuk-input govuk-input--width-50" />
</GdsFormGroup>
```

## Example with any content

You can include multiple elements, formatting, or even other components inside the hint:

```razor
<GdsHint>
    <div>The name you'll use on promotional material</div>
    <div>It can be up to 50 characters long</div>
    <div>Example: My event name</div>
</GdsHint>
```
