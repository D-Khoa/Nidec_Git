using System.Windows.Forms;

namespace PC_QRCodeSystem.Model
{
    public static class CustomMessageBox
    {
        public static void Notice(string message)
        {
            MessageBox.Show(message, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Error(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult Warring(string message)
        {
            return MessageBox.Show(message, "Warring", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public static DialogResult Question(string message)
        {
            return MessageBox.Show(message, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
