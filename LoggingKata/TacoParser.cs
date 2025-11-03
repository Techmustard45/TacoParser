namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array's Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log error message and return null
                logger.LogError("Invalid Line");
                return null; 
            }
            //get name of TacoBell
            string name = cells[2];
            
            //Get position of TacoBell
            Point loaction = new Point();
            loaction.Latitude = double.Parse(cells[0]);
            loaction.Longitude = double.Parse(cells[1]);

            TacoBell tacoBell = new TacoBell();
            tacoBell.Name = name;
            tacoBell.Location = loaction;

            return tacoBell;
        }
    }
}
