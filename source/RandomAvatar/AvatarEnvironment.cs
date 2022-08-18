namespace RandomAvatar;

public class AvatarEnvironment
{
    public bool IsHome
    {
        get
        {
            var isHome = Environment.GetEnvironmentVariable("RANDOM_AVATAR_HOME");
            return isHome is null or "true";
        }
    }

    public bool IsSymmetry
    {
        get
        {
            var isSymmetry = Environment.GetEnvironmentVariable("RANDOM_AVATAR_SYMMETRY");
            return isSymmetry is null or "true";
        }
    }

    public int Size
    {
        get
        {
            if (!int.TryParse(Environment.GetEnvironmentVariable("RANDOM_AVATAR_SIZE"), out var size))
            {
                size = 100;
            }

            return size;
        }
    }

    public int Padding
    {
        get
        {
            if (!int.TryParse(Environment.GetEnvironmentVariable("RANDOM_AVATAR_PADDING"), out var padding))
            {
                padding = 2;
            }
            return padding;
        }
    }
    public int BlockCount
    {
        get
        {
            if (!int.TryParse(Environment.GetEnvironmentVariable("RANDOM_AVATAR_BLOCK_COUNT"), out var blockCount))
            {
                blockCount = 2;
            }
            return blockCount;
        }
    }
    
}