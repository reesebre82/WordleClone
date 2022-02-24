using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;


namespace WordleClone
{
    public partial class MainPage : ContentPage
    {
        // private int guess = 0;
        // private String realWord = "clone";

        GameManager gameManager;

        Tuple<Frame, Label>[,] labels;
        Tuple<Frame, Label>[] keys;

        public Tuple<Frame, Label>[,] Labels {
            get { return labels; }
        }

        public MainPage()
        {
            InitializeComponent();

            //fixes safe area for iOS Users
            On<iOS>().SetUseSafeArea(true);

            UIGlobal.MainPage = this;

            gameManager = new GameManager();



            Xamarin.Forms.Application.Current.RequestedThemeChanged += (s, a) =>
            {
                // Respond to the theme change
                Console.WriteLine("Theme Changed");

                SetupColors();
            };


            SetupScreen();


            //Adding keyboard to variables
            labels = new Tuple<Frame, Label>[,]
            {
                { new Tuple<Frame, Label>(frame00, label00),  new Tuple<Frame, Label>(frame01, label01),  new Tuple<Frame, Label>(frame02, label02),  new Tuple<Frame, Label>(frame03, label03),  new Tuple<Frame, Label>(frame04, label04)},
                { new Tuple<Frame, Label>(frame10, label10),  new Tuple<Frame, Label>(frame11, label11),  new Tuple<Frame, Label>(frame12, label12),  new Tuple<Frame, Label>(frame13, label13),  new Tuple<Frame, Label>(frame14, label14)},
                { new Tuple<Frame, Label>(frame20, label20),  new Tuple<Frame, Label>(frame21, label21),  new Tuple<Frame, Label>(frame22, label22),  new Tuple<Frame, Label>(frame23, label23),  new Tuple<Frame, Label>(frame24, label24)},
                { new Tuple<Frame, Label>(frame30, label30),  new Tuple<Frame, Label>(frame31, label31),  new Tuple<Frame, Label>(frame32, label32),  new Tuple<Frame, Label>(frame33, label33),  new Tuple<Frame, Label>(frame34, label34)},
                { new Tuple<Frame, Label>(frame40, label40),  new Tuple<Frame, Label>(frame41, label41),  new Tuple<Frame, Label>(frame42, label42),  new Tuple<Frame, Label>(frame43, label43),  new Tuple<Frame, Label>(frame44, label44)},
                { new Tuple<Frame, Label>(frame50, label50),  new Tuple<Frame, Label>(frame51, label51),  new Tuple<Frame, Label>(frame52, label52),  new Tuple<Frame, Label>(frame53, label53),  new Tuple<Frame, Label>(frame54, label54)}

            };

            keys = new Tuple<Frame, Label>[]
            {
                new Tuple<Frame, Label>(keyboardA, labelKeyA),
                new Tuple<Frame, Label>(keyboardB, labelKeyB),
                new Tuple<Frame, Label>(keyboardC, labelKeyC),
                new Tuple<Frame, Label>(keyboardD, labelKeyD),
                new Tuple<Frame, Label>(keyboardE, labelKeyE),
                new Tuple<Frame, Label>(keyboardF, labelKeyF),
                new Tuple<Frame, Label>(keyboardG, labelKeyG),
                new Tuple<Frame, Label>(keyboardH, labelKeyH),
                new Tuple<Frame, Label>(keyboardI, labelKeyI),
                new Tuple<Frame, Label>(keyboardJ, labelKeyJ),
                new Tuple<Frame, Label>(keyboardK, labelKeyK),
                new Tuple<Frame, Label>(keyboardL, labelKeyL),
                new Tuple<Frame, Label>(keyboardM, labelKeyM),
                new Tuple<Frame, Label>(keyboardN, labelKeyN),
                new Tuple<Frame, Label>(keyboardO, labelKeyO),
                new Tuple<Frame, Label>(keyboardP, labelKeyP),
                new Tuple<Frame, Label>(keyboardQ, labelKeyQ),
                new Tuple<Frame, Label>(keyboardR, labelKeyR),
                new Tuple<Frame, Label>(keyboardS, labelKeyS),
                new Tuple<Frame, Label>(keyboardT, labelKeyT),
                new Tuple<Frame, Label>(keyboardU, labelKeyU),
                new Tuple<Frame, Label>(keyboardV, labelKeyV),
                new Tuple<Frame, Label>(keyboardW, labelKeyW),
                new Tuple<Frame, Label>(keyboardX, labelKeyX),
                new Tuple<Frame, Label>(keyboardY, labelKeyY),
                new Tuple<Frame, Label>(keyboardZ, labelKeyZ),
                new Tuple<Frame, Label>(EnterKey, labelKeyEnter),
                new Tuple<Frame, Label>(keyboardDel, labelKeyDel),
            };

            SetupKeyboard();
            SetupColors();
        }


