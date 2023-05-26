namespace ServStat
{
    public class Stat
    {

        public long freespace { get; set; }

        public List<string> drives { get; set; }

        public Stat()
        {

            DriveInfo d = new DriveInfo("C");
            freespace = d.AvailableFreeSpace;

            drives = new List<string>();
            foreach (DriveInfo item in DriveInfo.GetDrives())
            {
                drives.Add(item.Name);
            }

        }

    }
}
