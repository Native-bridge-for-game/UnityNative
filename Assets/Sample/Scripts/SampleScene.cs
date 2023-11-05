using System.Collections;
using System.Collections.Generic;
using PJ.Native;
using UnityEngine;

public class SampleScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        NativeBridge.Instance.Send("test 1");
        NativeBridge.Instance.Send("test 2", (response) => { Debug.Log("from android : " + response); });
    }
}
