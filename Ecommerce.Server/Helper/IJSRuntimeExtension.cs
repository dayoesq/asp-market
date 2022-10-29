using Microsoft.JSInterop;

namespace Ecommerce.Server.Helper;

public static class IJSRuntimeExtension
{
    public static async ValueTask ToasterSuccess(this IJSRuntime jsRuntime, string message)
    {
        await jsRuntime.InvokeVoidAsync("ShowToaster", "success", message);
    }

    public static async ValueTask ToasterError(this IJSRuntime jsRuntime, string message)
    {
        await jsRuntime.InvokeVoidAsync("ShowToaster", "error", message);
    }
}