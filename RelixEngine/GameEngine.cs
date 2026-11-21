using System.Diagnostics;
using System.Threading;

namespace RelixEngine;

public abstract class GameEngine
{
  private const double TargetFramesPerSecond = 60.0;
  private const double MillisecondsPerSecond = 1000.0;
  private const double SecondsPerMillisecond = 0.001;
  private const float MaxDeltaTimeSeconds = 0.05f;

  private bool _engineIsRunning;
  
  protected virtual void Initialize()
  {
    // Oyun açıldığında bir kez çalışacak başlangıç mantığı buraya yazılır.
  }

  protected virtual void Update(float deltaTime)
  {
    // Oyun her frame çalıştığında çalışacak mantık buraya yazılır.
  }
  protected virtual void Render()
  {
    // Oyun her frame çalıştığında ekrana çizim yapılır.
  }

  public void Run()
  {
    _engineIsRunning = true;
    Initialize();

    Stopwatch stopwatch = Stopwatch.StartNew();
    double previousElapsedMilliseconds = stopwatch.Elapsed.TotalMilliseconds;
    double targetFrameDurationMilliseconds = MillisecondsPerSecond / TargetFramesPerSecond;

    while(_engineIsRunning)
    {
      double currentElapsedMilliseconds = stopwatch.Elapsed.TotalMilliseconds;
      double rawDeltaMilliseconds = currentElapsedMilliseconds - previousElapsedMilliseconds;
      previousElapsedMilliseconds = currentElapsedMilliseconds;

      float deltaTime = (float)(rawDeltaMilliseconds * SecondsPerMillisecond);
      deltaTime = Math.Min(deltaTime, MaxDeltaTimeSeconds);
      Update(deltaTime);
      Render();
      double frameEndMilliseconds = stopwatch.Elapsed.TotalMilliseconds;
      double totalFrameDurationMilliseconds = frameEndMilliseconds - currentElapsedMilliseconds;
      
      double remainingMilliseconds = targetFrameDurationMilliseconds - totalFrameDurationMilliseconds;

      if (remainingMilliseconds >= 1.0)
      {
        Thread.Sleep((int)remainingMilliseconds);
      }
    }
  }

  public void Stop()
  {
    _engineIsRunning = false;
  }

}
