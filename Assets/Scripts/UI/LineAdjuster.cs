using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LineAdjuster : MonoBehaviour {

    private static LineAdjuster instance;

    public GridLayoutGroup lineContainer;
    public GameObject buttonContainer;
    public GameObject backgroundClickContainer;
    public ConfirmDialog confirmDialogObj;

    public Button lineUpButton;
    public Button lineDeleteButton;
    public Button lineDownButton;

    private CodeLine currentLine;

    void Start()
    {
        instance = this;
        backgroundClickContainer.SetActive(false);
        backgroundClickContainer.GetComponent<Button>().onClick.AddListener(() => HideAdjuster());
        lineUpButton.onClick.AddListener(() => ShiftLineUp(currentLine));
        lineDownButton.onClick.AddListener(() => ShiftLineDown(currentLine));
        lineDeleteButton.onClick.AddListener(() => DeleteCodeLine(currentLine));
    }

    void Update()
    {
        //Make the line adjustor stick to the line until you dismiss it.
        if (instance.currentLine != null)
        {
            instance.buttonContainer.transform.position = instance.currentLine.lineAdjustButton.gameObject.transform.position;
        }
    }

    public static void ShowAdjusterForLine(CodeLine line)
    {
        Debug.Log("Line Adjuster summoned.!");
        instance.currentLine = line;
        instance.buttonContainer.SetActive(true);
        instance.buttonContainer.transform.position = line.lineAdjustButton.gameObject.transform.position;
        instance.backgroundClickContainer.SetActive(true);
    }

    public static void HideAdjuster()
    {
        Debug.Log("Hiding Adjuster!");
        instance.currentLine = null;
        instance.buttonContainer.SetActive(false);
        instance.backgroundClickContainer.SetActive(false);
    }

    private static void ShiftLineUp(CodeLine line)
    {
        int index = ((RectTransform)line.gameObject.transform).GetSiblingIndex();
        index--;
        ((RectTransform)line.gameObject.transform).SetSiblingIndex(index);
    }

    private static void DeleteCodeLine(CodeLine line)
    {
        instance.confirmDialogObj.contentText.text = "Do you want to delete this line?";
        instance.confirmDialogObj.AddConfirmListener(() =>
        {
            line.cleanup();
            Destroy(line.gameObject);
            HideAdjuster();
        });
        instance.confirmDialogObj.showPanel();
    }

    private static void ShiftLineDown(CodeLine line)
    {
        int index = ((RectTransform)line.gameObject.transform).GetSiblingIndex();
        index++;
        ((RectTransform)line.gameObject.transform).SetSiblingIndex(index);
    }
}
