# Tag

Render a GOV.UK Design System styled tag component.

## Example image

![Coloured Tag example](TagColours.png)

## How it works

- Renders a ```<strong class="govuk-tag">``` element styled according to the GOV.UK Design System.
- Displays text using the `Text` parameter.
- Optionally styled using the `Colour` parameter.

## Simple example

```csharp
<GdsTag Text="Completed" />
```

## Example using Colour

```csharp
<GdsTag Colour="GdsTagColour.Turquoise" Text="Active" />

```