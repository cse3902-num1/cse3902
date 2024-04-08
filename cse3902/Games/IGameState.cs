using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cse3902.Games
{
    public interface IGameState
    {
        public void Update(GameTime gameTime, List<IController> controllers);
        public void Draw(Camera camera);
    }
}
