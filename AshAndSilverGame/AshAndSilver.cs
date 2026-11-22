using RelixEngine;

namespace AshAndSilverGame;

public class AshAndSilver : GameEngine
{
  private readonly IGameWindow _window;
  private float _x = 200f;
  private float _y = 180f;
  private const float Speed = 200f;

  public AshAndSilver() : this(new MonoGameWindow())
  {
  }

  private AshAndSilver(IGameWindow window) : base(window)
  {
    _window = window;
  }

  protected override void Initialize()
  {
    _window.BackgroundColor = EngineColor.CornflowerBlue;
    base.Initialize();
  }

  protected override void Update(float deltaTime)
  {
    base.Update(deltaTime);
    if (_window.Input.IsKeyDown(EngineKey.A))
    {
      _x -= Speed * deltaTime;
    }
    if (_window.Input.IsKeyDown(EngineKey.D))
    {
      _x += Speed * deltaTime;
    }
    if (_window.Input.IsKeyDown(EngineKey.W))
    {
      _y -= Speed * deltaTime;
    }
    if (_window.Input.IsKeyDown(EngineKey.S))
    {
      _y += Speed * deltaTime;
    }
  }

  protected override void Render()
  {
    base.Render();
    _window.QueueRectangle((int)_x, (int)_y, 64, 64, EngineColor.White);
  }
}