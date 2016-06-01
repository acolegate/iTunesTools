using System.Drawing;
using System.Windows.Forms;

namespace Forms
{
    public static class FormExtensionMethods
    {
        public static Form CenterForm(this Form child, Form parent)
        {
            child.StartPosition = FormStartPosition.Manual;
            child.Location = new Point(parent.Location.X + (parent.Width - child.Width) / 2, parent.Location.Y + (parent.Height - child.Height) / 2);
            return child;
        }
    }
}
