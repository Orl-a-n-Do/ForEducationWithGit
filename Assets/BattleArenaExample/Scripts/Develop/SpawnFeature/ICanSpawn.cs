public interface ICanSpawn
{
    float TimeToSwpawn { get; }
    bool InSpawnProcess(out float elapsedTime);
}
