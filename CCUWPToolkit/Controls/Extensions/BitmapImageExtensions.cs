﻿/********************************************************************************
** 作者： androllen
** 日期： 16/4/6 11:06:05
*********************************************************************************/
using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;

namespace CCUWPToolkit.Controls.Extensions
{
    public static class BitmapImageExtensions
    {
        public async static Task<ExceptionRoutedEventArgs> WaitForLoadedAsync(this BitmapImage bitmapImage, int timeoutInMs = 0)
        {
            var tcs = new TaskCompletionSource<ExceptionRoutedEventArgs>();

            // TODO: NOTE: This returns immediately if the image is already loaded,
            // but if the image already failed to load - the task will never complete and the app might hang.
            if (bitmapImage.PixelWidth > 0 ||
                bitmapImage.PixelHeight > 0)
            {
                tcs.SetResult(null);
                return await tcs.Task;
            }

            //var tc = new TimeoutCheck(bitmapImage);

            // Need to set it to null so that the compiler does not
            // complain about use of unassigned local variable.
            RoutedEventHandler reh = null;
            ExceptionRoutedEventHandler ereh = null;
            EventHandler<object> progressCheckTimerTickHandler = null;
            var progressCheckTimer = new DispatcherTimer();
            Action dismissWatchmen = () =>
            {
                bitmapImage.ImageOpened -= reh;
                bitmapImage.ImageFailed -= ereh;
                progressCheckTimer.Tick -= progressCheckTimerTickHandler;
                progressCheckTimer.Stop();
                //tc.Stop();
            };

            int totalWait = 0;
            progressCheckTimerTickHandler = (sender, o) =>
            {
                totalWait += 10;

                if (bitmapImage.PixelWidth > 0)
                {
                    dismissWatchmen.Invoke();
                    tcs.SetResult(null);
                }
                else if (timeoutInMs > 0 && totalWait >= timeoutInMs)
                {
                    dismissWatchmen.Invoke();
                    tcs.SetResult(null);
                    //ErrorMessage = string.Format("BitmapImage loading timed out after {0}ms for {1}.", totalWait, bitmapImage.UriSource)
                }
            };

            progressCheckTimer.Interval = TimeSpan.FromMilliseconds(10);
            progressCheckTimer.Tick += progressCheckTimerTickHandler;
            progressCheckTimer.Start();

            reh = (s, e) =>
            {
                dismissWatchmen.Invoke();
                tcs.SetResult(null);
            };

            ereh = (s, e) =>
            {
                dismissWatchmen.Invoke();
                tcs.SetResult(e);
            };

            bitmapImage.ImageOpened += reh;
            bitmapImage.ImageFailed += ereh;

            return await tcs.Task;
        }
    }
}
