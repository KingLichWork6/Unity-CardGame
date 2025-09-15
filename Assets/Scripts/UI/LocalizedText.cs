using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LocalizedText : MonoBehaviour
{
    [SerializeField] private bool _isIdentically;

    [SerializeField] private string _en;
    [SerializeField] private string _ru;

    private TextMeshProUGUI _text;

    private void OnEnable()
    {
        SettingsPanel.ChangeLanguage += UpdateText;
    }

    private void OnDisable()
    {
        SettingsPanel.ChangeLanguage -= UpdateText;
    }

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        if (LocalizationManager.Instance.Language == "en" || _isIdentically)
            _text.text = _en;
        else if (LocalizationManager.Instance.Language == "ru")
            _text.text = _ru;
    }

    public void UpdateText()
    {
        if (LocalizationManager.Instance.Language == "en" || _isIdentically)
            _text.text = _en;
        else if (LocalizationManager.Instance.Language == "ru")
            _text.text = _ru;
    }
}

