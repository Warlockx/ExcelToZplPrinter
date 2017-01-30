using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace ExcelToZplPrinter.Services
{
   public static class DialogService
    {
        public static async Task<MessageDialogResult> ShowMessage(string windowName,string messageTitle, string message, MessageDialogStyle dialogStyle)
        {
            WindowCollection windows = Application.Current.Windows;
            MetroWindow metroWindow = new MetroWindow();
            foreach (Window window in windows)
            {
                if (window.Name == windowName)
                    metroWindow = (MetroWindow) window;
            }

            return await metroWindow.ShowMessageAsync(messageTitle, message, dialogStyle);
        }
    }
}
