using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Relations.Association
{
    class Team
    {

    }

    class Player
    {
        public Team Team { get; set; }
    }
}
