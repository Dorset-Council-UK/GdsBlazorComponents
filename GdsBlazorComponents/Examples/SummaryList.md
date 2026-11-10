# Summary List

Render GOV.UK Design System styled summary list component

## How it works
- renders a description link (dl) styled according to the GOV.UK Design System
- use the `NoBorder` parameter to removed separating borders between rows
- supports additional CSS classes via the `AdditionalCssClasses` parameter
- supports any additional HTML attributes via the `AdditionalAttributes` parameter

### Rows
- use the `GdsSummaryListRow` component to define each row in the summary list
- use the `NoBorder` parameter to remove the separating border for that row
- use the `NoActions` parameter when the row does not have any actions to display, but other rows do have actions

### Key
- renders a description term (dt) styled according to the GOV.UK Design System
- use the `GdsSummaryListKey` component to define the key for each row

## Value
- renders a description definition (dd) styled according to the GOV.UK Design System
- use the `GdsSummaryListValue` component to define the value for each row

### Actions
- renders a description definition (dd) styled according to the GOV.UK Design System
- use the `GdsSummaryListActions` component to define actions for each row

### Actions list
- `GdsSummaryListActionsList` renders an unordered list (ul) styled according to the GOV.UK Design System
- used as a child of the `GdsSummaryListActions` component to define multiple actions for each row

## Action list item
- `GdsSummaryListActionsListItem` renders a list item (li) styled according to the GOV.UK Design System
- use as a child of the `GdsSummaryListActionsList` component to define each action in the list

## Examples

### Basic
```razor
<GdsSummaryList>
    <GdsSummaryListRow>
        <GdsSummaryListKey>Name</GdsSummaryListKey>
        <GdsSummaryListValue>Sarah Phillips</GdsSummaryListValue>
        <GdsSummaryListActions>
            <GdsLink Href="#">Change<span class="govuk-visually-hidden"> name</span></GdsLink>
        </GdsSummaryListActions>
    </GdsSummaryListRow>
    <GdsSummaryListRow>
        <GdsSummaryListKey>Address</GdsSummaryListKey>
        <GdsSummaryListValue>72 Guild Street<br>London<br>SE23 6FH</GdsSummaryListValue>
        <GdsSummaryListActions>
            <GdsLink Href="#">Change<span class="govuk-visually-hidden"> address</span></GdsLink>
        </GdsSummaryListActions>
    </GdsSummaryListRow>
</GdsSummaryList>
```

### Full
```razor
<GdsSummaryList>
    <GdsSummaryListRow>
        <GdsSummaryListKey>Name</GdsSummaryListKey>
        <GdsSummaryListValue>Sarah Phillips</GdsSummaryListValue>
        <GdsSummaryListActions>
            <GdsLink Href="#">Change<span class="govuk-visually-hidden"> name</span></GdsLink>
        </GdsSummaryListActions>
    </GdsSummaryListRow>
    <GdsSummaryListRow>
        <GdsSummaryListKey>Address</GdsSummaryListKey>
        <GdsSummaryListValue>72 Guild Street<br>London<br>SE23 6FH</GdsSummaryListValue>
        <GdsSummaryListActions>
            <GdsLink Href="#">Change<span class="govuk-visually-hidden"> address</span></GdsLink>
        </GdsSummaryListActions>
    </GdsSummaryListRow>
    <GdsSummaryListRow>
        <GdsSummaryListKey>Contact details</GdsSummaryListKey>
        <GdsSummaryListValue>
            <p>07700 900457</p>
            <p>sarah.phillips@example.com</p>
        </GdsSummaryListValue>
        <GdsSummaryListActions>
            <GdsSummaryListActionsList>
                <GdsSummaryListActionsListItem>
                    <GdsLink Href="#">Add<span class="govuk-visually-hidden"> contact details</span></GdsLink>
                </GdsSummaryListActionsListItem>
                <GdsSummaryListActionsListItem>
                    <GdsLink Href="#">Change<span class="govuk-visually-hidden"> contact details</span></GdsLink>
                </GdsSummaryListActionsListItem>
            </GdsSummaryListActionsList>
        </GdsSummaryListActions>
    </GdsSummaryListRow>
</GdsSummaryList>
```
