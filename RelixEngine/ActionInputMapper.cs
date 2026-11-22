namespace RelixEngine;

public class ActionInputMapper : IActionInput
{
  private readonly IGameInput _keyInput;
  private readonly Dictionary<GameAction, EngineKey[]> _bindings;

  public ActionInputMapper(IGameInput keyInput)
  {
    _keyInput = keyInput;
    _bindings = new Dictionary<GameAction, EngineKey[]>
    {
      [GameAction.MoveUp] = [EngineKey.W],
      [GameAction.MoveDown] = [EngineKey.S],
      [GameAction.MoveLeft] = [EngineKey.A],
      [GameAction.MoveRight] = [EngineKey.D],
      [GameAction.Interact] = [EngineKey.Space],
      [GameAction.Pause] = [EngineKey.Escape]
    };
  }

  public bool IsActionDown(GameAction action)
  {
    if(!_bindings.TryGetValue(action, out var keys))
    {
      return false;
    }
    foreach(var key in keys)
    {
      if(_keyInput.IsKeyDown(key))
      {
        return true;
      }
    }
    return false;
  }
}