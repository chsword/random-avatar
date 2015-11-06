using System.Collections.Generic;
using System.Drawing;

namespace RandomAvatar
{
    public class RandomAvatarBuilder
    {
        private int squareSize;
        private int blockSize;
        private bool asymmetry;
        private bool initial;
        private bool cache;
        private int padding;
        private readonly Color _backgroundColor = Color.Transparent;
        private readonly Color _fontColor = Color.White;

        private readonly List<Color> _colors = new List<Color>()
        {
            Color.FromArgb(127, 127, 220),
            Color.FromArgb(100, 207, 172),
            Color.FromArgb(198, 87, 181),
            Color.FromArgb(134, 166, 220),
        };

        public RandomAvatarBuilder(int padding)
        {
            this.padding = padding;
        }
        public RandomAvatar Build()
        {

            RandomAvatar instance = new RandomAvatar();
            instance.SquareSize = squareSize;
            instance.BlockSize = blockSize;
            instance.Asymmetry = asymmetry;

            instance.Padding = padding;
            instance.Colors = this._colors;
            instance.Padding = padding;
            instance.BackgroundColor = _backgroundColor;
            instance.FontColor = _fontColor;
             
            return instance;
        }
    }
}