using Mono.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desky
{

    class Program
    {
        static List<string> extra;
        static List<int> desktop;
        static List<string> wallpaper;

        [STAThread]
        static void Main(string[] args)
        {
            desktop = new List<int>();
            wallpaper = new List<string>();


            bool showHelp = false;
            bool useList = false;
            bool listScreens = false;
            bool make = false;
            bool makeWithFile = false;
            string jsonFile = null;
            string txtFile = null;

            var p = new OptionSet()
            {
                //{"j|json=", "The {JSON} file to use to load wallpapers", j => jsonFile = j },
                {"f|file=", "The {FILE} to use - each desktop wallpaper is on it's own line.", j => txtFile = j },
                {"a|use-args", "Use the extra arguments to set a wallpaper in order", j => useList = j != null },
                {"help", "show this message", j => showHelp = j != null },
                {"ls", "list the screens", j => listScreens = j != null },
                {"m|make", "Make a wallpaper configuration file, use in conjunction with `-f %` or `--file=%` to use the configuration straight away.",  j =>  make = j != null }
            };

            try
            {
                extra = p.Parse(args);
            }
            catch (OptionException e)
            {
                Console.Write("desky: ");
                Console.WriteLine(e.Message);
                Console.WriteLine("Try `desky --help' for more information.");
                return;
            }

            if (useList)
            {
                int count = 0;
                foreach (var arg in extra)
                {
                    Wallpaper.SetWallpaper((uint)count, arg);
                    count++;
                }
            }
            else if (make)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "png|*.png|jpg|*.jpg"
                };

                List<string> wallpapers = new List<string>();
                var c = Wallpaper.Interface.GetMonitorDevicePathCount();
                for (int i = 0; i < c; i++)
                {
                    openFileDialog.Title = $"Wallpaper for screen {i + 1}";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        wallpapers.Add(openFileDialog.FileName);
                    }
                    else
                    {
                        return;
                    }
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Plain Text File|*.txt"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Console.WriteLine("Wrote to file: " + saveFileDialog.FileName);
                    File.WriteAllLines(saveFileDialog.FileName, wallpapers);
                }

                if (txtFile != null && txtFile == "%")
                {
                    ParseTextFile(saveFileDialog.FileName);
                }
            }
            else if (listScreens)
            {
                Console.WriteLine(string.Join("\n", Wallpaper.GetMonitors()));
                Console.WriteLine(Wallpaper.GetAsciiMonitorRepresentation());
                //Wallpaper.ShowIdentifiers();
            }
            else if (jsonFile != null)
            {
                // do stuffs
            }
            else if (txtFile != null)
            {
                ParseTextFile(txtFile);
            }
            else
            {
                showHelp = true;
            }

            if (showHelp)
            {
                Console.WriteLine("==== DESKY ====");
                p.WriteOptionDescriptions(Console.Out);
                Console.ReadLine();
            }
        }

        private static void ParseTextFile(string txtFile)
        {
            string[] wallpapers = File.ReadAllLines(txtFile);

            int count = 0;
            foreach (var arg in wallpapers)
            {
                if (arg.Trim().StartsWith("#"))
                {

                }
                else if (arg.Length <= 1)
                {

                }
                else
                {
                    Wallpaper.SetWallpaper((uint)count, arg);
                    count++;
                }
            }
        }
    }
}
