# Grid Row

Render GOV.UK Design System styled grid row.

## How it works

- renders a `<div class="govuk-grid-row` element styled according to the GOV.UK Design System.
- optional `AdditionalCssClasses` parameter to add additional CSS classes to the container element
- any additional HTML attributes passed to the component will be added to the container element

## Examples

```csharp
<GdsGridRow>
    <div class="govuk-grid-column-two-thirds">
        <h1 class="govuk-heading-xl">Two-thirds column</h1>
        <p class="govuk-body">This is a paragraph inside a two-thirds wide column</p>
    </div>
    <div class="govuk-grid-column-one-third">
        <h2 class="govuk-heading-m">One-third column</h2>
        <p class="govuk-body">This is a paragraph inside a one-third wide column</p>
    </div>
</GdsGridRow>
```

```csharp
<GdsGridRow AdditionalCssClasses="govuk-!-padding-bottom-6">
    <div class="govuk-grid-column-two-thirds">
        <h1 class="govuk-heading-xl">Two-thirds column</h1>
        <p class="govuk-body">A two-thirds wide column with additional CSS classes</p>
    </div>
    <div class="govuk-grid-column-one-third">
        <h2 class="govuk-heading-m">One-third column</h2>
        <p class="govuk-body">This is a paragraph inside a one-third wide column</p>
    </div>
</GdsGridRow>
```

```csharp
<GdsGridRow id="my-row" data-something="testing">
    <div class="govuk-grid-column-two-thirds">
        <h1 class="govuk-heading-xl">Two-thirds column</h1>
        <p class="govuk-body">A two-thirds wide column with additional HTML attributes</p>
    </div>
    <div class="govuk-grid-column-one-third">
        <h2 class="govuk-heading-m">One-third column</h2>
        <p class="govuk-body">This is a paragraph inside a one-third wide column</p>
    </div>
</GdsGridRow>
```