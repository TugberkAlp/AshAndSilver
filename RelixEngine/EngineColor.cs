namespace RelixEngine;

public readonly struct EngineColor
{
  public byte R { get; }
  public byte G { get; }
  public byte B { get; }
  public byte A { get; }
  public EngineColor(byte r, byte g, byte b, byte a = 255)
  {
    R = r;
    G = g;
    B = b;
    A = a;
  }

  public static readonly EngineColor Black = new(0, 0, 0);
  public static readonly EngineColor White = new(255, 255, 255);
  public static readonly EngineColor CornflowerBlue = new(100, 149, 237);
  public static readonly EngineColor MediumPurple = new(147, 112, 219);
}