        private void SetupColors()
        {
            // Setup colors on bottom
            for (int i = 0; i < 28; i++)
            {
                int color = ColorManager.ReverseColorSearch(keys[i].Item1.BackgroundColor);
                keys[i].Item2.TextColor = ColorManager.KeyboardTextColor(color != 0);

                keys[i].Item1.BackgroundColor = ColorManager.FrameBackgroundColor(color);
            }

            // Setup colors on top
            for(int i = 0; i < 6; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    int color = ColorManager.ReverseColorSearch(labels[i, j].Item1.BackgroundColor);
                    var colorBorder = labels[i, j].Item1.BorderColor;
                    if (color != -1)
                    {
                        labels[i, j].Item1.BackgroundColor = ColorManager.FrameBackgroundColor(color);
                    }

                    if(colorBorder != Color.Transparent)
                    {
                        if (labels[i, j].Item2.Text == null)
                        {
                            labels[i, j].Item1.BorderColor = ColorManager.IsLightMode() ? Color.LightGray: Color.Gray;
                        }
                        else
                        {
                            labels[i, j].Item1.BorderColor = ColorManager.IsLightMode() ? Color.Black : Color.LightGray;
                        }
                    }
                }
            }

            // Sets Borders

        }



        private void SetupScreen()
        {
            var screenWidth = Convert.ToInt32(Math.Round(DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density));
            if (screenWidth > 600)
            {
                screenWidth = 600;
            }

            var screenHeight = Convert.ToInt32(Math.Round(DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density));

            var percentageOfScreenWidth = 0.8;

            WordleGrid.WidthRequest = screenWidth * percentageOfScreenWidth;
            WordleGrid.HeightRequest = (screenWidth * percentageOfScreenWidth) * 1.25;

            WordleAbsoluteLayout.HeightRequest = WordleGrid.Height;

            var leftHeight = screenHeight - ((screenWidth * percentageOfScreenWidth) * 2);
            if (leftHeight > 200)
            {
                leftHeight = 200;
            }
            else if (leftHeight < 100)
            {
                leftHeight = 100;
            }

            WordleKeyboard.HeightRequest = leftHeight / 3;
            WordleKeyboard2.HeightRequest = leftHeight / 3;
            EnterKey.HeightRequest = leftHeight / 3;


            WordleKeyboard.WidthRequest = screenWidth * 0.95;
            WordleKeyboard2.WidthRequest = screenWidth * 0.875;
            WordleKeyboard3.WidthRequest = screenWidth * 0.95;

            EndingScreen.WidthRequest = screenWidth * 0.75;
            EndingScreen.HeightRequest = screenWidth * 0.75;

            EndingScreenOverlay.IsVisible = false;
            EndingScreenOverlayColor.IsVisible = false;

            EndingScreenOverlayColor.BackgroundColor = Color.FromHex("#FFFFFF");

        }

        async public void showAnimationEndingScreen()
        {
            var screenWidth = Convert.ToInt32(Math.Round(DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density));
            var screenHeight = Convert.ToInt32(Math.Round(DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density));

            await EndingScreenOverlay.TranslateTo(0, screenHeight, 0);
            await EndingScreenOverlayColor.FadeTo(0, 0, Easing.Linear);

            EndingScreenOverlay.IsVisible = true;
            //EndingScreenOverlayColor.IsVisible = true;

            EndingScreenOverlay.TranslateTo(0, 0, 250, Easing.SinOut);
            EndingScreenOverlayColor.FadeTo(0.5, 250);

            EndingScreenOverlayColor.IsVisible = true;
        }

