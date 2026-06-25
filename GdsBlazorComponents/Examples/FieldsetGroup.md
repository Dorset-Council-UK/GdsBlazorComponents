# Fieldset Group

Render a GOV.UK Design System styled fieldset that associates with a form control. Works standalone (explicit `id`) or by consuming a cascaded control id provided by `GdsFormGroup`.

## How it works

- Renders ```<fieldset class="govuk-fieldset">``` with any child content you provide.
- Use `GdsFieldsetLegend` to provide a legend for the fieldset.
- Optionally use `GdsFieldsetHeading` to provide a heading for the legend.
- The component tries to calculate aria-describedby based on hint and field errors.
- It is recommended to use this component within a [GdsFormGroup](FormGroup.md) to fully support correct HTML and accessibility.

See [GdsCheckboxes](Checkboxes.md) and [GdsRadios](Radios.md) for complete examples of using this component.

## Warning
`LegendSize` was deprecated in version 3.3.0 `LegendSize` will be removed in a future release.

Use `GdsFieldsetLegend` with the `Size` parameter instead. 

## Simple example

```csharp
<GdsFieldsetGroup>
    <GdsFieldsetLegend>
        How can we contact you?
    </GdsFieldsetLegend>
    <div>Your content goes here</div>
</GdsFieldsetGroup>
```

## Example with heading

```csharp
<GdsFieldsetGroup>
    <GdsFieldsetLegend Size="@GdsSize.Medium">
        <GdsFieldsetHeading Level="2">How can we contact you?</GdsFieldsetHeading>
    </GdsFieldsetLegend>
    <div>Your content goes here</div>
</GdsFieldsetGroup>
```