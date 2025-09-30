# Fieldset Group

Render a GOV.UK Design System styled fieldset that associates with a form control. Works standalone (explicit `id`) or by consuming a cascaded control id provided by `GdsFormGroup`.

## How it works

- Renders ```<fieldset class="govuk-fieldset">``` with any child content you provide.
- An optional heading can be provided using the `Heading` parameter. This will be wrapped in a legend element with the correct GDS classes.
- The component tries to calculate aria-describedby based on hint and field errors.
- It is recommended to use this component within a [GdsFormGroup](FormGroup.md) to fully support correct HTML and accessibility.

See [GdsCheckboxes](Checkboxes.md) and [GdsRadios](Radios.md) for complete examples of using this component.

## Simple example

```csharp
<GdsFieldsetGroup>
    <Heading>
        <h2 class="govuk-fieldset__heading">How can we contact you?</h2>
    </Heading>
</GdsFieldsetGroup>
```

## Example

```csharp
<GdsFieldsetGroup>
    <Heading>
        <h2 class="govuk-fieldset__heading">How can we contact you?</h2>
    </Heading>
    <Content>
        <div>Anything can go here.</div>
    </Content>
</GdsFieldsetGroup>
```