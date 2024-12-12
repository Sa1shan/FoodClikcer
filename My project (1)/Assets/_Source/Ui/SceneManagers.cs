using UnityEngine;

namespace _Source.Ui
{
    public class SceneManagers : MonoBehaviour
    {
        [SerializeField] private int scenenumber;
        public void SceneManager()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(scenenumber);
        }
    }
}
