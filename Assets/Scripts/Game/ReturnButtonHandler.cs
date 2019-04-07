using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnButtonHandler : MonoBehaviour {

	public void ReturnButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
