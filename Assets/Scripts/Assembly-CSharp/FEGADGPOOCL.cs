using System;

public interface FEGADGPOOCL : IDisposable
{

 event Action IntroCompleted;

	void Init();

	void ManualUpdate();
}
