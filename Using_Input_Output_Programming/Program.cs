using System;
using System.IO;
namespace Using_Input_Output_Programming
{
    // Read a character from the keyboard.
    /*
    internal class Program
    {
        public static void Main()
        {
            char
                ch;
            Console.WriteLine("Keyword any key press ");
            ch= (char)Console.Read();
            Console.WriteLine("Your Press Key :" + ch);
        }
    }

    // Read keystrokes from the console by using ReadKey().
   class Readkey
    {
        public static void Main()
        {
            ConsoleKeyInfo keypress;
            Console.WriteLine("Enter keystrokes : Q is a Stop");
            do
            {
                keypress = Console.ReadKey();
                Console.WriteLine("\tYour Key Is \t " + keypress.KeyChar);
                // Check for modifier keys.
                if ((ConsoleModifiers.Alt & keypress.Modifiers) != 0)
                {
                    Console.WriteLine("Alt key pressed");
                }
                if ((ConsoleModifiers.Control & keypress.Modifiers) != 0)
                {
                    Console.WriteLine("Control Key Pressed");
                }
                if ((ConsoleModifiers.Shift & keypress.Modifiers) != 0)
                {
                    Console.WriteLine("Shift Key Pressed");
                }

            } while (keypress.KeyChar != 'Q');
        }
    }
        
Display a text file.
 To use this program, specify the name of the file that you
 want to see. For example, to see a file called TEST.CS,
 use the following command line.
 ShowFile TEST.CS

    class TextFileDemo
    {
        public static void Main(String [] args)
        {
            int i;
            FileStream fin;
            if(args.Length !=1)
            {
                Console.WriteLine("Useage : Show File ");
                return;
            }
            try
            {
                fin = new FileStream(args[0], FileMode.Open);
            }
            catch (IOException exc)
            {
                Console.WriteLine("Cannot Open File");
                Console.WriteLine(exc.Message);
                return; 
            }
            
            try
            {
                do
                {
                    i = fin.ReadByte();
                    if (i != -1) Console.Write((char)i);
                } while (i != -1);
            }
            catch (IOException exc)
            {
                Console.WriteLine("Error Reading File");
                Console.WriteLine(exc.Message);
            }
            finally
            {
                fin.Close();
            }
        }
       }
        
    // Demonstrate random access.
    class RandomAccess
    {
        public static void Main()
        {
            FileStream  f= null;
            char ch;
            try
            {
                f = new FileStream("Random.dat", FileMode.Create);
                for(int i=0; i<26; i++)
                {
                    f.WriteByte((byte)('A' + i));
                    f.Seek(0, SeekOrigin.Begin); 
                    ch = (char)f.ReadByte();
                    Console.WriteLine("First value is " + ch);
                    f.Seek(1, SeekOrigin.Begin); // seek to first byte
                    ch = (char)f.ReadByte();
                    Console.WriteLine("Seconds value is " + ch);
                    f.Seek(4, SeekOrigin.Begin); // seek to first byte
                    ch = (char)f.ReadByte();
                    Console.WriteLine("thirds value is " + ch);
                    Console.WriteLine();
                }
                Console.WriteLine("Here is every other value: ");
                for(int i=0; i<26;i+=1)
                {
                    f.Seek(i, SeekOrigin.Begin); 
                    ch = (char)f.ReadByte();
                    Console.Write(ch + " ");
                } 
            }
            catch(IOException exc)
            {
                Console.WriteLine("I/O Error " + exc.Message);
            }
            finally {

                if (f != null) f.Close();
             }
        }
    }
   
    //// Demonstrate MemoryStream.
    class MemStrDemo
    {
        static void Main()
        {
            byte[] storage = new byte[255];
            
            MemoryStream memstrm = new MemoryStream(storage);
           
            StreamWriter memwtr = new StreamWriter(memstrm);
            StreamReader memrdr = new StreamReader(memstrm);
            try
            {
                
                for (int i = 0; i < 10; i++)
                    memwtr.WriteLine("byte [" + i + "]: " + i);
               
                memwtr.WriteLine(".");
                memwtr.Flush();
                Console.WriteLine("Reading from storage directly: ");
                
                foreach (char ch in storage)
                {
                    if (ch == '.') break;
                    Console.Write(ch);
                }
                Console.WriteLine("\nReading through memrdr: ");
                
                memstrm.Seek(0, SeekOrigin.Begin); 
                string str = memrdr.ReadLine();
                while (str != null)
                {
                    str = memrdr.ReadLine();
                    if (str[0] == '.') break;
                    Console.WriteLine(str);
                }
            }
            catch (IOException exc)
            {
                Console.WriteLine("I/O Error\n" + exc.Message);
            }
            finally
            {
                
                memwtr.Close();
                memrdr.Close();
            }
        }
    }
     */
    // Redirect Console.Out.

    class Redirect
    {
        static void Main()
        {
            StreamWriter log_out = null;
            try
            {
                log_out = new StreamWriter("logfile.txt");
                // Redirect standard out to logfile.txt.
                Console.SetOut(log_out);
                Console.WriteLine("This is the start of the log file.");
                for (int i = 0; i < 10; i++) 
                    
                    Console.WriteLine(i);
                Console.WriteLine("This is the end of the log file.");
            }
            catch (IOException exc)
            {
                Console.WriteLine("I/O Error\n" + exc.Message);
            }
            finally
            {
                if (log_out != null) log_out.Close();
            }
        }
    }
}
