using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace RandomAvatar;

public class RandomAvatar
{
    public byte[] Seed { private get; init; } = null!;
    private byte[] _guidBytes = Guid.NewGuid().ToByteArray();
    private int _i;
    public int SquareSize { get; set; }

    public int BlockCount { get; set; }
    public bool IsSymmetry { get; set; }
    public List<Color> Colors { get; init; } = null!;

    public Color FontColor { get; set; }
    public int Padding { get; set; }

    private int RealSize => SquareSize - Padding * 2;

    

    public Image GenerateImage()
    {
        SetDefaultOptions();
        bool[,]? blocks = null;
        while (!Validate(blocks)) blocks = GenerateRandomBlocks();

        var image = new Image<Rgba32>(RealSize + Padding * 2, RealSize + Padding * 2);

        //var avatar = new Bitmap(RealSize + Padding * 2, RealSize + Padding * 2);
        DrawAvatar(image, blocks!);
        return image;
    }

    private void SetDefaultOptions()
    {
        SetBytes();
        SquareSize = SquareSize > 0 ? SquareSize : 100;
        BlockCount = BlockCount >= 3 ? BlockCount : 6;
    }

    private bool Validate(bool[,]? blocks)
    {
        // 验证，过满过希都不合适
        if (blocks == null) return false;
        var count = blocks.Cast<bool>().Count(block => block);
        if (2 < BlockCount && count < 6) return false;
        if (count == BlockCount * BlockCount) return false;
        return true;
    }

    private bool[,] GenerateRandomBlocks()
    {
        var blocks = new bool[BlockCount , BlockCount];
        for (var y = 0; y < BlockCount; y++)
        for (var x = 0; x < BlockCount; x++)
        {
            if (BlockCount / 2 <= x && IsSymmetry)
                blocks[x, y] = blocks[BlockCount - x - 1,y];
            else
                blocks[x, y] = (GetNextByte() & 1) == 0;
        }

        return blocks;
    }

    public byte GetNextByte()
    {
        if (_i < _guidBytes.Length) return _guidBytes[_i++];
        _i = 0;
        SetBytes();

        return _guidBytes[_i++];
    }

    private void SetBytes()
    {
        _guidBytes = Seed is {Length: > 0} ? Seed : Guid.NewGuid().ToByteArray();
    }

    private void DrawAvatar(Image<Rgba32> image, bool[,] blocks)
    {
        var size = RealSize / BlockCount;
        var index = GetNextByte() % Colors.Count;
        var color = Colors[index];
        var holeBlockSizeX = 0;
        var holeBlockSizeY = BlockCount / 2;
        var brush = new SolidBrush(Color.White);
        image.Mutate(c =>
        {
            var ret = c.BackgroundColor(color);
            for (var y = 0; y < BlockCount; y++)
            for (var x = 0; x < BlockCount; x++)
            {
                if (y < holeBlockSizeY && x < holeBlockSizeX) continue;
                if (!blocks[x, y]) continue;

                ret.Fill(brush,
                    new Rectangle(Padding + x * size, Padding + y * size, size, size)
                );
            }
        });
    }
}