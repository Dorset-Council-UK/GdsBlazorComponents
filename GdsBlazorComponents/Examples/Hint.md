# Hint

Render a GOV.UK Design System styled hint that associates with a form control. Works standalone (explicit `id`) or by consuming a cascaded control id provided by `GdsFormGroup`.

You can use plain text, HTML markup, or other Blazor components as the content of the hint.

## How it works

- Renders `<div class="govuk-hint">` with any child content you provide.
- The `id` attribute is set from the `Id` component property. If omitted, it falls back to a cascaded id provided by `GdsFormGroup`.

## Simple example with explicit `id`

```
<GdsHint Id="eventName">The name you’ll use on promotional material</GdsHint>
<InputText id="eventName" class="govuk-input" @bind-Value="eventName" />
```

## Example using a cascaded id

```
<GdsFormGroup For="() => Model.EventName">
    <GdsLabel Text="What is the name of the event?" />
    <GdsHint>The name you’ll use on promotional material</GdsHint>
    <GdsErrorMessage />
    <GdsInputText @bind-Value=Model.EventName class="govuk-input govuk-input--width-50" />
</GdsFormGroup>
```

## Example with any content

You can include multiple elements, formatting, or even other components inside the hint:
```
<GdsHint>
    <div>The name you’ll use on promotional material</div>
    <div>It can be up to 50 characters long</div>
    <div>Example: My event name</div>
</GdsHint>
```
