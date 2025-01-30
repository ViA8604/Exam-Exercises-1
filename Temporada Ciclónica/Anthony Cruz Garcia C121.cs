/*public static class Examen
{
    public static int MinEstudiantesAvisar(bool[,] amigos, int k)
    {
        int MinStudents = int.MaxValue;
        for (int i = 0; i <= k; i++)
        {
            if (MinStudents == 1)
            {
                return 1;
            }
            AlertStudents(new bool[amigos.GetLength(0)], ref MinStudents, 0, amigos, i,new bool[amigos.GetLength(0)]);
        }

        return MinStudents;
    }
    static void AlertStudents(bool[] studentsAlert, ref int MinStudents, int students, bool[,] friends, int profundity,bool[]DecanoAlert)
    {

        if (AllStudentsAlert(studentsAlert))//caso base
        {
            if (students < MinStudents)
            {
                MinStudents = students;
            }
            return;
        }

        if (students > MinStudents)//poda
        {
            return;
        }
        for(int i=0;i<studentsAlert.Length;i++)
        {
            if(!DecanoAlert[i])
            {
                DecanoAlert[i]=true;
                AlertStudents(Alert(studentsAlert,friends,i,profundity),ref MinStudents,students+1,friends,profundity,DecanoAlert);
                DecanoAlert[i]=false;
            }
        }
    }
    static bool[] Alert(bool[] studentsAlert, bool[,] friends, int student, int profundity)
    {
        bool[]Mask=CopyMask(studentsAlert);
        Mask[student] = true;
        for (int a = 0; a < profundity; a++)
        {
            for (int i = 0; i < studentsAlert.Length; i++)
            {
                if (friends[i, student])
                {
                    Mark(Mask,friends,i,profundity-1);
                }
            }
        }
        return Mask;
    }
    static void Mark(bool[] studentsAlert, bool[,] friends, int student, int profundity)
    {
        studentsAlert[student]=true;
        for (int a = 0; a < profundity; a++)
        {
            for (int i = 0; i < studentsAlert.Length; i++)
            {
                if (friends[i, student])
                {
                    Mark(studentsAlert,friends,i,profundity-1);
                }
            }
        }
    }
    static bool AllStudentsAlert(bool[] studentsAlert)
    {
        foreach (bool IsAlert in studentsAlert)
        {
            if (!IsAlert)
            {
                return false;
            }
        }
        return true;
    }
    static bool[] CopyMask(bool[] source)
    {
        bool[] NewMask = new bool[source.Length];
        Array.Copy(source, NewMask, source.Length);
        return NewMask;
    }
}
*/