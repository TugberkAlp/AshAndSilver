using RelixEngine;

namespace AshAndSilverGame;

public class AshAndSilver : GameEngine
{
  private readonly IGameWindow _window;

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
  }

  protected override void Render()
  {
    base.Render();
    _window.QueueRectangle(200, 180, 64, 64, EngineColor.White);
  }
}