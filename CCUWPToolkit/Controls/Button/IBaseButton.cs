using System;

namespace CCUWPToolkit.Controls
{
    public interface IBaseButton : IBaseControl, IImageSource
    {
        object Label { get; set; }
    }
}
