# Button

Render a GOV.UK Design System styled button that can be used to submit forms or trigger actions.

## Example image

![Button example](Button.png)

## How it works

- Renders a `<button class="govuk-button">` element.
- The `ButtonText` parameter sets the button text content.
- The default is a submit button, but you can set `IsSubmit` to `false` to render a regular button.
- If using the button type (not submit), you can use the `OnClick` event callback to trigger actions when the button is clicked.
- The `ElementStyle` parameter allows you to set the `style` attribute for custom inline styles.
- The `Disabled` parameter disables the button when set to `true`.
- The `PreventDoubleClick` parameter adds the `govuk-button--prevent-double-click` class to prevent multiple submissions.

## Simple example (Continue button)

```csharp
<GdsButton />
```

## Other Examples

```csharp
<GdsButton ButtonText="Save and continue" />
```

```csharp
<GdsButton Disabled ButtonText="Save and continue" />
```

```csharp
<GdsButton CssClass="govuk-button--warning" ButtonText="Delete account" />
```

```csharp
<GdsButton IsSubmit="false" OnClick="@somefunction" ButtonText="Search" />
```

## Notes

- Please use GdsStartButton for the specific start button as shown on the GOV.UK Design System website.
