using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public Level level;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Head head)) {

            level.OnFinish();
        }
    }

}
