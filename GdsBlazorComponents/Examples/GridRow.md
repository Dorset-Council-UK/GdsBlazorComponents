# Grid Row

Render GOV.UK Design System styled grid row.

## How it works

- renders a `<div class="govuk-grid-row` element styled according to the GOV.UK Design System.
- optional `AdditionalCssClasses` parameter to add additional CSS classes to the container element
- any additional HTML attributes passed to the component will be added to the container element

## Examples

```csharp
<GdsGridRow>
    <GdsGridColumn Width="GdsGridColumnWidth.TwoThirds">
        <GdsHeading Level="1">Two-thirds column</GdsHeading>
        <p class="govuk-body">This is a paragraph inside a two-thirds wide column</p>
    </GdsGridColumn>
    <GdsGridColumn Width="GdsGridColumnWidth.OneThird">
        <GdsHeading Level="2" Size="GdsSize.Medium">One-third column</GdsHeading>
        <p class="govuk-body">This is a paragraph inside a one-third wide column</p>
    </GdsGridColumn>
</GdsGridRow>
```

```csharp
<GdsGridRow AdditionalCssClasses="govuk-!-padding-bottom-6">
    <GdsGridColumn Width="GdsGridColumnWidth.TwoThirds">
        <GdsHeading Level="1">Two-thirds column</GdsHeading>
        <p class="govuk-body">A two-thirds wide column with additional CSS classes</p>
    </GdsGridColumn>
    <GdsGridColumn Width="GdsGridColumnWidth.OneThird">
        <GdsHeading Level="2" Size="GdsSize.Medium">One-third column</GdsHeading>
        <p class="govuk-body">This is a paragraph inside a one-third wide column</p>
    </GdsGridColumn>
</GdsGridRow>
```

```csharp
<GdsGridRow id="my-row" data-something="testing">
    <GdsGridColumn Widths="[GdsGridColumnWidth.TwoThirds, GdsGridColumnWidth.OneHalfFromDesktop]">
        <GdsHeading Level="1">Two-thirds column</GdsHeading>
        <p class="govuk-body">A two-thirds wide column with additional HTML attributes</p>
    </GdsGridColumn>
    <GdsGridColumn Widths="[GdsGridColumnWidth.OneThird, GdsGridColumnWidth.OneHalfFromDesktop]">
        <GdsHeading Level="2" Size="GdsSize.Medium">One-third column</GdsHeading>
        <p class="govuk-body">This is a paragraph inside a one-third wide column</p>
    </GdsGridColumn>
</GdsGridRow>
```