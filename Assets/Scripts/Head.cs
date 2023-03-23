using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public Player player;
    public Level level;

    public AudioClip sfxBump, sfxEat;
    private AudioSource _sound;

    public GameObject vfxBump, vfxEat;

    private void Awake()
    {
        _sound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Cube cube)) {
            GetDamage(cube.Lives);
            _sound.PlayOneShot(sfxBump);
            vfxBump.gameObject.SetActive(true);
            vfxBump.GetComponent<ParticleSystem>().Play();
        }

        if (collision.gameObject.TryGetComponent(out Food food)) {
            GetHealth(food.Lives);
            food.Eated();
            _sound.PlayOneShot(sfxEat);
            vfxEat.gameObject.SetActive(true);
            vfxEat.GetComponent<ParticleSystem>().Play();
        }

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
