using System.Collections.Generic;
using System.Drawing;

namespace RandomAvatar
{
    public class RandomAvatarBuilder
    {
        private readonly int _squareSize;
        private readonly int _blockSize;
        private readonly bool _asymmetry;
 
        private readonly int _padding;
        private readonly Color _fontColor = Color.White;

        private readonly List<Color> _colors = new List<Color>()
        {
            Color.FromArgb(127, 127, 220),
            Color.FromArgb(100, 207, 172),
            Color.FromArgb(198, 87, 181),
            Color.FromArgb(134, 166, 220),
            Color.FromArgb(0xf2, 0x4e, 0x33),
            Color.FromArgb(0xf9, 0x97, 0x40),
            Color.FromArgb(0xf9, 0xc8, 0x2f),
            Color.FromArgb(0x14, 0xad, 0xe3),
            Color.FromArgb(0x9e, 0xd2, 0x00),
            Color.FromArgb(0xb5, 0x4e, 0x33),
            Color.FromArgb(0xb5, 0x44, 0xec),
        };

        public RandomAvatarBuilder(int size,int padding, bool asymmetry=false)
        {
            this._padding = padding;
            //this._blockSize = blockSize;
            _squareSize = size;
            this._asymmetry = asymmetry;
        }
        public RandomAvatar Build()
        {

            RandomAvatar instance = new RandomAvatar();
            instance.SquareSize = _squareSize;
            instance.BlockSize = _blockSize;
            instance.Asymmetry = _asymmetry;

            instance.Padding = _padding;
            instance.Colors = this._colors;
            instance.Padding = _padding;
             
            instance.FontColor = _fontColor;
             
            return instance;
        }
    }
}