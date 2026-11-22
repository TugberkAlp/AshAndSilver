using System.Collections.Concurrent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RelixEngine;

internal sealed class RenderQueue
{
  private readonly ConcurrentQueue<RectangleCommand> _rectangleQueue = new();

  private readonly struct RectangleCommand
  {
    public int X { get; }
    public int Y { get; }
    public int Width { get; }
    public int Height { get; }
    public EngineColor Color { get; }

    public RectangleCommand(int x, int y, int width, int height, EngineColor color)
    {
      X = x;
      Y = y;
      Width = width;
      Height = height;
      Color = color;
    }
  }

  public void EnqueueRectangle(int x, int y, int width, int height, EngineColor color)
  {
    _rectangleQueue.Enqueue(new RectangleCommand(x, y, width, height, color));
  }

  public void DrawAll(SpriteBatch spriteBatch, Texture2D pixelTexture)
  {
    spriteBatch.Begin();
    while (_rectangleQueue.TryDequeue(out var cmd))
    {
      var rect = new Rectangle(cmd.X, cmd.Y, cmd.Width, cmd.Height);
      var color = new Color(cmd.Color.R, cmd.Color.G, cmd.Color.B, cmd.Color.A);
      spriteBatch.Draw(pixelTexture, rect, color);
    }
    spriteBatch.End();
  }
}