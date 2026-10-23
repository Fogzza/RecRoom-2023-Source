public interface BILDPPLNMGI
{

 bool IsReadyForPlayback
{
get ;
}

 bool CanStartLocalRecording
{
get ;
}

 OHMOFFLPCKG CurrentRecordingSubState
{
get ;
}

 float LocalRecordingProgress
{
get ;
}

 string StartRecordingPrompt
{
get ;
}

	void TryEnterRecordingFlow();

	void TryExitRecordingFlow();

	void TryStartRecording();

	void TryFinishRecording();

	void TrySaveRecording();
}
