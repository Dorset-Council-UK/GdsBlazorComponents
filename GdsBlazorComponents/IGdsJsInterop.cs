namespace GdsBlazorComponents;

public interface IGdsJsInterop
{
    public ValueTask InitGds();

    public ValueTask InitGds(CancellationToken ct);
}
