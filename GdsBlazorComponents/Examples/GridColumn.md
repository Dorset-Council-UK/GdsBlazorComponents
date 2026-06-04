# Grid column

Render GOV.UK Design System styled grid column.

## How it works
- renders a `<div class="govuk-grid-column` element styled according to the GOV.UK Design System
- use the `Width` parameter to specify the width of the column, for example: `Width="GdsGridColumnWidth.TwoThirds"` or `Width="GdsGridColumnWidth.TwoThirdsFromDesktop"`
- for a combination of GDS widths use the `Widths` parameter, for example: `Widths="[GdsGridColumnWidth.TwoThirds, GdsGridColumnWidth.OneHalfFromDesktop]"`
- if no width is specified, the column will default to full width
- optional `AdditionalCssClasses` parameter to add additional CSS classes to the column element
- any additional HTML attributes passed to the component will be added to the column element

## Widths
- Full
- OneHalf
- OneHalfFromDesktop
- OneThird
- OneThirdFromDesktop
- TwoThirds
- TwoThirdsFromDesktop
- OneQuarter
- OneQuarterFromDesktop
- ThreeQuarters
- ThreeQuartersFromDesktop

## Examples

See the [GridRow](GridRow.md) component for examples of how to use the `GdsGridColumn` component within a grid row.