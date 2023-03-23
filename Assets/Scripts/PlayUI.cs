using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayUI : MonoBehaviour
{
    public Text SnakeLives;
    public Text LevelCounter;
    public Player player;
    public Level level;

    private void Update()
    {
        SnakeLives.text = player.SnakeLives().ToString();
        LevelCounter.text = "Level: " + level.LevelCounter.ToString();
    }
}
