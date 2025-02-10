using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "New-Ring/WaveConfig")]
public class WaveConfig : ScriptableObject
{
    // Количество врагов для текущей волны
    public int enemiesToSpawn;
}
