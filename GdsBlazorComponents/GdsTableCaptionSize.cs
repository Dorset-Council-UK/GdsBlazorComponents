using System.ComponentModel;

namespace GdsBlazorComponents;

public enum GdsTableCaptionSize
{
	Default,

	[Description("govuk-table__caption--s")]
	Small,

	[Description("govuk-table__caption--m")]
	Medium,

	[Description("govuk-table__caption--l")]
	Large,

	[Description("govuk-table__caption--xl")]
	ExtraLarge,
}