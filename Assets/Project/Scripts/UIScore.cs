using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
    public string Prefix;

    private int _score;
    public int Score
    {
        get { return _score; }
        set
        {
            _text.text = string.Format("{0}: {1}", Prefix, value);
            _score = value;
        }
    }

    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }
}