        private void SetupKeyboard()
        {
            UpdateKeyboard("abcdefghijklmnopqrstuvwxyz", Enumerable.Repeat(Color.FromRgb(r: 212, g: 214, b: 218), 27).ToArray(), ColorManager.KeyboardTextColor(false));
            keyboardDel.BackgroundColor = Color.FromRgb(r: 212, g: 214, b: 218);
            EnterKey.BackgroundColor = Color.FromRgb(r: 212, g: 214, b: 218);

            labelKeyEnter.TextColor = ColorManager.KeyboardTextColor(false);
            labelKeyDel.TextColor = ColorManager.KeyboardTextColor(false);
        }

        async public void SetLetter(String letter, Frame frame, Label label)
        {
            //Animation
            await frame.ScaleTo(1.25, 50);
            //Frame
            frame.BorderColor = ColorManager.IsLightMode() ? Color.Black : Color.LightGray;

            //Label
            label.Text = letter;

            await frame.ScaleTo(1, 50);
        }

        public void LetterEntered(object sender, EventArgs e)
        {
            string data = ((Frame)sender).BindingContext as string;

            gameManager.AttemptSetLetter(data);

        }

        public void KeyboardLetterEntered(string key)
        {
            gameManager.AttemptSetLetter(letter: key);
        }

        public void RemoveLetter(object sender, EventArgs e)
        {
            gameManager.RemoveLetter();
        }


        async private void ShakeLetter(Frame frame)
        {
            await frame.TranslateTo(10, 0, 50);
            await frame.TranslateTo(-10, 0, 50);
            await frame.TranslateTo(10, 0, 50);
            await frame.TranslateTo(-10, 0, 50);
            await frame.TranslateTo(10, 0, 50);
            await frame.TranslateTo(0, 0, 50);
        }

        public void ShakeLane(int lane)
        {
            Console.WriteLine("Shaking lane: " + lane);
            switch (lane) {
                case 0:
                    ShakeLetter(frame00);
                    ShakeLetter(frame01);
                    ShakeLetter(frame02);
                    ShakeLetter(frame03);
                    ShakeLetter(frame04);
                    break;
                case 1:
                    ShakeLetter(frame10);
                    ShakeLetter(frame11);
                    ShakeLetter(frame12);
                    ShakeLetter(frame13);
                    ShakeLetter(frame14);
                    break;
                case 2:
                    ShakeLetter(frame20);
                    ShakeLetter(frame21);
                    ShakeLetter(frame22);
                    ShakeLetter(frame23);
                    ShakeLetter(frame24);
                    break;
                case 3:
                    ShakeLetter(frame30);
                    ShakeLetter(frame31);
                    ShakeLetter(frame32);
                    ShakeLetter(frame33);
                    ShakeLetter(frame34);
                    break;
                case 4:
                    ShakeLetter(frame40);
                    ShakeLetter(frame41);
                    ShakeLetter(frame42);
                    ShakeLetter(frame43);
                    ShakeLetter(frame44);
                    break;
                case 5:
                    ShakeLetter(frame50);
                    ShakeLetter(frame51);
                    ShakeLetter(frame52);
                    ShakeLetter(frame53);
                    ShakeLetter(frame54);
                    break;

                default:
                    break;
            }
        }

        async private void DanceLetter(Frame frame)
        {
            await frame.TranslateTo(0, -50, 150);
            await frame.TranslateTo(0, 0, 150);
            await frame.TranslateTo(0, -25, 150);
            await frame.TranslateTo(0, 0, 150);
        }

