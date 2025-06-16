namespace FloodOnlineReportingTool.GdsComponents;

[AttributeUsage(AttributeTargets.Property)]
internal class GdsFieldErrorClassAttribute : Attribute
{
    private const string FileUploadErrorCssClass = "govuk-file-upload--error";
    private const string InputErrorCssClass = "govuk-input--error";
    private const string SelectErrorCssClass = "govuk-select--error";
    private const string TextAreaErrorCssClass = "govuk-textarea--error";

    private readonly GdsFieldTypes _fieldType = GdsFieldTypes.Unknown;

    public GdsFieldErrorClassAttribute(GdsFieldTypes fieldType)
    {
        _fieldType = fieldType;
    }

    internal virtual GdsFieldTypes FieldType
    {
        get { return _fieldType; }
        init { _fieldType = value; }
    }

    internal virtual string CssClass()
    {
        return _fieldType switch
        {
            GdsFieldTypes.Date => InputErrorCssClass,
            GdsFieldTypes.FileUpload => FileUploadErrorCssClass,
            GdsFieldTypes.Input => InputErrorCssClass,
            GdsFieldTypes.Password => InputErrorCssClass,
            GdsFieldTypes.Select => SelectErrorCssClass,
            GdsFieldTypes.Textarea => TextAreaErrorCssClass,
            _ => string.Empty,
        };
    }
}
