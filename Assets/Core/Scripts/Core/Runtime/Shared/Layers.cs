public static class Layers
{
    public const int Default = 0;
    public const int TransparentFX = 1;
    public const int IgnoreRaycast = 2;
    public const int Ground = 3;
    public const int Water = 4;
    public const int UI = 5;
    public const int Trigger = 6;

    public static class Mask
    {
        public const int Default = 1;
        public const int TransparentFX = 2;
        public const int IgnoreRaycast = 4;
        public const int Ground = 8;
        public const int Water = 16;
        public const int UI = 32;
        public const int Trigger = 64;
    }
}
