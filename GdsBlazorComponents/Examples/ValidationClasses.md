# Validation CSS Classes

This guide explains how validation CSS classes are applied in GOV.UK Design System styled Blazor components.

By default Blazor will apply the `valid` and `modifed` CSS classes to form fields based on their state. But that does not align with GDS styles.

Some quick examples of what GDS uses when fields error are: `govuk-input--error`, `govuk-select--error`, `govuk-textarea--error`.

And often errors on a form field require the parent `govuk-form-group` to also have an error class, e.g. `govuk-form-group--error`. The [GdsFormGroup](FormGroup.md) component has been built to handle that part.

So what is left to solve is setting the correct CSS classes on the actual form fields.

## How it works

- GDS uses specific CSS classes to visually indicate validation states (e.g., errors) on form fields.
- We can make use of 2 of Blazor's validation features:
  - [Custom validation attributes](https://learn.microsoft.com/en-us/aspnet/core/blazor/forms/validation?view=aspnetcore-9.0#custom-validation-attributes) - So we can mark the fields in our model telling them what type of GDS fields they are.
  - [Field CSS Class Provider](https://learn.microsoft.com/en-us/aspnet/core/blazor/forms/validation?view=aspnetcore-9.0#custom-validation-css-class-attributes) - So when the field fails validation it will have the right GDS CSS class.
- The `GdsFieldTypes` enum defines all the GDS field types.
- The `GdsFieldErrorClassAttribute` custom attribute works out what GDS CSS class should be used for the field.
- The `GdsFieldCssClassProvider` is what the Blazor pages use to assign the form field CSS classes depending on their validation state.

Now just using the attribute and setting the field CSS class provider, the right GDS CSS error classes are applied when the fields fail to validate.

## Example model

```csharp
public class SomeModel
{
    [GdsFieldErrorClass(GdsFieldTypes.Input)]
    public string? Email { get; set; }

    [GdsFieldErrorClass(GdsFieldTypes.Password)]
    public string? Password { get; set; }

    [GdsFieldErrorClass(GdsFieldTypes.Checkbox)]
    public IReadOnlyCollection<GdsOptionItem<Guid>> MyCheckboxes { get; set; } = [];

    [GdsFieldErrorClass(GdsFieldTypes.Radio)]
    public bool? IsItMonday { get; set; }
}
```

## Example page

```csharp
protected override void OnInitialized()
{
    Model ??= new();
    editContext = new(Model);
    editContext.SetFieldCssClassProvider(new GdsFieldCssClassProvider());
}
```