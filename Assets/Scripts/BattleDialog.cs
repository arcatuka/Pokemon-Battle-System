using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleDialog : MonoBehaviour
{
        [SerializeField] int LetterperSecond;
        //[SerializeField] Color HighlightedColor;
        [SerializeField] Text DialogText;
        [SerializeField] GameObject ActionSelector;
        [SerializeField] GameObject MoveSelector;
        [SerializeField] GameObject MoveDetails;

        [SerializeField] List<Text> actionTexts;
        [SerializeField] List<Text> MoveTexts;

        [SerializeField] Text ppText;
        [SerializeField] Text typeText;
        public void SetDialog(string dialog)
        {
                DialogText.text = dialog;
        }

        public IEnumerator TypeDialog(string dialog)
        {
                DialogText.text = "";
                foreach(var letter in dialog.ToCharArray())
                {
                        DialogText.text += letter;
                        yield return new WaitForSeconds(1f/LetterperSecond);
                }
        }

        public void enableDialogText(bool Enabled)
        {
                DialogText.enabled = Enabled;
        }

        public void enableActionSeletor(bool enabled)
        {
                ActionSelector.SetActive(enabled);
        }

        public void enableMoveSelector(bool enabled)
        {
                MoveSelector.SetActive(enabled);
                MoveDetails.SetActive(enabled);
        }

        public void UpdateActionSelector(int SelectAction)
        {
                for(int i= 0;i < actionTexts.Count;i++)
                {
                        if (i == SelectAction)
                        {
                                actionTexts[i].color = Color.blue;
                        }
                        else actionTexts[i].color = Color.black;        
                }
        }
        public void UpdateMoveSelector(int SelectMove, Move move)
        {
                for(int i= 0;i < MoveTexts.Count;i++)
                {
                        if (i == SelectMove)
                        {
                                MoveTexts[i].color = Color.blue;
                        }
                        else MoveTexts[i].color = Color.black;        
                }

                ppText.text = $"PP {move.pp}/{move.Base.PP}";
                typeText.text = move.Base.type.ToString();
        }
        public void SetMoveName(List<Move> moves)
        {
                for(int i=0; i< MoveTexts.Count;i++)
                {
                        if(i< moves.Count)
                        {
                                MoveTexts[i].text= moves[i].Base.name;
                        }
                        else MoveTexts[i].text = "-";
                }
        }
        
}
