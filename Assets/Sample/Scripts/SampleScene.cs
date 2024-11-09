using UnityEngine;
using UnityEngine.UI;

public class SampleScene : MonoBehaviour
{

    public Button TestToastButton;
    // Start is called before the first frame update
    
    private SampleKit sample = new SampleKit();
    void Start()
    {
        TestToastButton.onClick.AddListener(sample.CallTest);
    }
}