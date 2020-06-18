using System;
using System.Collections.Generic;
using System.IO;

namespace Bot1
{
    class ChatBot
    {
        string s,
      path,
          userAnswer;
        List<string> sempls = new List<string>();
        bool flag = true;
        public event Action<string> GetStr;

        public ChatBot(string pat)
        {
            path = pat;
            try
            {
                sempls.AddRange(File.ReadAllLines(path));
            }
            catch { }
            GetStr += ChatBot_GetStr;


        }
        private string Answer(string qw)
        {
            string tr = "():^^*!?",
              ans = string.Empty;
            qw = qw.ToLower();
            qw = Trim(qw, tr.ToCharArray());
            for (int i = 0; i < sempls.Count; i += 2)
            {
                if (qw == sempls[i])
                {
                    ans = sempls[i + 1];
                    break;
                }
            }
            return ans;
        }

        private void Teach()
        {
            sempls.Add(s);
            sempls.Add(userAnswer);
            File.WriteAllLines(path, sempls.ToArray());
        }
        public void Ans(string qw)
        {
            if (flag)
            {
                s = qw;
                string ans = Answer(qw);

                if (ans == string.Empty)
                {
                    flag = false;
                    GetStr("\n Введите ответ: ");
                }
                else
                    GetStr("\n Введите ответ: " + ans + "\n Вфш вопрос: ");
            }
            else
            {
                flag = true;
                userAnswer = qw;
                Teach();
                GetStr("\n Ваш вопрос: ");
            }
        }
        string Trim(string str, char[] chars)
        {
            string strA = str;
            for (int i = 0; i < chars.Length; i++)
            {
                strA = strA.Replace(char.ToString(chars[i]), "");
            }
            return strA;

        }
        void ChatBot_GetStr(string obj)
        {

        }


    }
}

