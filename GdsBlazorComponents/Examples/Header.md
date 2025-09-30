# Header

Render a single GOV.UK Design System styled header component.

## Example image

![Header example](Header.png)

## How it works

- Renders a `<header class="govuk-header">` element styled according to the GOV.UK Design System.
- Displays your logo, service name, and service link.
- The `ServiceName` parameter sets the name of your service.
- The `ServiceUrl` parameter sets the link for the service.
- The `LogoUrl` parameter allows you to use your service logo image.
- Should be placed in your layout file, above the main content.

## Notes

We are currently using an older style of header component. We are planning to update to their June 2025 refreshed branding soon.

## Example

```html
<body class="govuk-template__body">
  <GdsHeader ServiceName="My Service" ServiceUrl="home" LogoUrl="@Assets["images/logos/logo.webp"]" />

  <div class="govuk-width-container">
    <main class="govuk-main-wrapper govuk-body" id="main-content" role="main">
      @Body
    </main>
  </div>

  <GdsFooter />
</body>
```
