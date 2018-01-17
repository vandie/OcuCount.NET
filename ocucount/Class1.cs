using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ocucount
{
    // Written by Michael Van Der Velden 2018
    // MIT

    public class Count{
        public string word;
        public int num;

        public Count(string word, int num){
            this.word = word;
            this.num = num;
        }

        /// <summary>
        /// Increases the count for this word by one.
        /// </summary>
        public void increaseCount(){
            num += 1;
        }
    }

    public class Counter
    {
        public List<Count> dict = new List<Count>();
        string sentence = "";

        /// <summary>
        /// Returns a new <see cref="T:ocucount.Counter"/> class containing the data for the given scentence.
        /// </summary>
        /// <param name="text">The text to count occurences from.</param>

        public Counter(string text){
            sentence = Regex.Replace(text, @"[^\w\s]", "").ToLower();
            string[] splitList = sentence.Split(' ');

            foreach ( string s in splitList ){
                int i = dict.FindIndex(l => l.word == s);
                if (i == -1) dict.Add(new Count(s, 1));
                else dict[i].increaseCount();
            }

            dict = dict.OrderByDescending(o => o.num).ToList();
        }

        /// <summary>
        /// Converts the count array to a JSON string.
        /// </summary>
        /// <returns>A JSON String.</returns>
        public string ToJSONString(){
            string[] jsona = new string[dict.Count()];
            int i = 0;
            foreach( Count d in dict ){
                jsona[i] = " { \"word\":\"" + d.word + "\", \"count\":" + d.num + " }";
                i++;
            }
            return "[ " + String.Join(", ",dict) + " ]";
        }

        /// <summary>
        /// Gets the occurence count for an indevidual word.
        /// </summary>
        /// <returns>The word count.</returns>
        /// <param name="word">A word.</param>
        /// 
        public Count getWordCount(string word){
            return dict.Find(l => l.word == word);
        }

        /// <summary>
        /// Compares two words.
        /// </summary>
        /// <returns>The difference in number of occurences betwee nthe given words.</returns>
        /// <param name="wordA">Word A.</param>
        /// <param name="wordB">Word B.</param>

        public int compareWords(string wordA, string wordB){
            Count a = dict.Find(l => l.word == wordA);
            Count b = dict.Find(l => l.word == wordB);

            if (a.num > b.num) return a.num - b.num;
            else if (a.num < b.num) return b.num - a.num;
            else return 0;
        }
    }
}
