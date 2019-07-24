using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeadsOrTailsWarGame
{
    public partial class GameDisplay : Form
    {
        public GameDisplay()
        {
            InitializeComponent();
        }

        Button[] currentButtons = new Button[900];
        Button[] oldButtons = new Button[900];

        Stack<Button> selectedButtons = new Stack<Button>();

        private void GameDisplay_Load(object sender, EventArgs e)
        {
            CreateButtons();
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            if (clickedButton.BackColor != Color.Black)
                selectedButtons.Push(clickedButton);


            clickedButton.BackColor = Color.Black;

            MessageBox.Show(clickedButton.Name);
        }

        private void ConvertToOldButtons()
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            while (selectedButtons.Count != 0)
            {
                MessageBox.Show(selectedButtons.Pop().Name);
            }
        }

        private void CreateButtons()
        {
            const int FIRSTXCOORDINATE = 60;
            int xCoordinate = FIRSTXCOORDINATE;
            int yCoordinate = 0;
            int colorController = 0;

            for (int buttonRecorder = 0; buttonRecorder < currentButtons.Length; buttonRecorder++)
            {
                if (colorController == 5) colorController = 0;

                CreateButtonProperties(buttonRecorder,xCoordinate,yCoordinate, TakeColor(colorController));

                colorController++;

                if (xCoordinate - FIRSTXCOORDINATE >= 580)
                {
                    yCoordinate += 20;
                    xCoordinate = FIRSTXCOORDINATE;
                    
                }
                else { xCoordinate += 20; }

            }
        }

        private void CreateButtonProperties(int buttonNumber ,int xCoordinate, int yCoordinate, Color buttonColor)
        {
            Button button = new Button();
            currentButtons[buttonNumber] = button;
            currentButtons[buttonNumber].Size = new Size(20, 20);
            currentButtons[buttonNumber].Location = new Point(xCoordinate, yCoordinate);
            currentButtons[buttonNumber].BackColor = buttonColor;

            currentButtons[buttonNumber].Name = buttonNumber.ToString();
            currentButtons[buttonNumber].Click += new EventHandler(ButtonClick);

            Controls.Add(currentButtons[buttonNumber]);
        }

        private Color TakeColor(int colorNumber)
        {
            switch (colorNumber)
            {
                case 0:
                    return Color.Red;
                case 1:
                    return Color.Blue;
                case 2:
                    return Color.Yellow;
                case 3:
                    return Color.Green;
                default:
                    return Color.White;

            }
        }
    }
}
