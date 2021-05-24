using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
  public class State
    {
      public string Name;
      public Dictionary<char, State> Transitions;
      public bool IsAcceptState;
    }

    public class FA1
    {
      public static State a = new State()
        {
          Name = "a",
          IsAcceptState = true,
          Transitions = new Dictionary<char, State>()
        };

        public State b = new State()
        {
          Name = "b",
          IsAcceptState = true,
          Transitions = new Dictionary<char, State>()
        };

        public State c = new State()
        {
          Name = "c",
          IsAcceptState = false,
          Transitions = new Dictionary<char, State>()
        };

        State InitialState = a;

        public FA1()
        {
          a.Transitions['0'] = b;
          a.Transitions['1'] = a;
          b.Transitions['0'] = c;
          b.Transitions['1'] = b;
          c.Transitions['0'] = c;
          c.Transitions['1'] = c;

        }

        public bool? Run(IEnumerable<char> s)
        {
          State current = InitialState;
          foreach (var c in s)
          {
              current = current.Transitions[c];
              if (current == null)
              {
                return null;
              }
          }
          return current.IsAcceptState;
        }
    }
public class FA2
    {
  public static State a = new State()
        {
          Name = "a",
          IsAcceptState = false,
          Transitions = new Dictionary<char, State>()
        };

        public State b = new State()
        {
          Name = "b",
          IsAcceptState = false,
          Transitions = new Dictionary<char, State>()
        };

        public State c = new State()
        {
          Name = "c",
          IsAcceptState = true,
          Transitions = new Dictionary<char, State>()
        };

        State InitialState = a;

        public FA2()
        {
          a.Transitions['0'] = b;
          a.Transitions['1'] = b;
          b.Transitions['0'] = c;
          b.Transitions['1'] = c;
          c.Transitions['0'] = b;
          c.Transitions['1'] = b;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                {
                    return null;
                }
            }
            return current.IsAcceptState;
        }
    }
  class Program
    {
    static void Main(string[] args)
        {
            String s = "";
            FA1 fa1 = new FA1();
            FA2 fa2 = new FA2();

            Console.WriteLine("Enter string");
            s = Console.ReadLine();

            while (s != "stop")
            {
                bool? result1 = fa1.Run(s);
                Console.WriteLine(result1);

                bool? result2 = fa2.Run(s);
                Console.WriteLine(result2);

                Console.WriteLine("Enter string");
                s = Console.ReadLine();
            }
        }
    }
}
