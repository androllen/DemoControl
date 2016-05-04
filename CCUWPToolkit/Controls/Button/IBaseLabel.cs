using System;

namespace CCUWPToolkit.Controls
{
    public interface IBaseLabel : IBaseControl, IImageSource
    {
        object Label { get; set; }
    }
}
