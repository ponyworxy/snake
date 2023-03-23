using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public int Lives;
    public TextMesh LivesText;
    public GameObject[] Foods;

    private void Awake()
    {
        int i = Random.Range(0, Foods.Length);
        Vector3 pos = new Vector3(0,0,0);
        Quaternion rot = Quaternion.Euler(0, 0, 0);
        Instantiate(Foods[i],transform.TransformPoint(pos),rot,transform);

        i = Random.Range(0, 6);
        Lives = i;
    }

    private void Update()
    {
        LivesText.text = Lives.ToString();
        if (Lives <= 0) Destroy(this.gameObject);
    }

    public void Eated() {
        Destroy(this.gameObject);
    }

}
