# Main wrapper

Render GOV.UK Design System styled main wrapper element.

## How it works

- renders a `<main class="govuk-main-wrapper` element styled according to the GOV.UK Design System.
- use the `AutoSpacing` parameter to automatically add the GOV.UK spacing class to the container element (essentially additional top padding)
- optional `AdditionalCssClasses` parameter to add additional CSS classes to the main wrapper element
- any additional HTML attributes passed to the component will be added to the main wrapper element

## Examples

```csharp
<GdsContainer>
    <GdsMainWrapper>
        @Body
    </GdsMainWrapper>
</GdsContainer>
```

```csharp
<GdsContainer>
    <GdsMainWrapper AutoSpacing id="main-content" AdditionalCssClasses="govuk-body">
        @Body
    </GdsMainWrapper>
</GdsContainer>
```