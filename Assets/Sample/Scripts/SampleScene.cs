using System.Collections;
using System.Collections.Generic;
using PJ.Native;
using UnityEngine;

public class SampleScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start sample~");
        NativeBridge.Instance.AddNativeMessageListener((message) =>
        {
            Debug.Log("from native : " + message); 
        });

        NativeBridge.Instance.Send("unity_add_event|testReturn");

        NativeBridge.Instance.Send("test|first");
        NativeBridge.Instance.Send("testRecall|second");
    }
}
