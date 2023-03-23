using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float speed;
    public GameObject Head;
    public GameObject Tail;
    public Level level;


    private List<GameObject> Tails = new List<GameObject>();
    public int Lives;
    private int _Lives;
    private bool _isLive = true;

    private void Awake()
    {
        for (int i = 0; i < Lives; i++) AddLive();
    }

    void Update()
    {

        if (!_isLive) return;

        for (int i = 0; i < Tails.Count; i++)
        {
            Vector3 Move = new Vector3(Head.transform.position.x, Tails[i].transform.position.y, Tails[i].transform.position.z);
            Tails[i].transform.position = Vector3.Lerp(Tails[i].transform.position, Move, Time.deltaTime * this.speed/(i+1));
        }

    }

    public void AddLive() {
        _Lives++;
        Vector3 tailpos = Tails.Count == 0 ? Head.transform.position : Tails[^1].transform.position;
        tailpos.z -= 0.5f;
        GameObject NewTail = Instantiate(Tail, tailpos, Quaternion.identity ,this.transform);
        Tails.Add(NewTail);
    }

    public void RemoveLive() {

        if (!_isLive) return;

        _Lives--;
        GameObject LastTail = Tails[^1];
        Tails.RemoveAt(Tails.Count-1);
        Destroy(LastTail.gameObject);
        if (_Lives <= 0) Die();
   }

    private void Die() {
        _isLive = false;
        level.OnDie();
        Debug.Log("Player Died!");
        
    }

    public int SnakeLives() {
        return _Lives;
    }

}
