namespace aoc2022_day7;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("AOC2022 Day 7!");
        String input = File.ReadAllText(@"data.txt");

        string[] rows = input.Split('\n');
        List<Directory> allDirs = new List<Directory>();
        List<AFile> allFiles  = new List<AFile>();
        Directory currentDirectory = new Directory();

        foreach (string row in rows)
        {
            
            if (row[0] == '$')
            {
                //Console.WriteLine("Command detected: {0}", row);
                if (row == "$ cd /")
                {
                    Console.WriteLine("cd to root detected");
                    currentDirectory.name = "/";
                    currentDirectory.parentDirs = "";
                }
                if (row[2] == 'c')
                {
                    //Console.WriteLine("cd detected");

                    // cd to dir
                    string[] parts = row.Split(' ');
                    // parts[0]: $
                    // parts[1]: cd
                    // parts[2]: .. or <dir>

                    //foreach (string part in parts)
                    //{
                    //    Console.WriteLine(part);
                    //}
                    // cd to parent (..)
                    if (parts[2] == "..")
                    {
                        Console.WriteLine("cd to parent!");
                        // get immediate parent ( last of parentdirs, split på /)
                        // set CD to this parent
                        // set parentDirs to what is was minus this dir
                        Console.WriteLine("pdlen:{0} ", currentDirectory.parentDirs.Length);
                        string[] tempDirs = currentDirectory.parentDirs.Split('/');
                        foreach (string td in tempDirs)
                        {
                            Console.WriteLine("td: {0}", td);
                        }
                        Console.WriteLine("len:{0} ", tempDirs.Length);
                        if (tempDirs.Length == 2 && tempDirs[tempDirs.Length - 1] == "")
                        {
                            currentDirectory.name = "/";
                            currentDirectory.parentDirs = "";
                            // this will cd to root
                        } else { 

                        currentDirectory.name = tempDirs[tempDirs.Length - 1];
                            //Console.WriteLine("ibcurrentdir: {0} parentdirs: {1}", currentDirectory.name, currentDirectory.parentDirs);
                            //Console.ReadLine();
                            currentDirectory.parentDirs = "";
                            for (int i = 0; i < tempDirs.Length -1; i++)
                        {
                            currentDirectory.parentDirs += tempDirs[i] + '/';
                        }
                            //Console.WriteLine("iacurrentdir: {0} parentdirs: {1}", currentDirectory.name, currentDirectory.parentDirs);
                            //Console.ReadLine();
                        }


                    }
                    else
                    {
                        //Console.WriteLine("cd to directory {0}", parts[2]);
                        if (currentDirectory.name == "/")
                        {
                            //Console.WriteLine("cd from root detected");
                            currentDirectory.name = parts[2];
                            currentDirectory.parentDirs = "/";
                        }
                        else
                        {
                            Console.WriteLine("cd from not root detected");
                            currentDirectory.parentDirs += currentDirectory.name;
                            currentDirectory.name = parts[2];

                        }
                        
                    }
                    Console.WriteLine("currentdir: {0} parentdirs: {1}", currentDirectory.name, currentDirectory.parentDirs);
                }

            } else
            {
                Console.WriteLine("listing detected: {0}", row);
            }

        }

    }
}
public class Directory
{
    public string name;
    public string parentDirs;
    public int sizeOfFiles;
}

public class AFile
{
    public string name;
    public string parentDirs;
    public int size;
}