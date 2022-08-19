using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyunkontrol : MonoBehaviour
{
    public bool oyunAktif = true;
    public int kristalSayisi = 3;
    public UnityEngine.UI.Text kristaltext;
    // Start is called before the first frame update
  

    public void KristalSayisiKontrol()
    {
        kristalSayisi -= 1;
        kristaltext.text = "" + kristalSayisi;
    }
}
