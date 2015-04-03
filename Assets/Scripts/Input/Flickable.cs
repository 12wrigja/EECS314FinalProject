using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Flickable : MonoBehaviour {

    public float dampeningFactor = 0.01f;

    private float zLayer;
    private bool isBeingSelected = false;
    private Renderer objRenderer;
    private float timeOfActionStart;
    private Rigidbody2D rigid;

    // Use this for initialization
    void Start()
    {
        zLayer = transform.position.z;
        this.objRenderer = GetComponent<Renderer>();
        this.rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        zLayer = transform.position.z;
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            Vector3 worldSpace = Camera.main.ScreenToWorldPoint(t.position);
            Vector3 layerLocal = new Vector3(worldSpace.x, worldSpace.y, zLayer);
            if (t.phase == TouchPhase.Began)
            {
                Bounds b = objRenderer.bounds;
                if (b.Contains(layerLocal))
                {
                    isBeingSelected = true;
                    timeOfActionStart = Time.time;
                }
            }
            else if (t.phase == TouchPhase.Ended)
            {
                isBeingSelected = false;
                float elapsedTime = Time.time - timeOfActionStart;
                Debug.Log("Action Time: " + elapsedTime);
                Vector3 directionVector = layerLocal - transform.position;
                float distance = directionVector.magnitude;
                Debug.Log("Action Distance: " + distance);
                float velocity = distance / elapsedTime;
                if (velocity > 5f)
                {
                    Debug.Log("Adding Force");
                    rigid.AddForce(new Vector2(directionVector.x, directionVector.y), ForceMode2D.Impulse);
                }
            }
        }
    }
}
