using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Build.Utilities;
using Microsoft.Build.Framework;
using System.IO;

namespace MSBuildTests.Tasks
{
    public class GenerateDumbFiles : Task
    {
        [Required]
        public string Directory
        {
            get;
            set;
        }

        [Required]
        public string Prefix
        {
            get;
            set;
        }

        [Required]
        public int Count
        {
            get;
            set;
        }

        public override bool Execute()
        {
            for (int i = 0; i < Count; i++)
            {
                FileStream fs = new FileStream(Directory + "\\" + Prefix + (i+1).ToString() + ".txt", FileMode.Create);
                using (fs)
                {
                    byte[] content = Encoding.UTF8.GetBytes("I'm a dumb file");
                    fs.Write(content, 0, content.Length);
                }
            }
            return true;
        }
    }
}

