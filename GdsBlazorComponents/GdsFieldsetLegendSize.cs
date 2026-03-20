using System.ComponentModel;

namespace GdsBlazorComponents;

public enum GdsFieldsetLegendSize
{
	[Description("govuk-fieldset__legend--s")]
	Small,

	[Description("govuk-fieldset__legend--m")]
	Medium,

	[Description("govuk-fieldset__legend--l")]
	Large,

	[Description("govuk-fieldset__legend--xl")]
	ExtraLarge,
}