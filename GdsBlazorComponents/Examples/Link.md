# Link

Render GOV.UK Design System styled link component

## How it works
- renders a link styled according to the GOV.UK Design System
- use `Href` parameter to specify where the link goes
- use `NoVisitedState` parameter to remove the visited state styling from the link
- use `Inverse` parameter to render the link in inverse mode (white text on dark background)
- use `NoUnderline` parameter to remove the underline from the link
- supports additional CSS classes via the `AdditionalCssClasses` parameter
- supports any additional HTML attributes via the `AdditionalAttributes` parameter

## Examples

### Basic
```csharp
<GdsLink Href="user/something">Something</GdsLink>
```

### No visited state
```csharp
<GdsLink Href="user/something" NoVisitedState>Something</GdsLink>
```

### Additional CSS classes
```csharp
<GdsLink Href="user/something" AdditionalCssClasses="govuk-!-font-size-27">Something</GdsLink>
```

### Attributes
```csharp
<GdsLink Href="user/something" rel="noreferrer noopener" target="_blank">
	Something (opens in new tab)
</GdsLink>
```

### Using Blazor features
```csharp
<GdsLink Href="user/something" @onclick="DoSomething" @onclick:preventDefault>Something</GdsLink>
```
