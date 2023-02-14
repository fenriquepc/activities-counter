using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;

namespace ActivitiesCounter.Utils;

internal record SimpleCallback(Action Callback) : IHandleEvent
{
    public static Action Create(Action callback) => new SimpleCallback(callback).Invoke;
    public static Func<Task> Create(Func<Task> callback) => new SimpleAsyncCallback(callback).Invoke;
    public static Func<KeyboardEventArgs, Task> Create(Func<KeyboardEventArgs, Task> callback) => new SimpleAsyncKeyBoardEventCallback(callback).Invoke;

    public void Invoke() => Callback();
    public Task HandleEventAsync(EventCallbackWorkItem item, object arg) => item.InvokeAsync(arg);
}

internal record SimpleAsyncCallback(Func<Task> Callback) : IHandleEvent
{
    public Task Invoke() => Callback();
    public Task HandleEventAsync(EventCallbackWorkItem item, object arg) => item.InvokeAsync(arg);
}

internal record SimpleAsyncKeyBoardEventCallback(Func<KeyboardEventArgs, Task> Callback) : IHandleEvent
{
    public Task Invoke(KeyboardEventArgs args) => Callback(args);
    public Task HandleEventAsync(EventCallbackWorkItem item, object arg) => item.InvokeAsync(arg);
}
