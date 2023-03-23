using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Cube[] Blocks;
    private void Awake()
    {
        SetupBlock();
    }

    private void SetupBlock() {

        foreach (Cube Cub in Blocks)
        {
            int live = Random.Range(0,9);
            Cub.SetLives(live);
        }
    }

}
