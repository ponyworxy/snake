using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public Player player;
    public Level level;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Head on " + collision.gameObject.name);

        if (collision.gameObject.TryGetComponent(out Cube cube)) {
            GetDamage(cube.Lives);
        }

        if (collision.gameObject.TryGetComponent(out Food food)) {
            GetHealth(food.Lives);
            food.Eated();
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Head offfffff " + collision.gameObject.name);
    }


    private void GetDamage(int Damage) {

        for (int i = 0; i < Damage; i++)
        {
            player.RemoveLive();
        }

    }

    private void GetHealth(int Health) {

        for (int i = 0; i < Health; i++) { 
            player.AddLive();
        }

    }

}
