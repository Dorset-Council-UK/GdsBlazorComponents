# Radio

Render a single GOV.UK Design System styled radio button using the option from [GdsOptionItem<T>](GdsOptionItem.md).

## Example image

![Radio example](Radio.png)

## How it works

- Renders a ```<div class="govuk-radios__item">``` with associated label, radio button and optional hint.
- Supports binding to any value type (e.g., string, int, enum, bool, custom types).
- Can be used standalone or as part of a group for multiple selections.
- If the [GdsOptionItem](GdsOptionItem.md) includes a hint, it is displayed below the label as defined by the GOV.UK Design System style.
- The component integrates with Blazor�s validation system, but the errors won't be displayed in this component. See [GdsRadios](Radios.md) which shows radio button error messages are shown above the radio buttons using [GdsErrorMessage](ErrorMessage.md).
- The component renders the radio button using Blazor's `InputRadio` component, labels via the [GdsLabel](Label.md) component, and hints via the [GdsHint](Hint.md) component.

## Simple example

```csharp
// id, label, T value, selected = false, isExclusive = false, hint = default
var option = new GdsOptionItem<bool>("subscribe", "Subscribe to newsletter", hint: "Receive updates and offers via email");
<GdsRadio Option="@option" />
```

## Recommended use example

In most cases you will want something more than a single radio button, so we recomend you using [GdsRadios component](Radios.md). Doing this also guarantees good HTML and accessibility.

Please refer to that component for full examples.