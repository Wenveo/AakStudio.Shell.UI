using System.Windows.Automation.Peers;

using AakStudio.Shell.UI.Controls;

namespace AakStudio.Shell.UI.Automation.Peers
{
    public class CustomChromeWindowAutomationPeer : WindowAutomationPeer
    {
        public CustomChromeWindowAutomationPeer(CustomChromeWindow owner) : base(owner)
        {
        }

        protected override string GetClassNameCore()
        {
            return "CustomChromeWindow";
        }
    }
}
