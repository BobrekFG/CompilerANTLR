using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Compiler
{
    public class Reg
    {
        int type;
        private char state;
        public Reg(int t)
        {
            type = t;
        }
        public bool CheckString(string input)
        {
            switch (type)
            {
                case 1:
                    {
                        Regex reg = new Regex(@"0*10*10*10*");
                        MatchCollection matches = reg.Matches(input);
                        return matches.Count != 0;
                        break;
                    }
                case 2:
                    {
                        Regex reg = new Regex(@"[A-Z][a-z]* [A-Z]\.[A-Z]\.");
                        MatchCollection matches = reg.Matches(input);
                        return matches.Count != 0;
                        break;
                    }
                case 3:
                    {
                        state = '1';
                        if (input.Length == 0)
                            return false;
                        foreach (var item in input)
                        {
                     
                        switch(state)
                            {
                                case '1': { if (item == 'a') state = '2'; break; }
                                case '2': { if (item == 'a') state = '2'; else if (item == 'b') state = '3'; break; }
                                case '3': { if (item == 'c') state = '4'; break; }
                                case '4': { if (item == 'c') state = '5'; break; }
                                default: return false;
                            }
                        }
                        if (state == '5')
                            return true;
                        else
                            return false;
                        break;
                    }
                case 4:
                    {
                        Regex reg = new Regex(@"10*(123)+");
                        MatchCollection matches = reg.Matches(input);
                        return matches.Count != 0;
                        break;
                    }
                default:
                    break;
            }
            return false;
        }
    }
}
