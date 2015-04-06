using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LineAdjuster : MonoBehaviour {

    private static LineAdjuster instance;

    public GridLayoutGroup lineContainer;
    public GameObject buttonContainer;
    public GameObject backgroundClickContainer;

    private CodeLine currentLine;

    void Start()
    {
        instance = this;
        backgroundClickContainer.SetActive(false);
        backgroundClickContainer.GetComponent<Button>().onClick.AddListener(() => HideAdjuster());
    }

    public static void ShowAdjusterForLine(CodeLine line)
    {
        Debug.Log("Line Adjuster summoned.!");
        instance.currentLine = line;
        instance.buttonContainer.SetActive(true);
        instance.buttonContainer.transform.position = line.lineAdjustButton.gameObject.transform.position;
        instance.backgroundClickContainer.SetActive(true);
    }

    //public static void HideAdjuster()
    //{
    //    Debug.Log("Hiding Adjuster!");
    //    instance.currentLine = null;
    //    instance.backgroundClickContainer.enabled = false;
    //}

    public static void HideAdjuster()
    {
        Debug.Log("Hiding Adjuster!");
        instance.currentLine = null;
        instance.buttonContainer.SetActive(false);
        instance.backgroundClickContainer.SetActive(false);
    }
}
