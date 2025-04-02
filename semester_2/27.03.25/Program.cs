using System.Collections;
using System.Diagnostics;

//* Task 1
Func<int, int, int> sum = (x, y) => x + y;
Func<int, int, int> subtract = (x, y) => x - y;
Func<int, int, int> multiply = (x, y) => x * y;
Func<float, float, float> divide = (x, y) => y==0?0:x/y;

Debug.Assert(sum(1, 2) == 3);
Debug.Assert(subtract(1, 2) == -1);
Debug.Assert(multiply(1, 2) == 2);
Debug.Assert(divide(0, 0) == 0);
Debug.Assert(divide(1, 2) == 0.5f);

//* Task 2
string[] lst = ["msfdfge", "dvdfgre", "mdfef", "ew", "mmm", "m", "xmxm"];
Func<string[], ArrayList> m_words = (lst) => {
    ArrayList q = new ArrayList();
    for (int i = 0; i < lst.Length; i++) 
    if(lst[i][0].ToString() == "m") 
    q.Add(lst[i]);
    return q;
    };

Debug.Assert(m_words(lst).Count == 4);


Console.WriteLine("Все тесты успешно пройдены!");