using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interectable : MonoBehaviour {

    public virtual void Interact()
    {
        Debug.Log("You interacted with: " + transform.name);
    }

}
