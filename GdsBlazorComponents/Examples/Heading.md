# Heading

Render GOV.UK Design System styled heading.

## How it works
- renders a `<h1>` to `<h6>` heading element styled according to the GOV.UK Design System
- use the `Level` parameter to specify the heading level 1 to 6
- use the `Size` parameter to override the automatic heading size (small, medium, large, extra large)
- optional `AdditionalCssClasses` parameter to add additional CSS classes to the heading element
- any additional HTML attributes passed to the component will be added to the heading element

## Size
- ExtraLarge
- Large
- Medium
- Small

## Automatic size by heading level
- Level 1: Extra Large
- Level 2: Large
- Level 3: Medium
- Level 4, 5, 6: Small

## Examples

```csharp
<GdsHeading Level="1">Heading 1</GdsHeading>
```

```csharp
<GdsHeading Level="2">Heading 2</GdsHeading>
```

```csharp
<GdsHeading Level="3" Size="GdsSize.Small">Heading 3 - Overridden size</GdsHeading>
```