        async public void SolveDance(int guess)
        {
            Console.WriteLine("Dancing lane: " + guess);
            switch (guess)
            {
                case 0:
                    DanceLetter(frame00);
                    await Task.Delay(100);
                    DanceLetter(frame01);
                    await Task.Delay(100);
                    DanceLetter(frame02);
                    await Task.Delay(100);
                    DanceLetter(frame03);
                    await Task.Delay(100);
                    DanceLetter(frame04);
                    break;
                case 1:
                    DanceLetter(frame10);
                    await Task.Delay(100);
                    DanceLetter(frame11);
                    await Task.Delay(100);
                    DanceLetter(frame12);
                    await Task.Delay(100);
                    DanceLetter(frame13);
                    await Task.Delay(100);
                    DanceLetter(frame14);
                    break;
                case 2:
                    DanceLetter(frame20);
                    await Task.Delay(100);
                    DanceLetter(frame21);
                    await Task.Delay(100);
                    DanceLetter(frame22);
                    await Task.Delay(100);
                    DanceLetter(frame23);
                    await Task.Delay(100);
                    DanceLetter(frame24);
                    break;
                case 3:
                    DanceLetter(frame30);
                    await Task.Delay(100);
                    DanceLetter(frame31);
                    await Task.Delay(100);
                    DanceLetter(frame32);
                    await Task.Delay(100);
                    DanceLetter(frame33);
                    await Task.Delay(100);
                    DanceLetter(frame34);
                    break;
                case 4:
                    DanceLetter(frame40);
                    await Task.Delay(100);
                    DanceLetter(frame41);
                    await Task.Delay(100);
                    DanceLetter(frame42);
                    await Task.Delay(100);
                    DanceLetter(frame43);
                    await Task.Delay(100);
                    DanceLetter(frame44);
                    break;
                case 5:
                    DanceLetter(frame50);
                    await Task.Delay(100);
                    DanceLetter(frame51);
                    await Task.Delay(100);
                    DanceLetter(frame52);
                    await Task.Delay(100);
                    DanceLetter(frame53);
                    await Task.Delay(100);
                    DanceLetter(frame54);
                    break;

                default:
                    break;
            }
        }

