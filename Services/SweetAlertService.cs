using Microsoft.JSInterop;

namespace PicsApp.Services
{
    public class SweetAlertService
    {
        private readonly IJSRuntime _jsRuntime;

        public SweetAlertService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task ShowErrorAsync(string message)
        {
            await _jsRuntime.InvokeVoidAsync("Swal.fire", new
            {
                icon = "error",
                title = "Oops...",
                text = message
            });
        }
    }
}
