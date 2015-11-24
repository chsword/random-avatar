using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace RandomAvatar
{
    public class RandomAvatar
    {
         
        public int SquareSize { get; set; }
    
        public int BlockSize { get; set; }
        public bool Asymmetry { get; set; }
        public List<Color> Colors { get; set; }
 
        public Color FontColor { get; set; }
        public int Padding { get; set; }

        public Image Generate()
        {

            SetDefaultOptions();
            bool[] blocks = null;
            while (!Validate(blocks))
            {
                blocks = GenerateRandomBlocks();
            }
            Bitmap avatar = new Bitmap(SquareSize + Padding*2, SquareSize + Padding*2);

            DrawAvatar(avatar, blocks);
            return avatar;

        }


        void SetDefaultOptions()
        {
            SquareSize = SquareSize > 0 ? SquareSize : 100;
            BlockSize = BlockSize >= 3 ? BlockSize : 5;
        }

        bool Validate(bool[] blocks)
        {
            if (blocks == null)
            {
                return false;
            }
            var count =
                blocks.Aggregate(0,
                    (current, block) => block ? current + 1 : current
                    );
            if (2 < BlockSize && count < 6)
            {
                return false;
            }
            if (count == BlockSize * BlockSize)
            {
                return false;
            }
            return true;
        }

        bool[] GenerateRandomBlocks()
        {
            var bytes = Guid.NewGuid().ToByteArray();
            int i = 0;
            bool[] blocks = new bool[BlockSize * BlockSize];
            for (int y = 0; y < BlockSize; y++)
            {
                for (int x = 0; x < BlockSize; x++)
                {
                    int index = y * BlockSize + x;
                    if (BlockSize / 2 < x && !Asymmetry)
                    {
                        blocks[index] = blocks[index - x + BlockSize - x - 1];
                    }
                    else
                    {
                        blocks[index] = (bytes[i++]%2) == 0;
                    }
                }
            }
            return blocks;
        }
 


        private void DrawAvatar(Image avatar, bool[] blocks)
        {
            using (var g = Graphics.FromImage(avatar))
            {
                int size = SquareSize/BlockSize;
                var index = Guid.NewGuid().ToByteArray()[0]%Colors.Count;
                Color color = Colors[index];
                int holeBlockSizeX = 0;
                int holeBlockSizeY = 0;
                g.Clear(color);
               
                holeBlockSizeY = BlockSize/2;
                for (int y = 0; y < BlockSize; y++)
                {
                    for (int x = 0; x < BlockSize; x++)
                    {
                        if (y < holeBlockSizeY && x < holeBlockSizeX)
                        {
                            continue;
                        }
                        if (blocks[y*BlockSize + x])
                        {
                            Brush brush = new SolidBrush(Color.White);
                            g.FillRectangle(brush,
                                new Rectangle(Padding + x*size, Padding + y*size, size, size)
                                );
                        }
                    }
                   

                }
                RenderFont(g);
            }
        }

        private void RenderFont(Graphics graphics)
        {
            //Font f = new Font(new FontFamily("Arial Black"), 
            //    (int)(holeBlockSizeY * size * 0.65)
            //    );

            // Brush brush1 = new SolidBrush(Colors[(index + 1)%Colors.Count]);

            // g.DrawString("BC", f, brush1, 10, 10);
        }
    }
}