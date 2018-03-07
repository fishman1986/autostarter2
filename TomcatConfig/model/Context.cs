using System;
using System.Collections.Generic;
using System.Text;

namespace TomcatConfig.model
{
    public class Context
    {
        public bool privileged { get; set; }
        public bool useHttpOnly { get; set; }
        public bool antiResourceLocking { get; set; }
        public bool allowLinking { get; set; }
        /// <summary>
        /// web app's location
        /// </summary>
        public string docBase { get; set; }
        /// <summary>
        /// virtual web path
        /// </summary>
        public string path { get; set; }
    }
}
