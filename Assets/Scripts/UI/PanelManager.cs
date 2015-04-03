using UnityEngine;
using System.Collections;

public class PanelManager : MonoBehaviour {

    protected Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    public void showPanel()
    {
        anim.SetTrigger("SlideInTrigger");
    }

    public void hidePanel()
    {
        anim.SetTrigger("SlideOutTrigger");
    }

}
