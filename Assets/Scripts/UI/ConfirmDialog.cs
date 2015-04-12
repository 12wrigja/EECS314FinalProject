using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConfirmDialog : PanelManager {

    public Text contentText;
    public Button cancelButton;
    public Button confirmButton;


    public delegate void actionConfirmed();
    public delegate void actionCancelled();

    private actionConfirmed confirmListener;
    private actionCancelled cancellListener;

    new void Start()
    {
        base.Start();
        cancelButton.onClick.AddListener(() => onActionCancelled());
        confirmButton.onClick.AddListener(() => onActionConfirmed());
    }

    public void AddConfirmListener(actionConfirmed c)
    {
        confirmListener += c;
    }

    public void AddCancelListener(actionCancelled c)
    {
        cancellListener += c;
    }

    private void onActionConfirmed()
    {
        hidePanel();
        confirmListener();
    }

    private void onActionCancelled()
    {
        hidePanel();
        cancellListener();
    }
}
