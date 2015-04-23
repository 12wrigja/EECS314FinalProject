using UnityEngine;
using System.Collections;

public class PanelManager : MonoBehaviour {

    protected Animator anim;

	// Use this for initialization
	protected void Start () {
        anim = GetComponent<Animator>();
	}

    public virtual void showPanel()
    {
        anim.SetTrigger("SlideInTrigger");
    }

    public virtual void hidePanel()
    {
        anim.SetTrigger("SlideOutTrigger");
    }

}
