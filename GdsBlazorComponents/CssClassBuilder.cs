using System.Text;

namespace GdsBlazorComponents;

internal sealed class CssClassBuilder
{
    private readonly StringBuilder _builder;
    private const char Space = ' ';

    public CssClassBuilder()
    {
        _builder = new StringBuilder();
    }

    public CssClassBuilder(string? cssClass)
    {
        _builder = new StringBuilder(cssClass?.Trim());
    }

    public int Length => _builder.Length;

    /// <summary>
    /// Adds a CSS class to the builder.
    /// </summary>
    /// <remarks>
    ///     <para>If the provided CSS class is null, empty, or whitespace, it will not be added.</para>
    ///     <para>A space will be added before the new class if the builder already contains classes.</para>
    /// </remarks>
    /// <param name="cssClass">The CSS class to add</param>
    public CssClassBuilder Add(ReadOnlySpan<char> cssClass)
    {
        if (cssClass.IsEmpty || cssClass.IsWhiteSpace())
        {
            return this;
        }

        ReadOnlySpan<char> trimmed = cssClass.Trim();
        if (trimmed.Length == 0)
        {
            return this;
        }

        if (_builder.Length > 0)
        {
            _builder.Append(Space);
        }
        _builder.Append(trimmed);

        return this;
    }

    /// <summary>
    /// Adds a CSS class to the builder, if the specified condition is true.
    /// </summary>
    /// <remarks>
    ///     <para>If the provided CSS class is null, empty, or whitespace, it will not be added.</para>
    ///     <para>A space will be added before the new class if the builder already contains classes.</para>
    /// </remarks>
    /// <param name="cssClass">The CSS class to add</param>
    public CssClassBuilder AddIf(bool condition, ReadOnlySpan<char> cssClass)
        => condition ? Add(cssClass) : this;

    public string? Build()
    {
        if (_builder.Length == 0)
        {
            return null;
        }
        
        return _builder.ToString();
    }
}
