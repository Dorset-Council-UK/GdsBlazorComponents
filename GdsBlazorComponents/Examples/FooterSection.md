# Footer section

Render GOV.UK Design System styled footer section for use within the `GdsFooter` component.

## How it works
- renders and wraps a `GdsGridColumn` component for use in GOV.UK Design System footer navigation
- use the `Width` parameter to specify the width of the footer section, for example: `Width="GdsGridColumnWidth.TwoThirds"` or `Width="GdsGridColumnWidth.TwoThirdsFromDesktop"`
- for a combination of GDS widths use the `Widths` parameter, for example: `Widths="[GdsGridColumnWidth.TwoThirds, GdsGridColumnWidth.OneHalfFromDesktop]"`
- if no width is specified, the footer section will default to full width
- optional `AdditionalCssClasses` parameter to add additional CSS classes to the footer section element
- any additional HTML attributes passed to the component will be added to the footer section element

## Examples

See the [Footer](Footer.md) component for examples of how to use the `GdsFooterSection` component within a footer.

See the [GridColumn](GridColumn.md) component for examples of how to set the width and additional parameters.