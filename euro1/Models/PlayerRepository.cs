using euro1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace euro1.Controllers
{
    public class PlayerRepository
    {
        euroContext db = new euroContext();

        public List<Player> GetAllPlayers() {
            return db.player.ToList();
    }
    }

}