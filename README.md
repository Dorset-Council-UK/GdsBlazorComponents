[![NuGet Version](https://img.shields.io/nuget/v/Dorset-Council-UK.GdsBlazorComponents?style=flat&logo=nuget)](https://www.nuget.org/packages/Dorset-Council-UK.GdsBlazorComponents/)

# GDS Blazor Components

This project contains Blazor components styled using the GOV.UK Design System. It can be used in any C# Blazor project that want to use GDS components.

This was originally built for our [Dorset Council - Flood Online Reporting Tool](https://github.com/Dorset-Council-UK/FloodOnlineReportingTool.Public) project.

We expect to use this project widely in our other projects to ensure a consistent use of GDS components within any Blazor projects that we develop using Government design principles.

## Getting Started

Add the `@using` directive to your file or `_Imports.razor`
```razor
@using GdsBlazorComponents
```

### Blazor Web App

Your `App.razor` should include the following GOV.UK template elements.

This is a partial example to show the required setup. Combine these lines into your existing Blazor markup as appropriate:

```html
<!DOCTYPE html>
<html lang="en-GB" class="govuk-template">

<head>
  <link rel="stylesheet" href="@Assets["_content/Dorset-Council-UK.GdsBlazorComponents/gds.css"]">
  <!-- other head content -->
</head>

<body class="govuk-template__body govuk-frontend-supported">
  <!-- other body content -->
  <script type="module" src="@Assets["_content/Dorset-Council-UK.GdsBlazorComponents/gds.js"]"></script>
</body>
</html>
```

### Blazor WebAssembly

Your `index.html` should include the following GOV.UK template elements.

This is a partial example to show the required setup. Combine these lines into your existing Blazor WebAssembly markup as appropriate:

```html
<!DOCTYPE html>
<html lang="en-GB" class="govuk-template">

<head>
  <link rel="stylesheet" href="_content/Dorset-Council-UK.GdsBlazorComponents/gds.css">
  <!-- other head content -->
</head>

<body class="govuk-template__body govuk-frontend-supported">
  <!-- other body content -->
  <script type="module" src="_content/Dorset-Council-UK.GdsBlazorComponents/gds.js"></script>
</body>
</html>
```

## Component Examples

- [GdsBreadcrumbs](https://github.com/Dorset-Council-UK/GdsBlazorComponents/blob/main/GdsBlazorComponents/Examples/Breadcrumbs.md)
- [GdsCheckbox](https://github.com/Dorset-Council-UK/GdsBlazorComponents/blob/main/GdsBlazorComponents/Examples/Checkbox.md)
- [GdsCheckboxes](https://github.com/Dorset-Council-UK/GdsBlazorComponents/blob/main/GdsBlazorComponents/Examples/Checkboxes.md)
- [GdsErrorMessage](https://github.com/Dorset-Council-UK/GdsBlazorComponents/blob/main/GdsBlazorComponents/Examples/ErrorMessage.md)
- [GdsErrorSummary](https://github.com/Dorset-Council-UK/GdsBlazorComponents/blob/main/GdsBlazorComponents/Examples/ErrorSummary.md)
- [GdsFieldsetGroup](https://github.com/Dorset-Council-UK/GdsBlazorComponents/blob/main/GdsBlazorComponents/Examples/FieldsetGroup.md)
- [GdsFileInput](https://github.com/Dorset-Council-UK/GdsBlazorComponents/blob/main/GdsBlazorComponents/Examples/FileInput.md)
- [GdsFooter](https://github.com/Dorset-Council-UK/GdsBlazorComponents/blob/main/GdsBlazorComponents/Examples/Footer.md)
- [GdsFormGroup](https://github.com/Dorset-Council-UK/GdsBlazorComponents/blob/main/GdsBlazorComponents/Examples/FormGroup.md)
- [GdsHeader](https://github.com/Dorset-Council-UK/GdsBlazorComponents/blob/main/GdsBlazorComponents/Examples/Header.md)
- [GdsHint](https://github.com/Dorset-Council-UK/GdsBlazorComponents/blob/main/GdsBlazorComponents/Examples/Hint.md)
- [GdsInputDate](https://github.com/Dorset-Council-UK/GdsBlazorComponents/blob/main/GdsBlazorComponents/Examples/InputDate.md)
- [GdsInputNumber](https://github.com/Dorset-Council-UK/GdsBlazorComponents/blob/main/GdsBlazorComponents/Examples/InputNumber.md)
- [GdsInputPartialDate](https://github.com/Dorset-Council-UK/GdsBlazorComponents/blob/main/GdsBlazorComponents/Examples/InputPartialDate.md)
- [GdsInputText](https://github.com/Dorset-Council-UK/GdsBlazorComponents/blob/main/GdsBlazorComponents/Examples/InputText.md)
- [GdsInsetText](https://github.com/Dorset-Council-UK/GdsBlazorComponents/blob/main/GdsBlazorComponents/Examples/InsetText.md)
- [GdsLabel](https://github.com/Dorset-Council-UK/GdsBlazorComponents/blob/main/GdsBlazorComponents/Examples/Label.md)
- [GdsNotificationBanner](https://github.com/Dorset-Council-UK/GdsBlazorComponents/blob/main/GdsBlazorComponents/Examples/NotificationBanner.md)
- [GdsPhaseBanner](https://github.com/Dorset-Council-UK/GdsBlazorComponents/blob/main/GdsBlazorComponents/Examples/PhaseBanner.md)
- [GdsRadio](https://github.com/Dorset-Council-UK/GdsBlazorComponents/blob/main/GdsBlazorComponents/Examples/Radio.md)
- [GdsRadios](https://github.com/Dorset-Council-UK/GdsBlazorComponents/blob/main/GdsBlazorComponents/Examples/Radios.md)
- [GdsSkipLink](https://github.com/Dorset-Council-UK/GdsBlazorComponents/blob/main/GdsBlazorComponents/Examples/SkipLink.md)
- [GdsSpinner](https://github.com/Dorset-Council-UK/GdsBlazorComponents/blob/main/GdsBlazorComponents/Examples/Spinner.md)
- [GdsWarning](https://github.com/Dorset-Council-UK/GdsBlazorComponents/blob/main/GdsBlazorComponents/Examples/Warning.md)
- [GdsTag](https://github.com/Dorset-Council-UK/GdsBlazorComponents/blob/main/GdsBlazorComponents/Examples/Tag.md)
- [GdsPanel](https://github.com/Dorset-Council-UK/GdsBlazorComponents/blob/main/GdsBlazorComponents/Examples/Panel.md)

### Other examples:

- [Colours](https://github.com/Dorset-Council-UK/GdsBlazorComponents/blob/main/GdsBlazorComponents/Examples/Colours.md)
- [Validation Classes](https://github.com/Dorset-Council-UK/GdsBlazorComponents/blob/main/GdsBlazorComponents/Examples/ValidationClasses.md)

## Bugs

Please report any bugs via the issue tracker in GitHub.

## Contributing

Please see our guide on [contributing](https://github.com/Dorset-Council-UK/GdsBlazorComponents/blob/main/CONTRIBUTING.md) if you're interested in getting involved.

## Reporting security issues

Security issues should be reported privately, to the project team via email at [gis@dorsetcouncil.gov.uk](mailto:gis@dorsetcouncil.gov.uk). You should receive a response within 24 hours during business days.

## Core developers

The Gds Blazor Components are a Dorset Council Open Source project. The core developers are currently Dorset Council staff. If you want to become a core developer, Please see our guide on [contributing](https://github.com/Dorset-Council-UK/GdsBlazorComponents/blob/main/CONTRIBUTING.md).

## Licence

Unless stated otherwise, the codebase is released under the MIT License. This covers both the codebase and any sample code in the documentation.
