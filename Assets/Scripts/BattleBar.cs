using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text NameText;
    [SerializeField] Text LevelText;
    [SerializeField] HPBar hPBar;
    Unit unit1;
    
    public void SetData(Unit unit)
    {
        unit1 = unit;
        NameText.text = unit.Base.name;
        LevelText.text = "Lvl" + unit.Level;
        hPBar.setData((float)unit.Hp/unit.MaxHP);
    }

    public IEnumerator UpdateHP()
    {
       yield return hPBar.setHPSmoth((float)unit1.Hp/unit1.MaxHP);
    }
}
