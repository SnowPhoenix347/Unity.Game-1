using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Animator _creators;

    public void OnPlayButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    public void OnCreatorsButtonClick()
    {
        _creators.SetBool("IsShow", !_creators.GetBool("IsShow"));
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}
