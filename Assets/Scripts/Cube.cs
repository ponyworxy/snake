using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class Cube : MonoBehaviour
{

    public int Lives;
    public GameObject TextFront, TextUp;
    public Renderer randy;

    private void Awake()
    {
        randy = GetComponent<Renderer>();
    }

    private void Update()
    {
        TextFront.GetComponent<TextMesh>().text = Lives.ToString();
        TextUp.GetComponent<TextMesh>().text = Lives.ToString();

        if (Lives <=0) Destroy(this.gameObject);
        
        randy.material.SetFloat("_LiveCount", Lives);
    }

    
    private void OnCollisionEnter(Collision collision)

    {
        if (collision.gameObject.TryGetComponent(out Head head))
            {
            Damage(head.player.Lives);
            }
    }
   

    public void SetLives(int liv)
    {
        Lives = liv;
    }

    public void Damage(int dmg) {
        Lives -= dmg;
        if (Lives <= 0) Die();
    }

    public void Die() {

        Destroy(this.gameObject);
    }

}
