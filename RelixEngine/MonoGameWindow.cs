using Microsoft.Xna.Framework;

namespace RelixEngine;

public class MonoGameWindow : IGameWindow
{
  public Color ClearColor { get; set; } = Color.MediumPurple;
  public int Width { get; }
  public int Height { get; }
  public string Title { get; }
  public bool IsOpen => _isOpen;
  private bool _isOpen;
  private InternalMonoGameHost? _host;

  public MonoGameWindow(string title = "Ash and Silver", int width = 1280, int height = 720)
  {
    Title = title;
    Width = width;
    Height = height;
    _isOpen = false;
  }

  public void Open()
  {
    _isOpen = true;
    _host = new InternalMonoGameHost(this);
    _host.StartHost();
  }

  public void Close()
  {
    _isOpen = false;
    _host?.Exit();
  }

  public void Tick()
  {
    if (!_isOpen || _host == null)
    {
      return;
    }
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
      Exiting += (_, _) => _owner.Close();
    }
    public void StartHost()
    {
      Thread thread = new Thread(() =>
      {
        Run();
      });
      thread.IsBackground = true;
      thread.Start();
    }

    protected override void Draw(GameTime gameTime)
    {
      GraphicsDevice.Clear(_owner.ClearColor);
      base.Draw(gameTime);
    }
  }
}
