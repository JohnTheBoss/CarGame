using UnityEngine;
using UnityEngine.UI;

public class AppVersion : MonoBehaviour {
    public Text Version;

    private void Start()
    {
        Version.text = "v" + Application.version;
    }
}
