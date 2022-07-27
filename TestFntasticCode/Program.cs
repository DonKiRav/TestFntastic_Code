using System;

namespace TestFantastic
{
    class Program
    {
        static void Main()
        {
            Program pr = new Program();
            string s1 = Console.ReadLine().ToLower();

            // простой вариант
            pr.EasyResalt(s1); 

            // усложненный вариант, с использованием быстрой сортировки
            //char[] sortarrey = s1.ToCharArray(); 
            //sortarrey = pr.SortArray(sortarrey, 0, s1.Length - 1); // сначала сортируем строку
            //pr.ChangeSymbol(sortarrey, s1); // потом заменяем символы
            
        }
        public char[] SortArray(char[] myarray, int leftIndex, int rightIndex)
        {
            //string s2 = array;
            //char[] myarrey = array.ToCharArray();
            var i = leftIndex;
            var j = rightIndex;
            var pivot = myarray[leftIndex];
            do
            {
                while (myarray[i] < pivot)
                {
                    i++;
                }

                while (myarray[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    var temp = myarray[i];
                    myarray[i] = myarray[j];
                    myarray[j] = temp;
                    i++;
                    j--;
                }
            }
            while (i <= j);
            
            if (leftIndex < j)
                SortArray(myarray, leftIndex, j);
            if (i < rightIndex)
                SortArray(myarray, i, rightIndex);
            return myarray;
        }
        public string ChangeSymbol(char[] sortarrey, string resultarrey)
        {
            for (int i = 0; i < sortarrey.Length; i++)
            {
                if (i + 1 < sortarrey.Length && sortarrey[i] == sortarrey[i + 1])
                {
                    while(i + 1 < sortarrey.Length && sortarrey[i] == sortarrey[i + 1])
                    {
                        i++;
                    }
                    resultarrey = resultarrey.Replace(sortarrey[i].ToString(), ")");
                }
                else
                {
                    resultarrey = resultarrey.Replace(sortarrey[i].ToString(), "(");
                }
            }
            Console.WriteLine(resultarrey);
            return resultarrey;
        }
        public void EasyResalt(string s)
        {
             bool once = true;// встречается ли буква один раз(если да то true, если нет false )
             string s2 = "";
            
             for(int i = 0; i < s.Length; i++)
             {
                 for (int j = 0; j < s.Length; j++)
                 {
                     if (s[i] == s[j] && i != j) // если встречается второй символ
                     {
                         once = false; // символ встречается 2 раза
                         break;
                     }
                 }
                 if (once) // заполняем вторую строку 0 или 1
                 {
                     s2 += "0";
                 }
                 else
                 {
                     s2 += "1";
                 }
                 once = true;
             }
             s2 = s2.Replace("0", "(");
             s2 = s2.Replace("1", ")");
             Console.WriteLine(s2);
        }
    }
}



