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
    Console.WriteLine("Ash and Silver game initialized.");
  }
  
  protected override void Update(float deltaTime)
  {
    base.Update(deltaTime);
    Console.WriteLine($"Ash and Silver game updated. Delta time: {deltaTime} seconds.");
  }
  protected override void Render()
  {
    base.Render();
    Console.WriteLine("Ash and Silver game rendered.");
  }
}