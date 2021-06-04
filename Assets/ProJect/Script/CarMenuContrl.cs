using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ARRaycastManager))]
public class CarMenuContrl : MonoBehaviour
{
    public GameObject CarPrefab;

    private GameObject SpawnObj;

    public GameObject CarPlane;

    public GameObject SpawnUI;

    public GameObject CarContrlUI;

    private ARPlaneManager planeManager;

    List<ARRaycastHit> hit = new List<ARRaycastHit>();
    Vector3 screenCenter = new Vector3(Screen.width * 0.5f,Screen.height * 0.5f,0);
    ARRaycastManager aRRaycastManager;

    private void Start()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();

        planeManager = GetComponent<ARPlaneManager>();
    }



    private void Update()
    {
        if (SpawnObj != null)
        {
            foreach (var item in planeManager.trackables)
            {
                item.gameObject.SetActive(false);
            }
        }

    }

    //放置物体
    public void OnSpawnContrl()
    {
        if (aRRaycastManager.Raycast(screenCenter,hit,TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hit[0].pose;

            if (SpawnObj == null)
            {
      
                SpawnObj = Instantiate(CarPrefab, hitPose.position, hitPose.rotation);

                SpawnObj.transform.localScale = new Vector3(1f,1f,1f);

                SpawnUI.SetActive(false);
                CarContrlUI.SetActive(true);

                
            }
        }
    }

    public void BackMainMenuClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
