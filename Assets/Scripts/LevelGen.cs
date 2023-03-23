using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class LevelGen : MonoBehaviour
{
    public int MinGen, MaxGen;
    public GameObject Block, Food;
    public Finish finish;
    public Level level;
    public float BlockDistance;
    public int offset;

    private void Awake()
    {
        int Blocks = Random.Range(MinGen,MaxGen+1);
        offset *= 2;

        level.Road.transform.localScale = new Vector3(1, 1, Blocks+offset);

        for (int i = 0; i < level.Road.transform.childCount; i++) {

            Renderer roadpart = level.Road.transform.GetChild(i).gameObject.GetComponent<Renderer>();
            roadpart.material.mainTextureScale = new Vector2(roadpart.material.mainTextureScale.x,roadpart.material.mainTextureScale.y*(Blocks+offset));
        }

        finish.transform.position = new Vector3(0, 0, 10*(Blocks+offset) + 5);

        for (int i = offset; i < Blocks+offset; i++) {

            Vector3 position = new Vector3(0, 1, BlockDistance * i);
            position.y *= this.transform.localScale.y;
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            GameObject GenPlatform = Instantiate(Block, position, rotation, transform);

            
            int PosX = Random.Range(-2, 3)*2;
            Vector3 FoodPos = new Vector3(PosX, 0.5f, BlockDistance * i - 5 );
            GameObject Foody = Instantiate(Food, FoodPos, rotation, transform);

        }


    }

}
