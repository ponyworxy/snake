using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public float speed;
    public GameObject Road;
    public Player player;
    public GameMusic music;
    public GameUI gameui;
    public enum State { Play, Win, Die }
    public State GameState { get; private set; }

    public int LevelCounter {
        get => PlayerPrefs.GetInt("LevelIndex", 1);
        private set 
        {
            PlayerPrefs.SetInt("LevelIndex", value);
            PlayerPrefs.Save();
        }
    }

    private float _xmin, _xmax;
    private float _viewDistance;
    private Vector3 _Point;
    private float _HeadRadius;
    private float _speed;

    private void Awake()
    {
  
        _HeadRadius = player.Head.GetComponent<SphereCollider>().radius * player.Head.transform.localScale.y;
        _Point = new Vector3(0, _HeadRadius, 0);

        Debug.Log(Road.GetComponent<MeshCollider>().bounds.min);
        Debug.Log(Road.GetComponent<MeshCollider>().bounds.max);

        _xmin = Road.GetComponent<MeshCollider>().bounds.min.x + _HeadRadius;
        _xmax = Road.GetComponent<MeshCollider>().bounds.max.x - _HeadRadius;

        float CamZ = Camera.main.transform.position.z;
        float CamY = Camera.main.transform.position.y;

        _viewDistance = Mathf.Sqrt(Mathf.Pow(CamZ,2)+Mathf.Pow(CamY,2)); // Растояние от камеры до линии Х

        _speed = speed;
    }

    private void FixedUpdate()
    {
       transform.Translate(Vector3.back*speed*Time.deltaTime); // Движение уровня 
    }

    private void Update()
    {
        
        if(Input.GetMouseButtonDown(0)) { 
            Vector3 Mouse = Input.mousePosition;
            Mouse.z = _viewDistance;
            Vector3 Point = Camera.main.ScreenToWorldPoint(Mouse);
            if (Point.x < _xmin) { Point.x = _xmin;  }
            else if (Point.x > _xmax) { Point.x = _xmax; } 
            _Point = new Vector3(Point.x,_HeadRadius, 0);
        }

        player.Head.transform.position = Vector3.Lerp(player.Head.transform.position, _Point, player.speed*Time.deltaTime); ;

    }

    public void OnDie()
    {   
        GameState = State.Die;
        speed = 0;
        gameui.uiGame.SetActive(false);
        gameui.uiDie.SetActive(true); // Почему-то не работает
        gameui.uiDie.active = true;
        music.PlayDie();
    }

    public void OnFinish() 
    {
        GameState = State.Win;
        speed = 0;
        gameui.uiGame.SetActive(false);
        gameui.uiWin.SetActive(true); // Почему-то не работает
        gameui.uiWin.active = true;
        music.PlayWin();
    }

    public void NextLevel() 
    {
        LevelCounter++;
        if (LevelCounter > 3) LevelCounter = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResetLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
