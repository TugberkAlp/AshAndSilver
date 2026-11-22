using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RelixEngine;

public class MonoGameWindow : IGameWindow
{
  public int Width { get; }
  public int Height { get; }
  public string Title { get; }
  public EngineColor BackgroundColor { get; set; } = EngineColor.MediumPurple;
  public bool IsOpen => _isOpen;

  private bool _isOpen;
  private InternalMonoGameHost? _host;
  private readonly RenderQueue _renderQueue = new();

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

  public void QueueRectangle(int x, int y, int width, int height, EngineColor color)
  {
    _renderQueue.EnqueueRectangle(x, y, width, height, color);
  }

  private sealed class InternalMonoGameHost : Game
  {
    private readonly GraphicsDeviceManager _graphics;
    private readonly MonoGameWindow _owner;
    private SpriteBatch? _spriteBatch;
    private Texture2D? _pixelTexture;

    public InternalMonoGameHost(MonoGameWindow owner)
    {
      _owner = owner;
      _graphics = new GraphicsDeviceManager(this);
      Window.Title = _owner.Title;
      _graphics.PreferredBackBufferWidth = _owner.Width;
      _graphics.PreferredBackBufferHeight = _owner.Height;
      Exiting += (_, _) => _owner.Close();
    }

    protected override void LoadContent()
    {
      _spriteBatch = new SpriteBatch(GraphicsDevice);
      _pixelTexture = new Texture2D(GraphicsDevice, 1, 1);
      _pixelTexture.SetData(new[] { Color.White });
      base.LoadContent();
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
      var bg = _owner.BackgroundColor;
      GraphicsDevice.Clear(new Color(bg.R, bg.G, bg.B, bg.A));

      if (_spriteBatch != null && _pixelTexture != null)
      {
        _owner._renderQueue.DrawAll(_spriteBatch, _pixelTexture);
      }

      base.Draw(gameTime);
    }
  }
}