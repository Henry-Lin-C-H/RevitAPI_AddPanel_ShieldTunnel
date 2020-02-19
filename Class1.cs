using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Windows.Media.Imaging;

namespace TunnelApplication
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class AddPanel : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            // 尋找檔案在電腦上的路徑
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).ToString();
            string filepath = path.Substring(6);
            // add new ribbon panel加入新的功能區面板 
            RibbonPanel ribbonPanel = application.CreateRibbonPanel("潛盾隧道自動化建模");
            //在“NewRibbonPanel” 功能區面板建立一按鈕 
            //當按下該按鈕，則增益集應用程式即被觸發執行
            string command_path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).ToString().Substring(6);

            PushButton pushButton = ribbonPanel.AddItem(new PushButtonData("Tunnel", "Tunnel", command_path + @"\SinoTunnel.dll", "SinoTunnel.start")) as PushButton;
            pushButton.LargeImage = new BitmapImage(new Uri(command_path + @"\images\Blue.png"));

            return Result.Succeeded;
        }
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}
