using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStart : MonoBehaviour {

	public void changemenuscene(string scenename)
    {
#pragma warning disable CS0618 // Type or member is obsolete
        Application.LoadLevel(scenename);
#pragma warning restore CS0618 // Type or member is obsolete
    }
	
}
