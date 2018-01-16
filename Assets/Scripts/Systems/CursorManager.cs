using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour {

    [System.Serializable]
    public class TheCursor
    {
        public string Tag;
        public Texture2D CursorTexture;
    }

    public List<TheCursor> CursorList = new List<TheCursor>();

	// Use this for initialization
	void Start ()
    {
        SetCursorTexture(CursorList[0].CursorTexture);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000))
        {
            for (int i = 0; i < CursorList.Count; i++)
            {
                if (hit.collider.tag == CursorList[i].Tag)
                {
                    SetCursorTexture(CursorList[i].CursorTexture);
                    return;
                }
            }
        }

        SetCursorTexture(CursorList[0].CursorTexture);

	}

    void SetCursorTexture(Texture2D tex)
    {
        Cursor.SetCursor(tex, Vector2.zero, CursorMode.Auto);
    }

}
