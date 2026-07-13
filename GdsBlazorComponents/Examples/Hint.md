# Hint

Render a GOV.UK Design System styled hint that associates with a form control.

You can use plain text, HTML markup, or other Blazor components as the content of the hint.

## How it works

- Renders `<div class="govuk-hint">` with any child content you provide.
- The `id` attribute is optional, letting you choose your own hint id.
- If `id` is not set, a default hint id is generated and stored in the `GdsFormGroup`.

## Simple example with explicit `id`

```csharp
<GdsHint Id="event-name-hint">The name you'll use on promotional material</GdsHint>
<InputText id="event-name" class="govuk-input" @bind-Value="Model.EventName" />
```

## Normal use example

```csharp
<GdsFormGroup For="() => Model.EventName">
    <GdsLabel Text="What is the name of the event?" />
    <GdsHint>The name you'll use on promotional material</GdsHint>
    <GdsErrorMessage />
    <GdsInputText @bind-Value=Model.EventName class="govuk-input govuk-input--width-50" />
</GdsFormGroup>
```

## Example with any content

You can include multiple elements, formatting, or even other components inside the hint:

```csharp
<GdsHint>
    <div>The name you'll use on promotional material</div>
    <div>It can be up to 50 characters long</div>
    <div>Example: My event name</div>
</GdsHint>
```
