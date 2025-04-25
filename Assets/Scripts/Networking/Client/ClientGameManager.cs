using System.Threading.Tasks;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ClientGameManager
{
    private const string MenuSceneName = "Menu";
    public async Task<bool> InitAsync()
    {
        await UnityServices.InitializeAsync();

        AuthState authState = await AuthenticationWrapper.DoAuth();

        if (authState == AuthState.Authenticated)
        {
            Debug.Log("Authenticated successfully!");
            return true;
        }
        else
        {
            Debug.LogError("Authentication failed!");
            return false;
        }
    }

    public void GoToMenu()
    {

        SceneManager.LoadScene(MenuSceneName);
        Debug.Log("Loading menu scene...");
    }

}