# Button

Render a GOV.UK Design System styled button that can be used to submit forms or trigger actions.

## Example image

![Button example](Button.png)

## How it works

- Renders a `<button class="govuk-button">` element.
- The `Text` parameter sets the button text content.
- The default is a submit button, but you can set `IsSubmit` to `false` to render a regular button.
- The `OnClick` event is only used if you select `IsSubmit` to `false`.
- You can pass additional HTML attributes, such as `class` and `style`, to this component.
- The `Disabled` parameter disables the button when set to `true`.
- The `PreventDoubleClick` parameter adds the `govuk-button--prevent-double-click` class to prevent multiple submissions.

## Simple example (Continue button)

```csharp
<GdsButton />
```

## Other Examples

```csharp
<GdsButton Text="Save and continue" />
```

```csharp
<GdsButton Disabled Text="Save and continue" />
```

```csharp
<GdsButton class="govuk-button--warning" Text="Delete account" />
```

```csharp
<GdsButton IsSubmit="false" OnClick="@somefunction" Text="Search" />
```

## Notes

- Please use GdsStartButton for the specific start button as shown on the GOV.UK Design System website.
