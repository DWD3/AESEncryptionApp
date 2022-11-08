using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{

    [SerializeField] private GameObject _encryptionScreen;
    
    
    [SerializeField] private GameObject _homeScreen;

    [SerializeField] private InputField _keyInputField;

    [SerializeField] private EncryptionManager _encryptionManager;
    [SerializeField] private DecryptionManager _decryptionManager;
    

    public void OpenHomeScreen()
    {
        _homeScreen.SetActive(true);
        _encryptionScreen.SetActive(false);
    }

    public void OpenEncryptionWindow()
    {
        if (_keyInputField.text.Length != 0)
        {
            _encryptionScreen.SetActive(true);
            _homeScreen.SetActive(false);
            _decryptionManager.SetKey(_keyInputField.text);
            _encryptionManager.SetKey(_keyInputField.text);
        }
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
