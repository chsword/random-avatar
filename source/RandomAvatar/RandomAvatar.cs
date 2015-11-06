using System;
using System.Collections.Generic;
using System.Drawing;

namespace RandomAvatar
{
    public class RandomAvatar
    {

        public int SquareSize { get; set; }
    
        public int BlockSize { get; set; }
        public bool Asymmetry { get; set; }
        public List<Color> Colors { get; set; }
        public Color BackgroundColor { get; set; } // -1 is transparent
        public Color FontColor { get; set; }
        public int Padding { get; set; }
        // private AvatarCache cache;


   

        public Image generate() 
        {
            
            setDefaultOptions();
            bool[] blocks = null;
            while (!validate(blocks)) {
                blocks = generateRandomBlocks(null);
            }
            Bitmap avatar = new Bitmap(SquareSize + Padding * 2, SquareSize + Padding * 2);
            GenerateAvatar(avatar, blocks);
            return avatar;
        }
 

        void setDefaultOptions()
        {
            SquareSize = SquareSize > 0 ? SquareSize : 100;
            BlockSize = BlockSize >= 3 ? BlockSize : 5;
        }

        bool validate(bool[] blocks)
        {
            if (blocks == null)
            {
                return false;
            }
            int count = 0;
            foreach (bool block in blocks)
            {
                count = block ? count + 1 : count;
            }
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

        bool[] generateRandomBlocks(String seed)
        {
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
                        blocks[index] = nextbool();
                    }
                }
            }
            return blocks;
        }

        bool nextbool()
        {
            try
            {
                return Guid.NewGuid().ToByteArray()[0]%2 == 0;
            }
            catch (Exception e)
            {
                return new Random().Next()%2 == 0;
            }
        }

    

        void GenerateAvatar(Image avatar, bool[] blocks)
        {
            var g = Graphics.FromImage(avatar);
            int size = SquareSize / BlockSize;
            var index = Guid.NewGuid().ToByteArray()[0]%Colors.Count;
            Color color = Colors[index];
            int holeBlockSizeX = 0;
            int holeBlockSizeY = 0;
        
            // background
            if (BackgroundColor != Color.Transparent)
            {

                g.Clear(BackgroundColor);
                g.FillRectangle(new SolidBrush(BackgroundColor),
                    new Rectangle(0, 0, SquareSize + Padding*2, SquareSize + Padding*2));
            }

 
                holeBlockSizeY = BlockSize / 2;
            for (int y = 0; y < BlockSize; y++)
            {
                for (int x = 0; x < BlockSize; x++)
                {
                    if (y < holeBlockSizeY && x < holeBlockSizeX)
                    {
                        continue;
                    }
                    if (blocks[y * BlockSize + x])
                    {
                        Brush brush = new SolidBrush(color);
                        g.FillRectangle(brush,
                            new Rectangle(Padding + x*size, Padding + y*size, size, size)
                            );
                    }
                }

                Font f = new Font(new FontFamily("Arial Black"), 
                    (int)(holeBlockSizeY * size * 0.65)
                    );

               // Brush brush1 = new SolidBrush(Colors[(index + 1)%Colors.Count]);
                
               // g.DrawString("BC", f, brush1, 10, 10);
            }
        }
 

 

       
 
    }
}