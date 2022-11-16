using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathingManager : MonoBehaviour
{

    [SerializeField]
    private List<Transform> waypoints = new List<Transform>();
    private GameObject pathObject;
    [SerializeField]
    private int lastStop;
    [SerializeField]
    private int nextStop = 0;
    [SerializeField]
    private float waypointSense;

    // Start is called before the first frame update
    void Start()
    {
        if (pathObject == null) pathObject = GameObject.Find("Path");
        for (int i = 0; i < pathObject.transform.childCount; i++)
        {
            waypoints.Add(pathObject.transform.GetChild(i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, new Vector2(waypoints[nextStop].position.x, waypoints[nextStop].position.y), Time.deltaTime);
        if (Vector2.Distance(transform.position, waypoints[nextStop].position) < waypointSense) ReachPoint(nextStop);
    }

    private void ReachPoint(int point)
    {
        lastStop = nextStop;
        if (nextStop + 1 >= waypoints.Count)
            nextStop = 0;
        else
            nextStop = nextStop + 1;
    }
}
