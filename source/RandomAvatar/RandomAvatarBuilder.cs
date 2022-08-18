using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Png;

namespace RandomAvatar;

public class RandomAvatarBuilder
{
    private static readonly List<Color> Colors = new()
    {
        Color.FromRgb(127, 127, 220),
        Color.FromRgb(100, 207, 172),
        Color.FromRgb(198, 87, 181),
        Color.FromRgb(134, 166, 220),
        Color.FromRgb(0xf2, 0x4e, 0x33),
        Color.FromRgb(0xf9, 0x97, 0x40),
        Color.FromRgb(0xf9, 0xc8, 0x2f),
        Color.FromRgb(0x14, 0xad, 0xe3),
        Color.FromRgb(0x9e, 0xd2, 0x00),
        Color.FromRgb(0xb5, 0x4e, 0x33),
        Color.FromRgb(0xb5, 0x44, 0xec)
    };

    private readonly RandomAvatar _instance;

    private RandomAvatarBuilder(int size, bool isSymmetry, string? seed)
    {
        _instance = new RandomAvatar
        {
            SquareSize = size,
            FontColor = Color.White,
            Colors = Colors,
            IsSymmetry = isSymmetry,
            Seed = seed == null ? new byte[] { } : Encoding.UTF8.GetBytes(seed.Length < 3 ? $"RA{seed}" : seed)
        };
    }

    public static RandomAvatarBuilder Build(int size, bool isSymmetry = true, string? seed = null)
    {
        return new RandomAvatarBuilder(size, isSymmetry, seed);
    }

    public RandomAvatarBuilder SetPadding(int padding)
    {
        _instance.Padding = padding;
        return this;
    }

    public RandomAvatarBuilder SetSymmetry(bool isSymmetry = true)
    {
        _instance.IsSymmetry = isSymmetry;
        return this;
    }

    public RandomAvatarBuilder SetBlockSize(int blockSize)
    {
        _instance.BlockCount = blockSize;
        return this;
    }



    public Image ToImage()
    {
        return _instance.GenerateImage();
    }

    public byte[] ToBytes()
    {
        var image = ToImage();
        return ImageToBuffer(image, new PngEncoder());
    }

    public static byte[] ImageToBuffer(Image image, IImageEncoder imageFormat)
    {
        using var stream = new MemoryStream();
        image.Save(stream, new PngEncoder());

        stream.Position = 0;
        var data = new byte[stream.Length];
        var t = stream.Read(data, 0, Convert.ToInt32(stream.Length));
        stream.Flush();

        return data;
    }

  
}