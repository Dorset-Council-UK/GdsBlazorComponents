# Input Text Search

This pattern renders an inline search box using GOV.UK Design System styled controls.

> [!INFO]
> This is a pattern developed by Dorset Council. 
> The implementation is not documented or recommended by GDS.
> Not recommended for public facing applications. 

## Example image

![Input text search example](InputTextSearch.png)

## How it works

- Renders a composite pattern using a `govuk-input__wrapper` element containing a GdsInputText and GdsButton control.
- The `@bind-Value` attribute allows two-way data binding for the input value.
- The `OnClick` event callback on the button allows you to define custom logic that executes when the button is clicked, such as performing a search action.
- You should use the number after `input--width-` to control the width of the input. 

## Example with callback

```csharp
<div class="govuk-input__wrapper">
    <GdsInputText @bind-Value="_bindProperty" class="govuk-input govuk-input--width-10" />
    <GdsButton class="govuk-button--secondary" IsSubmit="false" style="margin-bottom: 0.1rem;" Text="Search" OnClick="@OnClickEvent" />
</div>
```
