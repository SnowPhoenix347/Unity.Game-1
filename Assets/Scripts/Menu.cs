using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Animator _creatorsAnimator;

    public void OnPlayButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    public void OnCreatorsButtonClick()
    {
        _creatorsAnimator.SetBool("IsShow", !_creatorsAnimator.GetBool("IsShow"));
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}
