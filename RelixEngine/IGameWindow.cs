namespace RelixEngine;

public interface IGameWindow
{
  bool IsOpen { get; }
  void Open();
  void Close();
}