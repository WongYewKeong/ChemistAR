using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcedureTextTrigger : MonoBehaviour
{
    public ProcedureText procedureText;

    public void TriggerProcedure()
    {
        FindObjectOfType<TextManager>().StartProcedure(procedureText);
    }
}
