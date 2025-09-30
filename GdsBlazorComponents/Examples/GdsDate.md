# GdsDate

`GdsDate` is a flexible model designed for GDS styled Date Input components.

With this model, users can enter any values for the day, month, and year fields; Even if the date is incomplete or doesn't follow the usual format. This makes it easier to handle real-world input and guide users toward valid dates.

Following GOV.UK standards, the Date Input component uses `<input type="text">` fields for day, month, and year. The `GdsDate` model captures exactly what the user types, and also provides parsed values, including the final complete date if possible.

You'll find a consistent set of properties: `DayText`, `MonthText`, `YearText` (the raw text entered), and `Day`, `Month`, `Year`, `DateUtc` (the parsed values).

Whenever users update the text fields, the class automatically tries to set the corresponding parsed values.

## Designed for use with

- `GdsInputDate` and `GdsInputPartialDate` (which use Blazor's `InputText`)