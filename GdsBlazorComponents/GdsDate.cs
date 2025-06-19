using System.Globalization;

namespace GdsBlazorComponents;

/// <summary>
///     <para>Represents a GDS Date in Blazor.</para>
///     <para>Derived from the <c>DayText</c>, <c>MonthText</c>, and <c>YearText</c> fields.</para>
///     <para>When getting the <c>DateUtc</c> it attempts to parse those fields into a valid <see cref="DateTimeOffset"/>.</para>
///     <para>When setting the <c>DateUtc</c> it populates the individual text fields with the corresponding day, month, and year parts.</para>
/// </summary>
public class GdsDate
{
    [GdsFieldErrorClass(GdsFieldTypes.Date)]
    public string? DayText { get; set; }

    [GdsFieldErrorClass(GdsFieldTypes.Date)]
    public string? MonthText { get; set; }

    [GdsFieldErrorClass(GdsFieldTypes.Date)]
    public string? YearText { get; set; }

    public int? Day => int.TryParse(DayText, CultureInfo.InvariantCulture, out var day) ? day : null;
    public int? Month => int.TryParse(MonthText, CultureInfo.InvariantCulture, out var month) ? month : null;
    public int? Year => int.TryParse(YearText, CultureInfo.InvariantCulture, out var year) ? year : null;

    public DateTimeOffset? DateUtc
    {
        get
        {
            if (Day.HasValue && Month.HasValue && Year.HasValue)
            {
                try
                {
                    return new DateTimeOffset(Year.Value, Month.Value, Day.Value, 0, 0, 0, TimeSpan.Zero);
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }
        set
        {
            if (value.HasValue)
            {
                var date = value.Value;
                var format = CultureInfo.InvariantCulture.NumberFormat;
                DayText = date.Day.ToString(format);
                MonthText = date.Month.ToString(format);
                YearText = date.Year.ToString(format);
            }
            else
            {
                DayText = MonthText = YearText = null;
            }
        }
    }

    public GdsDate()
    {
    }

    public GdsDate(DateTimeOffset dateTimeOffset)
    {
        DateUtc = dateTimeOffset;
    }
}
