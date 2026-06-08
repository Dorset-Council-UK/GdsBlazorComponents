using System.ComponentModel;

namespace GdsBlazorComponents;

public enum GdsGridColumnWidth
{
    [Description("govuk-grid-column-full")]
    Full,

    [Description("govuk-grid-column-one-half")]
    OneHalf,

    [Description("govuk-grid-column-one-half-from-desktop")]
    OneHalfFromDesktop,

    [Description("govuk-grid-column-one-third")]
    OneThird,

    [Description("govuk-grid-column-one-third-from-desktop")]
    OneThirdFromDesktop,

    [Description("govuk-grid-column-two-thirds")] 
    TwoThirds,

    [Description("govuk-grid-column-two-thirds-from-desktop")] 
    TwoThirdsFromDesktop,

    [Description("govuk-grid-column-one-quarter")]
    OneQuarter,

    [Description("govuk-grid-column-one-quarter-from-desktop")]
    OneQuarterFromDesktop,

    [Description("govuk-grid-column-three-quarters")]
    ThreeQuarters,

    [Description("govuk-grid-column-three-quarters-from-desktop")]
    ThreeQuartersFromDesktop,
}
