using UnityEngine;
using System.Collections;

public class ResizeToFitContent : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        float totalHeight = 0f;
        foreach (Transform t in GetComponentInChildren<Transform>())
        {
            RectTransform r = (RectTransform)t;
            totalHeight += r.rect.height;
        }
        float width = ((RectTransform)transform).rect.width;
        
	}
}
