using Microsoft.JSInterop;

namespace XtremeWasmApp.Helpers
{
    public static class FileUtils
    {
        public static ValueTask<object> SaveAs(this IJSRuntime js, string filename, byte[] data)
        {
            return js.InvokeAsync<object>(
                  "saveAsFile",
                  filename,
                  Convert.ToBase64String(data));
        }
    }
}
