using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedObjectManager))]
public class ARTrackObjectContrl : MonoBehaviour
{
    ARTrackedObjectManager aRTrackedObjectManager;

    public GameObject currentObj;

    void Awake()
    {
        aRTrackedObjectManager = GetComponent<ARTrackedObjectManager>();
    }

    private void OnEnable()    {        aRTrackedObjectManager.trackedObjectsChanged += OnTrackedObjectsChanged;    }    void OnDisable()    {        aRTrackedObjectManager.trackedObjectsChanged -= OnTrackedObjectsChanged;    }
    // Update is called once per frame
    void Update()
    {

    }


    void OnTrackedObjectsChanged(ARTrackedObjectsChangedEventArgs eventArgs)
    {
        foreach (var trackedObject in eventArgs.added)        {            Debug.Log("trackedObject:" + trackedObject.name);            GameObject obj = GameObject.Instantiate(currentObj, trackedObject.transform);            Debug.Log("objPos:" + obj.transform.localPosition);            Debug.Log("objScale:" + obj.transform.localScale);            Debug.Log("objRota:" + obj.transform.eulerAngles);        }
    }
}
