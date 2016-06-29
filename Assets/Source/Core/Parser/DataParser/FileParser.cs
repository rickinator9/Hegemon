using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Source.Core.Parser.DataParser.Types;

namespace Assets.Source.Core.Parser.DataParser
{
	public class FileParser
	{
		#region Properties
		private string[] filePaths;

		private IParserType context;
		public ParserObject Root
		{
			get { return (ParserObject)context; }
		}
		#endregion

		#region Constructors
	    public FileParser(string directoryPath)
	    {
	        var filePathList = GetFilePathsInDirectoryRecursive(directoryPath);

			filePaths = filePathList.ToArray();
		}

	    public FileParser(string[] FilePaths)
		{
			filePaths = FilePaths;
		}
		#endregion

		#region Methods
	    public IParserType Parse()
		{
			context = new ParserObject();

			foreach(var filePath in filePaths) {
				var text = File.ReadAllText(filePath);
				foreach (var ch in text) {
					if (ch == '\t' || ch == '\r') {
						; // Do nothing
					}  else {
						context = context.HandleCharacter(ch);						
					}				
				}
			}
			return context;
		}

	    private IList<string> GetFilePathsInDirectoryRecursive(string rootDirectoryPath)
	    {
	        var filesInDirectory = Directory.GetFiles(rootDirectoryPath);
	        var filePathList = new List<string>(filesInDirectory);
	        foreach (var directoryPath in Directory.GetDirectories(rootDirectoryPath))
	        {
                var directory = new DirectoryInfo(directoryPath);
	            if (directory.Name.ToLower() == "wip")
	                continue;

                filePathList.AddRange(GetFilePathsInDirectoryRecursive(directoryPath));
	        }

            return filePathList;
	    } 
		#endregion
	}
}
