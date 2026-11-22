using Microsoft.Xna.Framework.Input;

namespace RelixEngine;

public class MonoGameInput : IGameInput
{
  private KeyboardState _currentState;

  public void Update()
  {
    _currentState = Keyboard.GetState();
  }

  public bool IsKeyDown(EngineKey key)
  {
    return key switch
    {
      EngineKey.W => _currentState.IsKeyDown(Keys.W),
      EngineKey.S => _currentState.IsKeyDown(Keys.S),
      EngineKey.A => _currentState.IsKeyDown(Keys.A),
      EngineKey.D => _currentState.IsKeyDown(Keys.D),
      EngineKey.Space => _currentState.IsKeyDown(Keys.Space),
      EngineKey.Escape => _currentState.IsKeyDown(Keys.Escape),
      _ => false
    };
  }
}
