**Inoxie.Tools.Excel**

Nuget package used to import and export data to xlsx files. How to use it:

 1. Install nuget package Inoxie.Tools.Excel
 2.  Register dependency injection
   `services.AddInoxieToolsExcel();`
  3. Create xlsx stream 
  
		   internal class DummyExporter
		   {
		    public DummyExporter(ISpreadsheetBuilder spreadsheetBuilder)
		    {
		        this.spreadsheetBuilder = spreadsheetBuilder;
		    }

		    public Stream Export()
		    {
		        var sheetName = "DummySheet";
		        var data = new List<(long Id, string Name)>()
		        {
		             new (1, "DummyName1"),
		             new (2, "DummyName2"),
		        };

		        var stream = spreadsheetBuilder
		            .Create()
		            .CreateSheet(sheetName)
		            .CreateHeaderRow(sheetName, new string[] { "Id", "Name" })
		            .InsertRowData(sheetName,
		                data.Select(s => new object[] { s.Id.ToString(), s.Name }))
		            .WriteToStream();

		        return stream;
		    }
		   }
 
 3. Read xlsx data
 
		   internal class DummyReader
		   {
			    public DummyReader(ISpreadsheetReader spreadsheetReader)
			    {
			        this.spreadsheetReader = spreadsheetReader;
			    }

			    public void Read()
			    {
			        var sheets = spreadsheetReader.Read(stream);
			       
			        foreach (var (name, data) in sheets)
			        {
					        foreach (var row in data)
					        {
								    foreach (var cell in row ) 
								    {
									    console.log(cell); //reads cell data
								    }
					        }
			        }			        
		   }