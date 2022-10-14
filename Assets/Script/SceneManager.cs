using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{

    [SerializeField] private GameObject _encryptionScreen;

    [SerializeField] private GameObject _decryptionScreen;
    
    [SerializeField] private GameObject _homeScreen;
    

    public void OpenHomeScreen()
    {
        _homeScreen.SetActive(true);
        _encryptionScreen.SetActive(false);
        _decryptionScreen.SetActive(false);
    }

    public void OpenEncryptionWindow()
    {
        _encryptionScreen.SetActive(true);
        _decryptionScreen.SetActive(false);
        _homeScreen.SetActive(false);
    }

    public void OpenDecryptionWindow()
    {
        _encryptionScreen.SetActive(false);
        _decryptionScreen.SetActive(true);
        _homeScreen.SetActive(false);
    }
}
