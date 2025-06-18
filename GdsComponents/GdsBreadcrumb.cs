namespace FloodOnlineReportingTool.GdsComponents;

public readonly record struct GdsBreadcrumb
{
    public Uri Uri { get; }
    public string Label { get; }

    public GdsBreadcrumb(Uri uri, string label)
    {
        Uri = uri;
        Label = label;
    }

    public GdsBreadcrumb(string url, string label)
    {
        Uri = new Uri(url, UriKind.Relative);
        Label = label;
    }
}