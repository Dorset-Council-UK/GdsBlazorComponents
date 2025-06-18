using Microsoft.AspNetCore.Components.Forms;
using System.Reflection;

namespace FloodOnlineReportingTool.GdsComponents;

public class GdsFieldCssClassProvider : FieldCssClassProvider
{
    /// <summary>
    /// Get the CSS class to apply to a field based on its state.
    /// </summary>
    /// <remarks>
    ///     <para>These following GDS field types don't have a field error class, they rely on setting the error class on the form group instead:</para>
    ///     <para>Checkbox, Radio</para>
    /// </remarks>
    public override string GetFieldCssClass(EditContext editContext, in FieldIdentifier fieldIdentifier)
    {
        if (editContext.IsValid(fieldIdentifier))
        {
            return string.Empty;
        }

        var propertyInfo = fieldIdentifier.Model.GetType().GetProperty(fieldIdentifier.FieldName);
        var attribute = propertyInfo?.GetCustomAttribute<GdsFieldErrorClassAttribute>();
        return attribute?.CssClass() ?? "";
    }
}
