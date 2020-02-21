using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeLibrary
{
    public class BadgeMethods
    {
        private readonly Dictionary<string, List<string>> _Badges = new Dictionary<string, List<string>>();
        //static Dictionary<string, List<string>> Badges;
        
        
        public void AddKeyValuePairToDictionary(Badge newBadge)
        {
            _Badges.Add(newBadge.BadgeID, newBadge.Doors);
        }
        public Dictionary<string,List<string>> ViewValueFromDictionary()
        {
            return _Badges;
        }
        public void ViewStuffLikeAString()
        {
            foreach (KeyValuePair<string, List<string>> newBadge in _Badges)
            {
                Console.WriteLine($"{newBadge.Key} {string.Join(",", newBadge.Value)}");
            }
        }
        public List<string> GetListByID(string userInput)
        {//userInput as ReadLine in UI
            foreach (KeyValuePair<string, List<string>> newBadge in _Badges)
            {
             if (userInput==newBadge.Key)
                {
                    return newBadge.Value;
                }
            }
            return null;
        }

    }
}
