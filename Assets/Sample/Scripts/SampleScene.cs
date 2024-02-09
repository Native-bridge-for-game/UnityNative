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
        SampleKit sample = new SampleKit();
        sample.CallTest();
    }
}
