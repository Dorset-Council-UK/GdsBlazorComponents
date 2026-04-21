# Tabs

Render a GOV.UK Design System styled tabs component.

## Example image

![Tabs example](Tabs.png)

## How it works

- Renders a `<div class="govuk-tabs" data-module="govuk-tabs">` container.
- Displays a tab list using the Heading values from each `GdsTabPanel`.
- Each tab links to its corresponding panel using fragment IDs (`href="#panel-id"`).
- The first tab is selected by default.
- Non-first panels are initially hidden using `govuk-tabs__panel--hidden`.
- GOV.UK JavaScript enhances the component to provide interactive tab behaviour.

## Simple example

```csharp
<GdsTabs Title="Contents">
    <GdsTabPanel Id="past-day" Heading="Past day">
        <GdsTable Items="PastDay">
            <HeaderContent>
                <GdsTableTh>Case manager</GdsTableTh>
                <GdsTableTh Numeric="true">Cases opened</GdsTableTh>
                <GdsTableTh Numeric="true">Cases closed</GdsTableTh>
            </HeaderContent>

            <RowTemplate Context="item">
                <GdsTableTd Value="@item.CaseManager" />
                <GdsTableTd Value="@item.CasesOpened" Numeric="true" />
                <GdsTableTd Value="@item.CasesClosed" Numeric="true" />
            </RowTemplate>
        </GdsTable>
    </GdsTabPanel>

    <GdsTabPanel Id="past-week" Heading="Past week">
        <GdsTable Items="PastWeek">
            <HeaderContent>
                <GdsTableTh>Case manager</GdsTableTh>
                <GdsTableTh Numeric="true">Cases opened</GdsTableTh>
                <GdsTableTh Numeric="true">Cases closed</GdsTableTh>
            </HeaderContent>

            <RowTemplate Context="item">
                <GdsTableTd Value="@item.CaseManager" />
                <GdsTableTd Value="@item.CasesOpened" Numeric="true" />
                <GdsTableTd Value="@item.CasesClosed" Numeric="true" />
            </RowTemplate>
        </GdsTable>
    </GdsTabPanel>

    <GdsTabPanel Id="past-month" Heading="Past month">
        <GdsTable Items="PastMonth">
            <HeaderContent>
                <GdsTableTh>Case manager</GdsTableTh>
                <GdsTableTh Numeric="true">Cases opened</GdsTableTh>
                <GdsTableTh Numeric="true">Cases closed</GdsTableTh>
            </HeaderContent>

            <RowTemplate Context="item">
                <GdsTableTd Value="@item.CaseManager" />
                <GdsTableTd Value="@item.CasesOpened" Numeric="true" />
                <GdsTableTd Value="@item.CasesClosed" Numeric="true" />
            </RowTemplate>
        </GdsTable>
    </GdsTabPanel>

    <GdsTabPanel Id="past-year" Heading="Past year">
        <GdsTable Items="PastYear">
            <HeaderContent>
                <GdsTableTh>Case manager</GdsTableTh>
                <GdsTableTh Numeric="true">Cases opened</GdsTableTh>
                <GdsTableTh Numeric="true">Cases closed</GdsTableTh>
            </HeaderContent>

            <RowTemplate Context="item">
                <GdsTableTd Value="@item.CaseManager" />
                <GdsTableTd Value="@item.CasesOpened" Numeric="true" />
                <GdsTableTd Value="@item.CasesClosed" Numeric="true" />
            </RowTemplate>
      </GdsTable>
    </GdsTabPanel>
</GdsTabs>

@code {
    private sealed record CaseManagerStats(string CaseManager, int CasesOpened, int CasesClosed);

    private static readonly IReadOnlyList<CaseManagerStats> PastDay =
   [
       new("David Francis", 3, 0),
        new("Paul Farmer", 1, 0),
        new("Rita Patel", 2, 0)
   ];

    private static readonly IReadOnlyList<CaseManagerStats> PastWeek =
    [
        new("David Francis", 24, 18),
        new("Paul Farmer", 16, 20),
        new("Rita Patel", 24, 27)
    ];

    private static readonly IReadOnlyList<CaseManagerStats> PastMonth =
    [
        new("David Francis", 98, 95),
        new("Paul Farmer", 122, 131),
        new("Rita Patel", 126, 142)
    ];

    private static readonly IReadOnlyList<CaseManagerStats> PastYear =
    [
        new("David Francis", 1380, 1472),
        new("Paul Farmer", 1129, 1083),
        new("Rita Patel", 1539, 1265)
    ];
}
```