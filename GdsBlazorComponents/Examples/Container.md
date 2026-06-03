# Container

Render GOV.UK Design System styled container.

## How it works

- renders a `<div class="govuk-width-container` element styled according to the GOV.UK Design System.
- optional `AdditionalCssClasses` parameter to add additional CSS classes to the container element
- any additional HTML attributes passed to the component will be added to the container element

## Examples

```csharp
<GdsContainer>
    <div>Container example</div>
</GdsContainer>
```

```csharp
<GdsContainer AdditionalCssClasses="flex-fill">
    <div>Container example</div>
</GdsContainer>
```

```csharp
<GdsContainer id="my-container" data-something="testing">
    <div>Container example</div>
</GdsContainer>
```