using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]

public class Draggable : MonoBehaviour {

    private float zLayer;
    private bool isBeingSelected = false;
    private Renderer objRenderer;

	// Use this for initialization
	void Start () {
        zLayer = transform.position.z;
        this.objRenderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        zLayer = transform.position.z;
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            Vector3 worldSpace = Camera.main.ScreenToWorldPoint(t.position);
            Vector3 layerLocal = new Vector3(worldSpace.x, worldSpace.y, zLayer);
            if (t.phase == TouchPhase.Began)
            {
                Bounds b = objRenderer.bounds;
                Debug.Log(b);
                Debug.Log(layerLocal);
                Debug.Log(b.Contains(layerLocal));
                if (b.Contains(layerLocal))
                {
                    isBeingSelected = true;
                }
            }
            else if (t.phase == TouchPhase.Moved && isBeingSelected)
            {
                transform.position = layerLocal;
            }
            else if (t.phase == TouchPhase.Ended)
            {
                isBeingSelected = false;
            }
        }
	}
}
