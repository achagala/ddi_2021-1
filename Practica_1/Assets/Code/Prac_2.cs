using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prac_2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var students = new List<string>()
                    {
                        "ABIMAEL ALVEZ MADRIGAL", "CRISTIAN ALFREDO ASTORGA SEPULVEDA", "ERICK ARTURO BECERRA PERAZA",
                        "EDGAR ALBERTO CHAGALA JIMENEZ", "LUIS GERARDO DIAZ REYNOSO", "LUIS FERNANDO ESQUEDA GARCIA",
                        "ISAAC HERNANDEZ CANO", "EDGAR MIGUEL LANDA LUNA", "LUIS ELOY LAZCANO ORTIZ",
                        "NEREO CESAR LOPEZ MORENO", "ARACELI LUEVANO CRUZ", "SERGIO ALONSO MARTINEZ SUAREZ",
                        "JORGE ANTONIO MARTINEZ VILLANUEVA", "IVAN ALFREDO MORALES ROSALES", "FELIX ABRAHAM QUINTERO CARRISOZA",
                        "BRANDON RAYGOZA DE LA PAZ", "RAUL ARTURO RODRÍGUEZ CONTRERAS", "MIGUEL ANGEL ROSAS OCAMPO",
                        "DANIEL SANTOS MÉNDEZ", "JOSE LIAM TAPIA OLVERA"                    
                    };

        Debug.Log(IsStudent(students, "Edgar Alberto Chagala Jimenez"));
        Debug.Log(IsStudent(students, "Alberto Chagala"));
        Debug.Log(IsStudent(students, "JORGE ANTONIO MARTINEZ VILLANUEVA"));
        Debug.Log(IsStudent(students, "JORGE MARTINEZ"));
        Debug.Log(IsStudent(students, "Sebastian Huato"));
    }

    bool IsStudent(List<string> students, string person)
    {
        string student = person.ToUpper();
        students.Sort();

        for (int i = 0; i < students.Count; i++)
        {
            if(students[i].Equals(student))
            {
                return true;
            }
        }

        return false;
    }
    
}
