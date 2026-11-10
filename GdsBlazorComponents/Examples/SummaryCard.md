# Summary Card

Render GOV.UK Design System styled summary card component

## How it works
- renders a summary card styled according to the GOV.UK Design System
- supports additional CSS classes via the `AdditionalCssClasses` parameter
- supports any additional HTML attributes via the `AdditionalAttributes` parameter

### Title
- `GdsSummaryCardTitle` renders a summary card title (heading) styled according to the GOV.UK Design System
- use as a child of `GdsSummaryCardTitleWrapper`

### Content
- `GdsSummaryCardContent` renders a summary card content styled according to the GOV.UK Design System
See [summary list](SummaryList.md) for details of common summary card content.

### Card actions
- `GdsSummaryCardActions` renders a summary card actions (ul) styled according to the GOV.UK Design System
- use as a child of `GdsSummaryCardTitleWrapper`

### Card action
- `GdsSummaryCardAction` renders a summary card action (li) styled according to the GOV.UK Design System
- use as a child of `GdsSummaryCardActions`

## Examples

### Basic
```razor
<GdsSummaryCard>
    <GdsSummaryCardTitleWrapper>
        <GdsSummaryCardTitle Level="2" Size="GdsSize.Large">Lead tenant</GdsSummaryCardTitle>
    </GdsSummaryCardTitleWrapper>
    <GdsSummaryCardContent>
        <GdsSummaryList>
            <GdsSummaryListRow>
                <GdsSummaryListKey>Age</GdsSummaryListKey>
                <GdsSummaryListValue>38</GdsSummaryListValue>
                <GdsSummaryListActions>
                    <GdsLink Href="#">Change<span class="govuk-visually-hidden"> age (Lead tenant)</span></GdsLink>
                </GdsSummaryListActions>
            </GdsSummaryListRow>
            <GdsSummaryListRow>
                <GdsSummaryListKey>Nationality</GdsSummaryListKey>
                <GdsSummaryListValue>UK national resident in UK</GdsSummaryListValue>
                <GdsSummaryListActions>
                    <GdsLink Href="#">Change<span class="govuk-visually-hidden"> nationality (Lead tenant)</span></GdsLink>
                </GdsSummaryListActions>
            </GdsSummaryListRow>
            <GdsSummaryListRow>
                <GdsSummaryListKey>Working situation</GdsSummaryListKey>
                <GdsSummaryListValue>Part time – less than 30 hours a week</GdsSummaryListValue>
                <GdsSummaryListActions>
                    <GdsLink Href="#">Change<span class="govuk-visually-hidden"> working situation (Lead tenant)</span></GdsLink>
                </GdsSummaryListActions>
            </GdsSummaryListRow>
        </GdsSummaryList>
    </GdsSummaryCardContent>
</GdsSummaryCard>
```

### With card actions
```razor
<GdsSummaryCard>
    <GdsSummaryCardTitleWrapper>
        <GdsSummaryCardTitle Level="2" Size="GdsSize.Large">University of Gloucestershire</GdsSummaryCardTitle>
        <GdsSummaryCardActions>
            <GdsSummaryCardAction>
                <GdsLink Href="#">Delete choice<span class="govuk-visually-hidden"> (University of Gloucestershire)</span></GdsLink>
            </GdsSummaryCardAction>
            <GdsSummaryCardAction>
                <GdsLink Href="#">Withdraw<span class="govuk-visually-hidden"> (University of Gloucestershire)</span></GdsLink>
            </GdsSummaryCardAction>
        </GdsSummaryCardActions>
    </GdsSummaryCardTitleWrapper>
    <GdsSummaryCardContent>
        <GdsSummaryList>
            <GdsSummaryListRow>
                <GdsSummaryListKey>Course</GdsSummaryListKey>
                <GdsSummaryListValue>English (3DMD)<br>PGCE with QTS full time</GdsSummaryListValue>
            </GdsSummaryListRow>
            <GdsSummaryListRow>
                <GdsSummaryListKey>Location</GdsSummaryListKey>
                <GdsSummaryListValue>School name<br>Road, City, SW1 1AA</GdsSummaryListValue>
            </GdsSummaryListRow>
        </GdsSummaryList>
    </GdsSummaryCardContent>
</GdsSummaryCard>
```
