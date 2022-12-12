using GameOfLife.system.impl;

DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

void Main()
{
    int tps = 20; // Ticks Per second, determines how often game logic gets updated.
    int fps = 20;

    ConsoleScreen consoleScreen = new ConsoleScreen(
        new GameOfLife.system.Vector2i(0, 0), 
        new GameOfLife.system.Vector2i(Console.WindowWidth, Console.WindowHeight));
    GameWorld gameWorld = new GameWorld(new GameOfLife.system.Vector2i(Console.WindowWidth, Console.WindowHeight));

    long lastUpdate = (long)(DateTime.UtcNow - epoch).TotalMilliseconds;
    long lastDraw = (long)(DateTime.UtcNow - epoch).TotalMilliseconds;
    while (true)
    {
        long now = (long)(DateTime.UtcNow - epoch).TotalMilliseconds;
        long deltaTime = (now - lastUpdate);
        long deltaFrameTime = (now - lastDraw);

        // Runs an update on the gameworld's logic
        if (deltaTime >= 1000/tps)
        {
            consoleScreen.Update(deltaTime, gameWorld);
            gameWorld.Update(deltaTime);
            lastUpdate = now;
        }

        if (deltaFrameTime >= 1000 / fps)
        {
            consoleScreen.Draw(deltaTime, gameWorld);
            lastDraw = now;
        }

    }

}

Main();