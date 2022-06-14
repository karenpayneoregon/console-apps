using System.Collections.Generic;

namespace TraverseFolder.Models
{
    public class GroupItem
    {
        public string FolderName { get; }
        public List<Item> FileList { get; }

        public GroupItem(string folderName, List<Item> list)
        {
            FolderName = folderName;
            FileList = list;
        }
    }
}