# Table

Render a GOV.UK Design System styled tabel component.

## Example images

![Table example with value and formatting](Tabel1.png)
![Table example with ChildContent](Tabel2.png)

## How it works

- Renders a ```<table class="govuk-table>``` element styled according to the GOV.UK Design System.
- Table supports `Caption`, `CaptionSize` and `FirstCellIsHeader`.
  - Cells (`GdsTableTh` and `GdsTableTd`) support `Numeric`.

## Simple example (using Formatting)

```csharp
<GdsTable T="Payment" Items="@Payments" Caption="Months and rates" CaptionSize="GdsTableCaptionSize.Large" FirstCellIsHeader>
    <HeaderContent>
        <GdsTableTh>Month you apply</GdsTableTh>
        <GdsTableTh Numeric>Rate for vehicles</GdsTableTh>
    </HeaderContent>
    <RowTemplate Context="item">
        <GdsTableTd Value="@item.Date" Format="MMMM" />
        <GdsTableTd Value="@item.Amount" Format="C0" />
    </RowTemplate>
</GdsTable>

@code {
    private record Payment(DateTime Date, int Amount);

    private Payment[] Payments { get; set; } = [
        new(new DateTime(2026, 1, 1), 95),
        new(new DateTime(2026, 2, 1), 55),
        new(new DateTime(2026, 3, 1), 125),
    ];
}
```

## Example using ChildContnet

```csharp
<GdsTable T="Member" Items="@Members" Caption="Members" Density="GdsTableDensity.SmallTextUntilTablet">
    <HeaderContent>
        <GdsTableTh>Date started</GdsTableTh>
        <GdsTableTh>Full name</GdsTableTh>
        <GdsTableTh Numeric>Age</GdsTableTh>
        <GdsTableTh>Is Active</GdsTableTh>
    </HeaderContent>
    <RowTemplate Context="item">
        <GdsTableTd Value="@item.StartDate" Format="dd/MM/yyyy" />
        <GdsTableTd Value="@item.Name" />
        <GdsTableTd Value="@item.Age" Numeric />
        <GdsTableTd>
            <GdsTag Colour="@(item.IsActive? GdsTagColour.Green: GdsTagColour.Red)" Text="@(item.IsActive ? "yes" : "no")" />
        </GdsTableTd>
    </RowTemplate>
</GdsTable>

@code {
    private record Member(DateTime StartDate, bool IsActive, int Age, string Name);

    private Member[] Members { get; set; } = [
        new(new DateTime(2024, 05, 01), true, 25, "Zabrina Muris"),
        new(new DateTime(2025, 10, 26), false, 40, "Claudie Mugford"),
        new(new DateTime(2024, 08, 24), true, 36, "Garald Pervoe"),
        new(new DateTime(2024, 03, 05), true, 34, "Emili Hundall"),
        new(new DateTime(2024, 06, 05), false, 37, "Tabby Larrett"),
        new(new DateTime(2024, 03, 29), true, 46, "Barbra Vannuccinii"),
        new(new DateTime(2025, 10, 08), true, 23, "Jean Swidenbank"),
        new(new DateTime(2024, 11, 04), false, 42, "Charis Groucock"),
        new(new DateTime(2026, 01, 04), false, 21, "Jamesy Bramer"),
        new(new DateTime(2024, 09, 11), false, 36, "Arlen Lemoir")
    ];
}
```