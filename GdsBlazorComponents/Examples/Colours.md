# Colours

CSS custom variables for GOV.UK Design System colours, making it easy to use consistent colours in your custom styles.

## How it works

- The GDS Blazor Components stylesheet defines CSS custom properties in the `:root` scope for all GOV.UK Design System colours.
- These variables are prefixed with `--govuk-frontend-color-` followed by the colour name.
- You can use these variables in your custom CSS or inline styles throughout your application.
- The colour values are from the GOV.UK Frontend colour palette [Colour](https://design-system.service.gov.uk/styles/colour/).

## Available colours

The following colour variables are available:

```css
--govuk-frontend-color-red
--govuk-frontend-color-yellow
--govuk-frontend-color-green
--govuk-frontend-color-blue
--govuk-frontend-color-dark-blue
--govuk-frontend-color-light-blue
--govuk-frontend-color-purple
--govuk-frontend-color-black
--govuk-frontend-color-dark-grey
--govuk-frontend-color-mid-grey
--govuk-frontend-color-light-grey
--govuk-frontend-color-white
--govuk-frontend-color-light-purple
--govuk-frontend-color-bright-purple
--govuk-frontend-color-pink
--govuk-frontend-color-light-pink
--govuk-frontend-color-orange
--govuk-frontend-color-brown
--govuk-frontend-color-light-green
--govuk-frontend-color-turquoise
```

## Example use in your CSS

You can use these colour variables in your custom stylesheets:

```css
.my-thing {
    color: var(--govuk-frontend-color-red);
}
```