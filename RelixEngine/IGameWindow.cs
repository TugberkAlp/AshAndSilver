namespace RelixEngine;

public interface IGameWindow
{
  bool IsOpen { get; }
  EngineColor BackgroundColor { get; set; }
  void Open();
  void Close();
  void Tick();
  void QueueRectangle(int x, int y, int width, int height, EngineColor color);
}