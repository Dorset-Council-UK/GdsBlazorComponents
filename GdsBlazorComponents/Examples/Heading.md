# Heading

Render GOV.UK Design System styled heading.

## How it works
- renders a `<h1>` to `<h6>` heading element styled according to the GOV.UK Design System
- use the `Level` parameter to specify the heading level 1 to 6
- use the `Size` parameter to specify the heading size (small, medium, large, extra large)
- if no size is specified, the heading will default to extra large size
- optional `AdditionalCssClasses` parameter to add additional CSS classes to the heading element
- any additional HTML attributes passed to the component will be added to the heading element

## Size
- Small
- Medium
- Large
- ExtraLarge

## Examples

```csharp
<GdsHeading Level="1">Extra large heading</GdsHeading>
```

```csharp
<GdsHeading Level="2" Size="GdsSize.Large">Large heading</GdsHeading>
```

```csharp
<GdsHeading Level="3" Size="GdsSize.Medium">Medium heading</GdsHeading>
```