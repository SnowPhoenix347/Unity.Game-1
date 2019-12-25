using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Animator _creatorsAnimator;
    public void OnPlayPress()
    {
        SceneManager.LoadScene(1);
    }

    public void OnCreatorsPress()
    {
        _creatorsAnimator.SetBool("IsShow", !_creatorsAnimator.GetBool("IsShow"));
    }

    public void OnExitPress()
    {
        Application.Quit();
    }
}
