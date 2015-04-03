using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[ExecuteInEditMode]
public class AutoResizeGrid : MonoBehaviour {

    public GridLayoutGroup grid;
	
	// Update is called once per frame
	void Update () {
        Debug.Log(((RectTransform)transform).rect);
        grid.cellSize = new Vector2(((RectTransform)transform).rect.width, grid.cellSize.y);
	}
}
