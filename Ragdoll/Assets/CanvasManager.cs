using System.Text;

using UnityEngine;
using TMPro;
public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI money;
    [SerializeField]
    TextMeshProUGUI kelpy;
    
    // Update is called once per frame
    void Update()
    {
        money.text = "$" + GameManager.instance.currentMoney.ToString();
        StringBuilder s = new StringBuilder();
        s.Append((GameManager.instance.kelpRating * 100).ToString());
        s.Append("/100");
        kelpy.text = "Kelp Score: " + s.ToString();
    }
}
