using System.Windows;

namespace Message_Encoder
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DecodeButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(textShiftAmount.Text, out int shiftAmount))
            {
                MessageBox.Show("Invalid input.");
                textShiftAmount.Focus();
            }
            else
            {
                int alphabet = 26;
                int firstLetter = 97;
                int lastLetter = 122;

                string message = txtMessage.Text.ToLower();
                string decoded = "";

                for (int i = 0; i < message.Length; i++)
                {
                    if (char.IsLetter(message[i]))
                    {
                        int newLetter = message[i];
                        newLetter = newLetter + shiftAmount;

                        if (newLetter > lastLetter)
                        {
                            newLetter = newLetter - alphabet;
                        }
                        else if (newLetter < firstLetter)
                        {
                            newLetter = newLetter + alphabet;
                        }
                        decoded = decoded + (char)newLetter;
                    }
                    else decoded = decoded + message[i];
                }
                textResult.Text = decoded;
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}