# Skip Link

Render a single GOV.UK Design System styled skip link to help keyboard-only users skip to the main content on a page.

## How it works

- Renders a `<a class="govuk-skip-link">` element that allows keyboard and screen reader users to quickly skip to the main content of the page.
- The `Href` parameter sets the target element's ID (e.g., `#main-content`) that the skip link will jump to.
- Should be placed at the very top of the page, before the main content. Often in your Blazor layout file.

## Example

```html
<body class="govuk-template__body">
  <GdsSkipLink Href="#main-content" />

  <div class="govuk-width-container">
    <main class="govuk-main-wrapper govuk-body" id="main-content" role="main">
      @Body
    </main>
  </div>
</body>
```
