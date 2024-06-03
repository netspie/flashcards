using Plugin.Maui.Audio;

namespace FlashcardApp.Common;

public interface IAudioService
{
    Task StartRecordingAsync();
    Task<Stream> StopRecordingAsync();
    bool IsRecording { get; }
}

public class AudioService : IAudioService
{
    private IAudioManager _audioManager;
    private IAudioRecorder _audioRecorder;
    public bool IsRecording => _audioRecorder.IsRecording;

    public AudioService(IAudioManager audioManager)
    {
        _audioManager = audioManager;
        _audioRecorder = audioManager.CreateRecorder();
    }

    public async Task StartRecordingAsync()
    {
        await _audioRecorder.StartAsync();
    }

    public async Task<Stream> StopRecordingAsync()
    {
        var recordedAudio = await _audioRecorder.StopAsync();
        return recordedAudio.GetAudioStream();
    }
}