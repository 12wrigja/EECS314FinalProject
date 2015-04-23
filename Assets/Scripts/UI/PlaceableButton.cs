using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[ExecuteInEditMode]
public class PlaceableButton : MonoBehaviour
{

    public string fillText;
    public Text fillTextDisplay;
    public Button btn;

    // Use this for initialization
    void Start()
    {
        btn = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fillTextDisplay != null && fillText != null)
        {
            fillTextDisplay.text = fillText;
        }
    }
}