        public void UpdateKeyboard(string word, Color[] colors, Color labelColor)
        {
            for (int i = 0; i < word.Length; i++)
            {
                char letter = word[i];

                switch (letter) {
                    case 'a':
                        if (keyboardA.BackgroundColor != ColorManager.FrameBackgroundColor(3))
                        {
                            keyboardA.BackgroundColor = colors[i];
                            labelKeyA.TextColor = labelColor;
                        }
                        break;
                    case 'b':
                        if (keyboardB.BackgroundColor != ColorManager.FrameBackgroundColor(3))
                        {
                            keyboardB.BackgroundColor = colors[i];
                            labelKeyB.TextColor = labelColor;
                        }
                        break;
                    case 'c':
                        if (keyboardC.BackgroundColor != ColorManager.FrameBackgroundColor(3))
                        {
                            keyboardC.BackgroundColor = colors[i];
                            labelKeyC.TextColor = labelColor;
                        }
                        break;
                    case 'd':
                        if (keyboardD.BackgroundColor != ColorManager.FrameBackgroundColor(3))
                        {
                            keyboardD.BackgroundColor = colors[i];
                            labelKeyD.TextColor = labelColor;
                        }
                        break;
                    case 'e':
                        if (keyboardE.BackgroundColor != ColorManager.FrameBackgroundColor(3))
                        {
                            keyboardE.BackgroundColor = colors[i];
                            labelKeyE.TextColor = labelColor;
                        }
                        break;
                    case 'f':
                        if (keyboardF.BackgroundColor != ColorManager.FrameBackgroundColor(3))
                        {
                            keyboardF.BackgroundColor = colors[i];
                            labelKeyF.TextColor = labelColor;
                        }
                        break;
                    case 'g':
                        if (keyboardG.BackgroundColor != ColorManager.FrameBackgroundColor(3))
                        {
                            keyboardG.BackgroundColor = colors[i];
                            labelKeyG.TextColor = labelColor;
                        }
                        break;
                    case 'h':
                        if (keyboardH.BackgroundColor != ColorManager.FrameBackgroundColor(3))
                        {
                            keyboardH.BackgroundColor = colors[i];
                            labelKeyH.TextColor = labelColor;
                        }
                        break;
                    case 'i':
                        if (keyboardI.BackgroundColor != ColorManager.FrameBackgroundColor(3))
                        {
                            keyboardI.BackgroundColor = colors[i];
                            labelKeyI.TextColor = labelColor;
                        }
                        break;
                    case 'j':
                        if (keyboardJ.BackgroundColor != ColorManager.FrameBackgroundColor(3))
                        {
                            keyboardJ.BackgroundColor = colors[i];
                            labelKeyJ.TextColor = labelColor;
                        }
                        break;
                    case 'k':
                        if (keyboardK.BackgroundColor != ColorManager.FrameBackgroundColor(3))
                        {
                            keyboardK.BackgroundColor = colors[i];
                            labelKeyK.TextColor = labelColor;
                        }
                        break;
                    case 'l':
                        if (keyboardL.BackgroundColor != ColorManager.FrameBackgroundColor(3))
                        {
                            keyboardL.BackgroundColor = colors[i];
                            labelKeyL.TextColor = labelColor;
                        }
                        break;
                    case 'm':
                        if (keyboardM.BackgroundColor != ColorManager.FrameBackgroundColor(3))
                        {
                            keyboardM.BackgroundColor = colors[i];
                            labelKeyM.TextColor = labelColor;
                        }
                        break;
                    case 'n':
                        if (keyboardN.BackgroundColor != ColorManager.FrameBackgroundColor(3))
                        {
                            keyboardN.BackgroundColor = colors[i];
                            labelKeyN.TextColor = labelColor;
                        }
                        break;
                    case 'o':
                        if (keyboardO.BackgroundColor != ColorManager.FrameBackgroundColor(3))
                        {
                            keyboardO.BackgroundColor = colors[i];
                            labelKeyO.TextColor = labelColor;
                        }
                        break;
                    case 'p':
                        if (keyboardP.BackgroundColor != ColorManager.FrameBackgroundColor(3))
                        {
                            keyboardP.BackgroundColor = colors[i];
                            labelKeyP.TextColor = labelColor;
                        }
                        break;
                    case 'q':
                        if (keyboardQ.BackgroundColor != ColorManager.FrameBackgroundColor(3))
                        {
                            keyboardQ.BackgroundColor = colors[i];
                            labelKeyQ.TextColor = labelColor;
                        }
                        break;
                    case 'r':
                        if (keyboardR.BackgroundColor != ColorManager.FrameBackgroundColor(3))
                        {
                            keyboardR.BackgroundColor = colors[i];
                            labelKeyR.TextColor = labelColor;
                        }
                        break;
                    case 's':
                        if (keyboardS.BackgroundColor != ColorManager.FrameBackgroundColor(3))
                        {
                            keyboardS.BackgroundColor = colors[i];
                            labelKeyS.TextColor = labelColor;
                        }
                        break;
                    case 't':
                        if (keyboardT.BackgroundColor != ColorManager.FrameBackgroundColor(3))
                        {
                            keyboardT.BackgroundColor = colors[i];
                            labelKeyT.TextColor = labelColor;
                        }
                        break;
                    case 'u':
                        if (keyboardU.BackgroundColor != ColorManager.FrameBackgroundColor(3))
                        {
                            keyboardU.BackgroundColor = colors[i];
                            labelKeyU.TextColor = labelColor;
                        }
                        break;
                    case 'v':
                        if (keyboardV.BackgroundColor != ColorManager.FrameBackgroundColor(3))
                        {
                            keyboardV.BackgroundColor = colors[i];
                            labelKeyV.TextColor = labelColor;
                        }
                        break;
                    case 'w':
                        if (keyboardW.BackgroundColor != ColorManager.FrameBackgroundColor(3))
                        {
                            keyboardW.BackgroundColor = colors[i];
                            labelKeyW.TextColor = labelColor;
                        }
                        break;
                    case 'x':
                        if (keyboardX.BackgroundColor != ColorManager.FrameBackgroundColor(3))
                        { 
                            keyboardX.BackgroundColor = colors[i];
                            labelKeyX.TextColor = labelColor;
                        }
                        break;
                    case 'y':
                        if (keyboardY.BackgroundColor != ColorManager.FrameBackgroundColor(3))
                        {
                            keyboardY.BackgroundColor = colors[i];
                            labelKeyY.TextColor = labelColor;
                        }
                        break;
                    case 'z':
                        if (keyboardZ.BackgroundColor != ColorManager.FrameBackgroundColor(3))
                        {
                            keyboardZ.BackgroundColor = colors[i];
                            labelKeyZ.TextColor = labelColor;
                        }
                        break;
                    default:
                        Console.WriteLine("UpdateKeyboard hit Default Case.");
                        break;

                }
            }
        }

        public void EnterWord(object sender, EventArgs e)
        {
            gameManager.EnterWord();
        }


        
    }

    public static class UIGlobal
    {
        public static MainPage MainPage { get; set; }
    }
}
