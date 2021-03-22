using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCoroutineUpdate : MonoBehaviour
{
    public WaitForSeconds UpdateTime = new WaitForSeconds(.05f);

    private float timeLastUpdate = 0;
    protected float deltaTime = 0;
    protected float timeScale => deltaTime / Time.deltaTime;

    protected void Start()
    {
        timeLastUpdate = 0;
        deltaTime = 0;
        StartCoroutine(UpdateRoutine());
    }

    private IEnumerator UpdateRoutine()
    {
        while (true)
        {
            deltaTime = Time.timeSinceLevelLoad - timeLastUpdate;
            Debug.Log(timeScale);
            OnUpdate();
            timeLastUpdate = Time.timeSinceLevelLoad;
            yield return UpdateTime;
        }
    }

    protected abstract void OnUpdate();
}
