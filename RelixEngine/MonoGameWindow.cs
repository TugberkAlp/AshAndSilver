using Microsoft.Xna.Framework;

namespace RelixEngine;

public class MonoGameWindow : IGameWindow
{
  public int Width { get; }
  public int Height { get; }
  public string Title { get; }
  private bool _isOpen;
  private InternalMonoGameHost? _host;
  public bool IsOpen => _isOpen;

  public MonoGameWindow(int width = 1280, int height = 720, string title = "Ash and Silver")
  {
    Width = width;
    Height = height;
    Title = title;
    _isOpen = false;
  }

  public void Open()
  {
    _isOpen = true;
    _host = new InternalMonoGameHost(this);
  }

  public void Close()
  {
    _isOpen = false;
    _host?.Exit();
  }

  private sealed class InternalMonoGameHost : Game
  {
    private readonly GraphicsDeviceManager _graphics;
    private readonly MonoGameWindow _owner;

    public InternalMonoGameHost(MonoGameWindow owner)
    {
      _owner = owner;
      _graphics = new GraphicsDeviceManager(this);
      Window.Title = _owner.Title;
      _graphics.PreferredBackBufferWidth = _owner.Width;
      _graphics.PreferredBackBufferHeight = _owner.Height;
    }
  }
}
