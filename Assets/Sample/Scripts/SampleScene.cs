using System.Collections;
using System.Collections.Generic;
using PJ.Native.Bridge;
using PJ.Native.Messenger;
using UnityEngine;

public class SampleScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start sampleScene~");
        NativeNode node = new NativeNode();
        MessageManager.Instance.Mediator.Add(node);
        SampleNode sampleNode = new SampleNode();
        MessageManager.Instance.Mediator.Add(sampleNode);
        sampleNode.CallTest();
        // NativeBridge.Instance.AddNativeMessageListener((message) =>
        // {
        //     Debug.Log("from native : " + message); 
        // });

        // NativeBridge.Instance.Send("unity_add_event|testReturn");

        // NativeBridge.Instance.Send("test|first");
        // NativeBridge.Instance.Send("testRecall|second");
    }
}
